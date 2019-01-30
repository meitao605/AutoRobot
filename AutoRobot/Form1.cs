using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jai_FactoryDotNET;
using EasyModbus;
using System.Threading;
using System.Net.Sockets;
using System.IO.Ports;

namespace AutoRobot
{
    public partial class Form1 : Form
    {
        CFactory myFactory = new CFactory();
        CCamera myCamera;
        private string CameraName;
        SerialPort MoChaMachine = new SerialPort("COM3", 115200, Parity.Even, 7, StopBits.Two);

        TcpClient AGVTcp = new TcpClient();
        TcpClient AGVTcpStatus = new TcpClient();

        private bool AGVconnected = false;
        ModbusClient RobotModbus = new ModbusClient("134.64.230.204", 502);
        

        System.Windows.Forms.Timer statemachinetimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer Getrobottimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer agvstatustimer = new System.Windows.Forms.Timer();

        int agv_simulation = 0;
        int robotpick_simulation = 0;
        int robotback_simulation = 0;
        int test_simulation = 0;
        int init_simulation = 0;

        private enum Statemachine
        {
            Init,
            idel,
            AGVMoving,
            RobotPick,
            testing,
            RobotReturn
        }
        Statemachine mystatemachine = Statemachine.idel;
        
        public Form1()
        {
            InitializeComponent();
            statemachinetimer.Interval = 3000;
            statemachinetimer.Tick += Statemachinetimer_Tick;
            Getrobottimer.Interval = 1000;
            Getrobottimer.Tick += Getrobottimer_Tick;
            agvstatustimer.Interval = 300;
            agvstatustimer.Tick += Agvstatustimer_Tick;

            

            //      AGVClient.DataReceived += AGVClient_DataReceived;
            for (int i = 0; i < 18; i++)
            {
                Positions.Items.Add("A" + (i + 1).ToString());
            }
            
            try
            {
                AGVTcp.Connect("134.64.230.204", 19206);
                AGVInfo.Text = "134.64.230.204";
                AGVconnected = true;
            }
            catch (Exception)
            {
                AGVInfo.Text = "AGV not connected";
                AGVconnected = false;
            }

            try
            {
                AGVTcpStatus.Connect("134.64.230.204", 19204);
                AGVInfo.Text = "134.64.230.204";
                AGVconnected = true;
            }
            catch (Exception)
            {
                AGVInfo.Text = "AGV not connected";
                AGVconnected = false;
            }


            try
            {
                RobotModbus.Connect();
                RobotInfo.Text = "134.64.230.204:502";
            }
            catch (Exception)
            {
                RobotInfo.Text = "Robot not connected";
            }

            Jai_FactoryWrapper.EFactoryError error = Jai_FactoryWrapper.EFactoryError.Success;
            error = myFactory.Open("");
            InitCamera();
            StartCamera();
            statemachinetimer.Start();
           
        }

        private void Agvstatustimer_Tick(object sender, EventArgs e)
        {

            byte[] commands = { 0x5A, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00,0x00, 0x03, 0xEC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
            byte[] Tcpbuffer = new byte[256];

            NetworkStream AGVStream = AGVTcpStatus.GetStream();
            AGVStream.Write(commands, 0, commands.Length);

            try
            {
                AGVStream.Read(Tcpbuffer, 0, Tcpbuffer.Length);
            }

            catch (Exception)
            {
                throw;
            }

            byte[] stringbuffer = new byte[256];

            for (int i = 16; i < Tcpbuffer.Length; i++)
            {
                stringbuffer[i - 16] = Tcpbuffer[i];
            }
            string s = System.Text.Encoding.UTF8.GetString(stringbuffer);


            commands[9] = 0xED;
            byte[] speedtcpbuffer = new byte[256];
            AGVStream.Write(commands, 0, commands.Length);

            try
            {
                AGVStream.Read(speedtcpbuffer, 0, speedtcpbuffer.Length);
            }

            catch (Exception)
            {
                throw;
            }

            string r = "";

            
            byte[] speedbuffer = new byte[256];

            for (int i = 16; i < speedtcpbuffer.Length; i++)
            {
                speedbuffer[i-16] = speedtcpbuffer[i];
            }

             r  = System.Text.Encoding.UTF8.GetString(speedbuffer);
            string[] speed = r.Split(',');
            bool speedzero = true;
            foreach (var item in speed)
            {
                string m = item.Substring(item.LastIndexOf(":")+1);
                try
                {
                    m = m.Remove(m.LastIndexOf("}"));
                }
                catch (Exception)
                {

                }
                speedzero = speedzero &&(m == "0.0"||m == "-0.0");
            }

            AGV_Status.Text = s;
            AGV_Speed.Text = r;
            if (s.Contains("LM1") && speedzero)
            {
                agvstatustimer.Stop();
            }
        }

        /// <summary>
        /// this timer is going to read the status of the robot to confirm the UUT has been put and the robot
        /// has already gone the the right position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Getrobottimer_Tick(object sender, EventArgs e)
        {
            int position = RobotModbus.ReadHoldingRegisters(135, 5)[3];

            RobotStatus.Text = "The Robot Status is: " + position.ToString(); 
            if(position == 1)
            {
                Getrobottimer.Stop();
            }
            //throw new NotImplementedException();
        }


        /// <summary>
        /// THis funtion doing the state machine for the main control logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Statemachinetimer_Tick(object sender, EventArgs e)
        {

            switch (mystatemachine)
            {
                case Statemachine.Init:
                    init_simulation++;
                    TestStatus.Text = "Here's Init AGV, Robot Mocha,Confirm they're in good state." + "Init time: " + init_simulation.ToString() ;
                    if(init_simulation>3)
                    {
                        init_simulation = 0;
                        mystatemachine = Statemachine.AGVMoving;
                    }
                    break;
                case Statemachine.idel:

                    TestStatus.Text = "IDEL";

                    break;
                case Statemachine.AGVMoving:
                    agv_simulation++;
                    TestStatus.Text = "Here's moving the AGV to LM1 before we start pick up UUT." + "AGV Time: " + agv_simulation.ToString();
                    if(agv_simulation>9)
                    {
                        agv_simulation = 0;
                        mystatemachine = Statemachine.RobotPick;
                    }
                    break;
                case Statemachine.RobotPick:
                    robotpick_simulation++;
                    TestStatus.Text = "Here's use the robot to pick up UUT to MoCha Machine" + "Robot Pick: " + robotpick_simulation.ToString();
                    if (robotpick_simulation>9)
                    {
                        robotpick_simulation = 0;
                        mystatemachine = Statemachine.testing;
                    }
                    break;
                case Statemachine.testing:
                    test_simulation++;
                    TestStatus.Text = "Mocha Testing geting the picture" + "picture Number: " + test_simulation.ToString();
                    if (test_simulation > 9)
                    {
                        test_simulation = 0;
                        mystatemachine = Statemachine.RobotReturn;
                    }
                    break;
                case Statemachine.RobotReturn:
                    robotback_simulation++;
                    TestStatus.Text = "Mocha Testing geting the picture" + "picture Number: " + robotback_simulation.ToString();
                    if (robotback_simulation > 9)
                    {
                        robotback_simulation = 0;
                        mystatemachine = Statemachine.idel;
                    }
                    break;
                default:
                    break;
            }

            //StartCapture();
            //  throw new NotImplementedException();
        }

        private void StartCamera()
        {
            if (myCamera != null)
                myCamera.StartImageAcquisition(false, 5);
        }

        private void InitCamera()
        {
            if(myCamera!=null)
            {
                if (myCamera.IsOpen)
                {
                    myCamera.Close();
                }
                myCamera = null;   
            }

            myFactory.UpdateCameraList(Jai_FactoryDotNET.CFactory.EDriverType.FilterDriver);

            for (int i = 0; i < myFactory.CameraList.Count; i++)
            {
                myCamera = myFactory.CameraList[i];
                if(Jai_FactoryWrapper.EFactoryError.Success==myCamera.Open())
                {
                    break;
                }
            }

            if (null != myCamera && myCamera.IsOpen)
            {
                CameraName = myCamera.CameraID;
                CameraName = CameraName.Substring(CameraName.Length - 10);
                CameraInfo.Text =CameraName;
                // Attach an event that will be called every time the Async Recording finishes
                myCamera.AsyncImageRecordingDoneEvent += new CCamera.AsyncImageRecordingDoneHandler(myCamera_AsyncImageRecordingDoneEvent);

                if (myCamera.NumOfDataStreams > 0)
                {
                    Start.Enabled = true;
                }
                else
                {
                    Start.Enabled = false;
                } }
            else
            {
                Start.Enabled = false;
                MessageBox.Show("No Cameras Found!");
                CameraInfo.Text = "No Cameras Found";
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartCapture();
        }

        private void StartCapture()
        {
            if (myCamera != null)
            {
                if (myCamera.IsAsyncImageRecordingRunning || (myCamera.TotalAsyncImagesRecordedCount > 0))
                {

                        myCamera.StopAsyncImageRecording();
                        myCamera.FreeAsyncRecordedImages();
                        myCamera.StartAsyncImageRecording(1, 0, 0);        
                }
                else
                {
                    myCamera.StartAsyncImageRecording(1, 0, 0);
                }
            }
        }


        private void SaveCamera()
        {
            // Have we got any images to save to disk?
            if (myCamera != null && !myCamera.IsAsyncImageRecordingRunning && (myCamera.TotalAsyncImagesRecordedCount > 0))
            {
                    // Disable the Image Recording buttons as long as we are saving the images

                    // Get the recorded images as a list
                    List<Jai_FactoryWrapper.ImageInfo> imageList = myCamera.GetAsyncRecordedImages();

                    // Any images recorded?
                    if (imageList != null && (imageList.Count > 0))
                    {
                        // Run through the list of recorded images
                        for (int index = 0; index < myCamera.TotalAsyncImagesRecordedCount; index++)
                        {
                            Jai_FactoryWrapper.EFactoryError error = Jai_FactoryWrapper.EFactoryError.Success;

                            // Get the recorded image at this index
                            Jai_FactoryWrapper.ImageInfo ii = imageList[index];

                            // Are we saving the images in "raw" format or in Tiff?

          
                                // Create local image that will contain the converted image
                                Jai_FactoryWrapper.ImageInfo localImageInfo = new Jai_FactoryWrapper.ImageInfo();

                                // Allocate buffer that will contain the converted image
                                // In this sample we re-allocate the buffer over-and-over because we assume that the recorded images could be
                                // of different size (If we have been using the Sequence functionality in the cameras)
                                error = Jai_FactoryWrapper.J_Image_Malloc(ref ii, ref localImageInfo);

                                // Convert the raw image to image format
                                error = Jai_FactoryWrapper.J_Image_FromRawToImage(ref ii, ref localImageInfo, 4096, 4096, 4096);

                        // Save the image to disk
                                string time = System.DateTime.Now.Hour.ToString()+"-"+ System.DateTime.Now.Minute.ToString()+"-"+ System.DateTime.Now.Second.ToString();
                                error = Jai_FactoryWrapper.J_Image_SaveFile(ref localImageInfo, ".\\SR" + time + ".tif");
                                FullImageShowBox.Load(".\\SR" + time + ".tif");

                                //Free the conversion buffer
                                error = Jai_FactoryWrapper.J_Image_Free(ref localImageInfo);

                            Application.DoEvents();
                        }

                    }              
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            statemachinetimer.Stop();
            AGVTcp.Close();
            AGVTcpStatus.Close();
            
            //AGVClient.Disconnect();
            RobotModbus.Disconnect();
            if (myCamera != null)
            {
                myCamera.StopImageAcquisition();
                myCamera.Close();
            }
        }
        void myCamera_AsyncImageRecordingDoneEvent(int Count)
        {
            SaveCamera();       
        }

        private void ReconnectCamera_Click(object sender, EventArgs e)
        {
            InitCamera();
        }

        private void ConnectAGV_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //AGVClient.Connect("192.168.1.107", 60000);
                AGVInfo.Text = "134.64.230.204:19206";
                AGVconnected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("AGV not connected");
                AGVInfo.Text = "AGV not connected";
                AGVconnected = false;
            }
        }

        private void ConnectRobot_Button_Click(object sender, EventArgs e)
        {
            try
            {
                RobotModbus.Connect();
                RobotInfo.Text = "192.168.1.107:502";
            }
            catch (Exception)
            {
                RobotInfo.Text = "Robot not connected";
                MessageBox.Show("Robot not connected");
            }
        }

        private void Manual_Button_Click(object sender, EventArgs e)
        {
            Maintab.SelectedIndex = 1;
        }

        private void BacktoMain_Click(object sender, EventArgs e)
        {
            Maintab.SelectedIndex = 0;
        }

        private void AGVMoveLM1_Click(object sender, EventArgs e)
        {
            if(AGVconnected)
            {

                
                byte[] commands = { 0x5A,0x01,0x00,0x01,0x00,0x00,0x00,0x0C,0x0B,0xEB,0x00,0x00,0x00,0x00,0x00,0x00,0x7B,0x22,0x69,0x64,0x22,0x3A,0x22,0x4C,0x4D,0x31,0x22,0x7D };
                byte[] Tcpbuffer = new byte[256];

                NetworkStream AGVStream = AGVTcp.GetStream();
                AGVStream.Write(commands, 0, commands.Length);

                try
                {
                    AGVStream.Read(Tcpbuffer, 0, Tcpbuffer.Length);
                    if(Tcpbuffer[8] == 0x32 & Tcpbuffer[9] == 0xFB & Tcpbuffer[10] == 0x0B & Tcpbuffer[11] == 0xEB)
                    {
                        AGV_Status.Text = "sent to LM1 sucessful";
                        agvstatustimer.Start();
                    }
                }


                catch (Exception)
                {
                    throw;
                }
                string s = "";

                //for (int i = 0; i < Tcpbuffer.Length; i++)
                //{
                //    s = s + Tcpbuffer[i].ToString("X")+ " ";
                //}

                // AGV_Status.Text = System.Text.Encoding.UTF8.GetString(Tcpbuffer);
                //AGV_Status.Text = s;
                //wait for AGV finished the path, and then enable the buttons.
                AGVMoveLM1.Enabled = false;
                AGVMoveLM2.Enabled = false;
                AGVMoveLM3.Enabled = false;
                AGVMoveLM4.Enabled = false;

                //here do this query work for agv.
                Thread.Sleep(3000);

                AGVMoveLM1.Enabled = true;
                AGVMoveLM2.Enabled = true;
                AGVMoveLM3.Enabled = true;
                AGVMoveLM4.Enabled = true;
          //      AGVStream.Close();

            }
        }


        private void AGVMoveLM2_Click(object sender, EventArgs e)
        {
            if (AGVconnected)
            {


                byte[] commands = { 0x5A, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0C, 0x0B, 0xEB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7B, 0x22, 0x69, 0x64, 0x22, 0x3A, 0x22, 0x4C, 0x4D, 0x32, 0x22, 0x7D };
                byte[] Tcpbuffer = new byte[256];

                NetworkStream AGVStream = AGVTcp.GetStream();
                AGVStream.Write(commands, 0, commands.Length);

                try
                {
                    AGVStream.Read(Tcpbuffer, 0, Tcpbuffer.Length);
                }
                catch (Exception)
                {
                    throw;
                }
                string s = "";

                for (int i = 0; i < Tcpbuffer.Length; i++)
                {
                    s = s + Tcpbuffer[i].ToString("X") + " ";
                }
                //  AGVClient.Write(commands);
                //AGVClient.DataReceived += AGVClient_DataReceived;
                //wait for AGV finished the path, and then enable the buttons.
                AGVMoveLM1.Enabled = false;
                AGVMoveLM2.Enabled = false;
                AGVMoveLM3.Enabled = false;
                AGVMoveLM4.Enabled = false;

                //here do this query work for agv.
                Thread.Sleep(3000);

                AGVMoveLM1.Enabled = true;
                AGVMoveLM2.Enabled = true;
                AGVMoveLM3.Enabled = true;
                AGVMoveLM4.Enabled = true;


            }
        }

        private void AGVMoveLM3_Click(object sender, EventArgs e)
        {
            if (AGVconnected)
            {


                byte[] commands = { 0x5A, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0C, 0x0B, 0xEB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7B, 0x22, 0x69, 0x64, 0x22, 0x3A, 0x22, 0x4C, 0x4D, 0x33, 0x22, 0x7D };

                AGVMoveLM1.Enabled = false;
                AGVMoveLM2.Enabled = false;
                AGVMoveLM3.Enabled = false;
                AGVMoveLM4.Enabled = false;

                //here do this query work for agv.
                Thread.Sleep(3000);

                AGVMoveLM1.Enabled = true;
                AGVMoveLM2.Enabled = true;
                AGVMoveLM3.Enabled = true;
                AGVMoveLM4.Enabled = true;

            }
        }

        private void RobotPick_Click(object sender, EventArgs e)
        {
            if(true)
            {
                RobotModbus.WriteSingleRegister(130, 1);
            }
            //Getrobottimer.Start();
        }

        private void RobotReturn_Click(object sender, EventArgs e)
        {
            if (true)
            {
                int[] register = { 0, 0, 0, 0, 0 };
                RobotModbus.WriteMultipleRegisters(130, register);
            }
        }

        private void CameraCalibration_Click(object sender, EventArgs e)
        {
            mystatemachine = Statemachine.Init;
        }







        //private string HexStringToString(string HexString)
        //{
        //    string stringValue = "";
        //    for (int i = 0; i < HexString.Length / 2; i++)
        //    {
        //        string hexChar = HexString.Substring(i * 2, 2);
        //        int hexValue = Convert.ToInt32(hexChar, 16);
        //        stringValue += Char.ConvertFromUtf32(hexValue);
        //    }
        //    return stringValue;
        //}

    }
}
