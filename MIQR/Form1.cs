using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using OpenCvSharp;
using ZXing;

namespace MIQR
{
    public partial class Form1 : Form
    {
        private int _width = 640;
        private int _height = 480;
        private Mat _frame;
        private VideoCapture _videoCapture;
        private Bitmap _bitmap;
        private Graphics _graphics;
        private string _qrDecoded;
        private BarcodeReader _barcodeReader;
        private Result _result;
        private string _tmpManualReserveNumber;
        // private static string[] liveList = { "12/11 Night", "12/12 Noon", "12/12 Night", "TEST" };
        private static string[] liveList = { "1", "2", "3", "9" };      // 公演順の数字、9はデバッグ用

        public bool CanRead = true;

        public Form1()
        {
            InitializeComponent();
            consoleDisplay_TextBox.Clear();
            this.FormBorderStyle = FormBorderStyle.None;
            // this.WindowState = FormWindowState.Maximized;
            
            AddLog("Initializing...");

            bool result = GoogleApiConnection.ReadGoogle("9");
            if (result)
            {
                AddLog("Google API Connected");
            }
            else
            {
                AddLog("Google API Failed");
                MessageBox.Show(@"Google API Authentication Failed", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
            
            _barcodeReader = new BarcodeReader();

            comboBox_Day.Items.AddRange(liveList);
            comboBox_Day.SelectedIndex = 3;


            // fonts

            //System.Drawing.Text.PrivateFontCollection pfc =
            //    new System.Drawing.Text.PrivateFontCollection();
            //pfc.AddFontFile(@"./OCRA-Alternate.otf");
            //pfc.AddFontFile(@"./Orbitron-Regular.ttf");
            //pfc.AddFontFile(@"./Ronde-B_square.otf");
            //pfc.AddFontFile(@"./meiryob.ttc");
            // foreach (var VARIABLE in pfc.Families)
            // {
            //     AddLog(VARIABLE.Name);
            // }
            //Font f1 = new Font(pfc.Families[1], 48);
            //reserveNumberDisplay_Label.Font = f1;
            //label1.Font = new Font(pfc.Families[2], 80);
            //label2.Font = new Font(pfc.Families[2], 14);
            //label3.Font = new Font(pfc.Families[2], 14);
            //label8.Font = new Font(pfc.Families[2], 14);
            //label4.Font = new Font(pfc.Families[4], 24);
            //label9.Font = new Font(pfc.Families[4], 12);
            //label10.Font = new Font(pfc.Families[4], 12);
            //status_Label.Font = new Font(pfc.Families[2], 72);
            //grantStatus_Label.Font = new Font(pfc.Families[0], 95, FontStyle.Bold);
            
            AddLog("Initialize completed");
        }

        /// <summary>
        /// Start web camera capture
        /// </summary>
        /// <returns>Success?</returns>
        private bool CaptureStart()
        {
            _videoCapture = new VideoCapture(0);
            if (!_videoCapture.IsOpened())
            {
                MessageBox.Show(@"Camera was not found!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            _videoCapture.FrameWidth = _width;
            _videoCapture.FrameHeight = _height;
            _frame = new Mat(_height, _width, MatType.CV_8UC3);
            _bitmap = new Bitmap(_frame.Cols, _frame.Rows, (int)_frame.Step(),
                System.Drawing.Imaging.PixelFormat.Format24bppRgb, _frame.Data);
            
            captureDisplay_pictureBox.Width = _frame.Cols;
            captureDisplay_pictureBox.Height = _frame.Rows;
            
            _graphics = captureDisplay_pictureBox.CreateGraphics();
            backgroundWorker1.RunWorkerAsync();
            return true;
        }

        // [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private string ScanQr(ref Bitmap bitmap)
        {
             _result = _barcodeReader.Decode(bitmap);
             // GC.Collect();
             // GC.WaitForFullGCComplete();
             if (_result != null)
             {
                 return _result.Text;
             }
             _result = null;
             return null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            while (backgroundWorker1.IsBusy) Application.DoEvents();
        }

        // [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!CanRead) return;
            var tmpImage = (Bitmap)_bitmap.Clone();
            tmpImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            
            // 色反転
            // Graphics g = Graphics.FromImage(tmpImage);
            // System.Drawing.Imaging.ColorMatrix cm =
            //     new System.Drawing.Imaging.ColorMatrix()
            //     {
            //         Matrix00 = -1,
            //         Matrix11 = -1,
            //         Matrix22 = -1,
            //         Matrix33 = 1,
            //         Matrix40 = 1,
            //         Matrix41 = 1,
            //         Matrix42 = 1,
            //         Matrix44 = 1
            //     };
            // System.Drawing.Imaging.ImageAttributes ia =
            //     new System.Drawing.Imaging.ImageAttributes();
            // ia.SetColorMatrix(cm);
            // g.DrawImage(tmpImage,
            //     new Rectangle(0, 0, tmpImage.Width, tmpImage.Height),
            //     0, 0, tmpImage.Width, tmpImage.Height, GraphicsUnit.Pixel, ia);
            // g.Dispose();
            // _graphics.DrawImage(tmpImage, 0, 0, _frame.Cols, _frame.Rows);
            
            _qrDecoded = ScanQr(ref tmpImage);
            if (_qrDecoded != null)
            {
                CanRead = false;
                nextScan_Button.Enabled = true;
                status_Label.Text = @"SCANNED";
                status_Label.ForeColor = Color.FromArgb(165, 245, 255);
                AddLog(_qrDecoded);
                
                // QR detected --------------------------------------
                GoogleApiConnection.ReadGoogle(liveListType());
                
                //ユーザー専用のQRインスタンスの作成
                QrProcedure qrProcedure = new QrProcedure(_qrDecoded);
                
                // そもそも正しいQRかどうか
                if (!qrProcedure.CollectId)
                {
                    AddLog("QR authentication denied");
                    status_Label.Text = @"INVALID";
                    status_Label.ForeColor = Color.FromArgb(255, 0, 85);
                    nextScan_Button.Focus();
                    return;
                }
                
                //DBに問い合わせ
                bool isMatched = qrProcedure.CollateUuid();
                if (isMatched)
                {
                    AddLog($"{qrProcedure.ReserveNumber} is matched");
                    status_Label.Text = @"VALID";
                    status_Label.ForeColor = Color.FromArgb(46, 245, 153);
                    var a = GoogleApiConnection.Data;
                    bool checkedIn = GoogleApiConnection.WriteGoogle(true, qrProcedure.ReserveNumber, liveListType());
                    if (checkedIn)
                    {
                        grantStatus_Label.Text = @"受付完了";
                        grantStatus_Label.ForeColor = Color.Cyan;
                        nextScan_Button.Focus();
                    }
                    else
                    {
                        grantStatus_Label.Text = @"受付済み";
                        grantStatus_Label.ForeColor = Color.FromArgb(255, 123, 85);
                        nextScan_Button.Focus();
                    }

                    int reserveNumber =
                        GoogleApiConnection.Data.FindIndex(n => n.ReserveNumber == qrProcedure.ReserveNumber.ToString("0000"));
                    reserveNumberDisplay_Label.Text = GoogleApiConnection.Data[reserveNumber].SeatNumber.ToString();
                }
                else
                {
                    AddLog("QR authentication denied");
                    status_Label.Text = @"INVALID";
                    status_Label.ForeColor = Color.FromArgb(255, 0, 85);
                    nextScan_Button.Focus();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            while (!backgroundWorker1.CancellationPending)
            {
                _videoCapture.Grab();
                OpenCvSharp.Internal.NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(_videoCapture.CvPtr, _frame.CvPtr);
                bw.ReportProgress(0);
            }
        }

        /// <summary>
        /// Display Log on specific console
        /// </summary>
        /// <param name="text">Log detail</param>
        public void AddLog(string text)
        {
            DateTime dateTime = DateTime.Now;
            consoleDisplay_TextBox.AppendText(System.Environment.NewLine + "[" + dateTime.ToString("HH:mm:ss") + "] " + text);
        }

        /// <summary>
        /// Return label for GoogleAPIConnection
        /// </summary>
        /// <returns>liveListType</returns>
        public string liveListType()
        {
            string type = null;
            switch (comboBox_Day.SelectedIndex)
            {
                case 0:
                    //type = "1211NGH";
                    type = "1";
                    break;
                case 1:
                    //type = "1212NOO";
                    type = "2";
                    break;
                case 2:
                    //type = "1212NGH";
                    type = "3";
                    break;
                case 3:
                    //type = "TEST";
                    type = "9";
                    break;
            }

            return type;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool rs = CaptureStart();
            if (rs)
            {
                status_Label.Text = @"SCANNING";
                status_Label.ForeColor = Color.FromArgb(165, 245, 255);
                nextScan_Button.Enabled = true;
                authenticationSearch_Button.Enabled = true;
                captureStart_Button.Enabled = false;
                captureStop_Button.Enabled = true;
                comboBox_Day.Enabled = false;
                AddLog("Capture Start");
            }
        }

        private void nextScan_Button_Click(object sender, EventArgs e)
        {
            grantStatus_Label.Text = @"・・・";
            grantStatus_Label.ForeColor = Color.Cyan;
            status_Label.Text = @"SCANNING";
            status_Label.ForeColor = Color.FromArgb(165, 245, 255);
            reserveNumberDisplay_Label.Text = @"------";
            reserveNumber_TextBox.Clear();
            uuid_TextBox.Clear();
            checkIn_Button.Enabled = false;
            AddLog("Ready to scan");
            CanRead = true;
            nextScan_Button.Enabled = false;
            authenticationSearch_Button.Enabled = true;
        }

        private void authenticationSearch_Button_Click(object sender, EventArgs e)
        {
            CanRead = false;
            authenticationSearch_Button.Enabled = false;
            status_Label.Text = @"MANUAL";
            status_Label.ForeColor = Color.FromArgb(165, 56, 255);
            AddLog("Manual searching...");
            
            QrProcedure qrProcedure = new QrProcedure($"{int.Parse(reserveNumber_TextBox.Text).ToString("0000")}_0");
            string resultUuid = qrProcedure.SearchGoogle(int.Parse(reserveNumber_TextBox.Text).ToString("0000"));
            nextScan_Button.Enabled = true;
            if (resultUuid == "Not Found")
            {
                nextScan_Button.Focus();
                checkIn_Button.Enabled = false;
                uuid_TextBox.Text = resultUuid;
                return;
            }
            
            checkIn_Button.Enabled = true;
            _tmpManualReserveNumber = int.Parse(reserveNumber_TextBox.Text).ToString("0000");
            uuid_TextBox.Text = resultUuid;
        }

        private void checkIn_Button_Click(object sender, EventArgs e)
        {
            GoogleApiConnection.ReadGoogle(liveListType());
            bool checkedIn = GoogleApiConnection.WriteGoogle(true, int.Parse(_tmpManualReserveNumber), liveListType());
            if (checkedIn)
            {
                grantStatus_Label.Text = @"受付完了";
                grantStatus_Label.ForeColor = Color.Cyan;
                nextScan_Button.Focus();
            }
            else
            {
                grantStatus_Label.Text = @"受付済み";
                grantStatus_Label.ForeColor = Color.FromArgb(255, 123, 85);
                nextScan_Button.Focus();
            }

            int reserveNumber =
                GoogleApiConnection.Data.FindIndex(n => n.ReserveNumber == _tmpManualReserveNumber.ToString());
            reserveNumberDisplay_Label.Text = GoogleApiConnection.Data[reserveNumber].SeatNumber.ToString();
            checkIn_Button.Enabled = false;
        }

        private void captureStop_Button_Click(object sender, EventArgs e)
        {
            CanRead = false;
            captureDisplay_pictureBox.Image = null;
            status_Label.Text = @"STOP";
            status_Label.ForeColor = Color.FromArgb(255, 128, 255);
            nextScan_Button.Enabled = false;
            authenticationSearch_Button.Enabled = false;
            captureStart_Button.Enabled = true;
            captureStop_Button.Enabled = false;
            AddLog("Capture Stop");
            // AddLog("Please restart this software");
            backgroundWorker1.CancelAsync();    // backgroundWorker1がカメラオブジェクト(?)を触っているので、
            Thread.Sleep(1000);  // アホ
            _videoCapture.Dispose();            // ここの順番変えると、bg1内のループにてnull(抹殺後のカメラオブジェクト)を参照することになるので注意
            // backgroundWorker1.Dispose();     // このメソッドは何もしないらしい
        }

    }
}
