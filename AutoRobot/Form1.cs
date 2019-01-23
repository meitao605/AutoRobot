using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jai_FactoryDotNET;
using SimpleTCP;
using EasyModbus;
using System.Threading;

using System.Net.Sockets;



namespace AutoRobot
{
    public partial class Form1 : Form
    {
        CFactory myFactory = new CFactory();
        CCamera myCamera;
        private string CameraName;

        TcpClient AGVTcp = new TcpClient();

      //  SimpleTcpClient AGVClient = new SimpleTcpClient();
        private bool AGVconnected = false;
        ModbusClient RobotModbus = new ModbusClient("192.168.1.107", 502);

        string agv_message = "";

        System.Windows.Forms.Timer statemachinetimer = new System.Windows.Forms.Timer();

        private enum Statemachine
        {
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
            
      //      AGVClient.DataReceived += AGVClient_DataReceived;

            try
            {
                AGVTcp.Connect("192.168.1.107", 60000);
                AGVInfo.Text = "192.168.1.107";
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
                RobotInfo.Text = "192.168.1.107:502";
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


        /// <summary>
        /// THis funtion doing the state machine for the main control logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Statemachinetimer_Tick(object sender, EventArgs e)
        {

            switch (mystatemachine)
            {
                case Statemachine.idel:
                    //string bytesend = "000100000006010600020180";
                    //byte[] agvstring = { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x06, 0x00, 0x02, 0x01, 0x80 };
                    //AGVClient.Write(agvstring);
                    break;
                case Statemachine.AGVMoving:
                    break;
                case Statemachine.RobotPick:
                    break;
                case Statemachine.testing:
                    break;
                case Statemachine.RobotReturn:
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
                AGVInfo.Text = "192.168.1.107:60000";
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
                //string bytesend = "000100000006010600020180";
                //byte[] agvstring = { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x06, 0x00, 0x02, 0x01, 0x80 };

                // string commands = HexStringToString("5A0100010000000C0BEB000000000000") + HexStringToString("7B226964223A22") + HexStringToString("4C4D33") + HexStringToString("227D");
                //string commands = HexStringToString("5A0100010000000C0BEB0000000000007B226964223A224C4D31227D");
                
                byte[] commands = { 0x5A,0x01,0x00,0x01,0x00,0x00,0x00,0x0C,0x0B,0xEB,0x00,0x00,0x00,0x00,0x00,0x00,0x7B,0x22,0x69,0x64,0x22,0x3A,0x22,0x4C,0x4D,0x31,0x22,0x7D };
                byte[] Tcpbuffer = new byte[256];
                //AGVClient.Write(commands);
                // AGVClient.DataReceived += AGVClient_DataReceived;
                // AGVTcp.ReceiveTimeout = 3000;
                
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

        private void AGVClient_DataReceived(object sender, SimpleTCP.Message e)
        {
            agv_message += e.MessageString;
            AGV_Status.Text = agv_message;
           // throw new NotImplementedException();
        }

        private void AGVMoveLM2_Click(object sender, EventArgs e)
        {
            if (AGVconnected)
            {
                //string bytesend = "000100000006010600020180";
                //byte[] agvstring = { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x06, 0x00, 0x02, 0x01, 0x80 };

                // string commands = HexStringToString("5A0100010000000C0BEB000000000000") + HexStringToString("7B226964223A22") + HexStringToString("4C4D33") + HexStringToString("227D");
                //string commands = HexStringToString("5A0100010000000C0BEB0000000000007B226964223A224C4D31227D");

                byte[] commands = { 0x5A, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0C, 0x0B, 0xEB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7B, 0x22, 0x69, 0x64, 0x22, 0x3A, 0x22, 0x4C, 0x4D, 0x32, 0x22, 0x7D };
                
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
                //string bytesend = "000100000006010600020180";
                //byte[] agvstring = { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x06, 0x00, 0x02, 0x01, 0x80 };

                // string commands = HexStringToString("5A0100010000000C0BEB000000000000") + HexStringToString("7B226964223A22") + HexStringToString("4C4D33") + HexStringToString("227D");
                //string commands = HexStringToString("5A0100010000000C0BEB0000000000007B226964223A224C4D31227D");

                byte[] commands = { 0x5A, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0C, 0x0B, 0xEB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7B, 0x22, 0x69, 0x64, 0x22, 0x3A, 0x22, 0x4C, 0x4D, 0x33, 0x22, 0x7D };
               // AGVClient.Write(commands);
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
