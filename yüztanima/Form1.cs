using System;
using System.Drawing; 
using System.Windows.Forms;


using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace YuzTanimaProjesi 
{
    public partial class Form1 : Form
    {
        
        VideoCapture capture;
        Mat frame;            

        
        Mat gray; 
        CascadeClassifier cascade; 


        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            capture = new VideoCapture(0);

            if (!capture.IsOpened())
            {
                MessageBox.Show("Kamera açılamadı!");
                return;
            }

           
            frame = new Mat();
            gray = new Mat();

            
            
            string cascadePath = System.IO.Path.Combine(Application.StartupPath, "haarcascade_frontalface_default.xml");

            if (!System.IO.File.Exists(cascadePath))
            {
                MessageBox.Show("Haar Cascade dosyası bulunamadı! 'haarcascade_frontalface_default.xml' dosyasının özelliklerini kontrol edin.");
                return;
            }

            cascade = new CascadeClassifier(cascadePath);

            
            timer1.Start();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            capture.Read(frame);

           
            if (frame.Empty())
            {
                timer1.Stop();
                return;
            }

            

            
            Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);

            
            Cv2.EqualizeHist(gray, gray);

          
            Rect[] faces = cascade.DetectMultiScale(
                image: gray,
                scaleFactor: 1.1,
                minNeighbors: 5,
                flags: HaarDetectionTypes.ScaleImage,
                minSize: new OpenCvSharp.Size(30, 30));

            foreach (Rect face in faces)
            {
                Cv2.Rectangle(frame, face, Scalar.Red, 3); 
            }

            
            picKamera.Image = BitmapConverter.ToBitmap(frame);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            timer1.Stop();

           
            if (capture != null)
                capture.Release();

            if (frame != null)
                frame.Dispose();

            if (gray != null)
                gray.Dispose();

            if (cascade != null)
                cascade.Dispose();
        }
    }
}