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

namespace AutoRobot
{
    public partial class Form1 : Form
    {
        CFactory myFactory = new CFactory();
        CCamera myCamera;
        private string CameraName;

        SimpleTcpClient AGVClient = new SimpleTcpClient();
        ModbusClient RobotModbus = new ModbusClient("192.168.1.107", 502);

        Timer statemachinetimer = new Timer();

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
            
            try
            {
                AGVClient.Connect("192.168.1.107", 60000);
                AGVInfo.Text = "192.168.1.107:60000";
            }
            catch (Exception)
            {
                AGVInfo.Text = "AGV not connected";
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


        private void Statemachinetimer_Tick(object sender, EventArgs e)
        {

            switch (mystatemachine)
            {
                case Statemachine.idel:
                    byte[] agvstring = {0x01, 0xAA, 0xB1, 0xDC, 0x10, 0xDD};
                    AGVClient.Write(agvstring);
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
                                error = Jai_FactoryWrapper.J_Image_SaveFile(ref localImageInfo, ".\\RecordedImage" + time + ".tif");
                                FullImageShowBox.Load(".\\RecordedImage" + time + ".tif");

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
            AGVClient.Disconnect();
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
                AGVClient.Connect("192.168.1.107", 60000);
                AGVInfo.Text = "192.168.1.107:60000";
            }
            catch (Exception)
            {
                MessageBox.Show("AGV not connected");
                AGVInfo.Text = "AGV not connected";
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
    }
}
