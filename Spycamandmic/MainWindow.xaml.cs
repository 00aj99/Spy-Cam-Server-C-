using MaterialDesignThemes.Wpf;
using LumiSoft.Net.UDP;
using LumiSoft.Net.Codec;
using LumiSoft.Media.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Spycamandmic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopupBox.Visibility = Visibility.Visible;
        }
        WebSocket4Net.WebSocket audio;
        WebSocket4Net.WebSocket speaker;
        WebSocket4Net.WebSocket camera;
        delegate void vd();
        public void connect(string ip)
        {
            WebSocketSharp.WebSocket sock = new WebSocketSharp.WebSocket("ws://" + ip + ":9682");
           Thread th = new Thread(() => { 
               bool gh =   sock.Connect().Result;
               Application.Current.Dispatcher.Invoke(new Action(() => { 
               
             
               if (gh)
            {
                Sock_Opened(ip, null);
                   sock.Close();
                   
            }
            else
            {
                Sock_Closed(null, null);
            }
               }));
            });
            th.Start();
           
            

        }

        ThreadStart start = new ThreadStart(() => {


            var wv = new WaveIn(WaveIn.Devices[0], 8000, 16, 1, 400);


        });
       
        private void Sock_Opened(string ip, EventArgs e)
        {
            WelcomeMessageSnackbar.Visibility = Visibility.Hidden;
            PopupBox.Visibility = Visibility.Hidden;

            cam.Visibility = Visibility.Visible;
            mic.Visibility = Visibility.Visible;
            bze.Visibility = Visibility.Visible;
            Flash.Visibility = Visibility.Visible;
            camera = new WebSocket4Net.WebSocket("ws://" + ip + ":9682");
            camera.DataReceived += (ui, ty) => {
               
                Gr.Dispatcher.Invoke(new Action(() =>
                { 
                    MemoryStream strm = new MemoryStream(ty.Data);
             
                var imageSource = new BitmapImage();
                 
                imageSource.BeginInit();
                imageSource.StreamSource = strm;
                imageSource.EndInit();
                   
                  
                    if(cam.Tag.ToString() == "0")
                    { 
                        Image rotated90 = new Image();
        TransformedBitmap tb = new TransformedBitmap();

                    tb.BeginInit();
                    tb.Source = imageSource;
                    // Set image rotation.
                    RotateTransform transform = new RotateTransform(-90);
                    tb.Transform = transform;
                    tb.EndInit();

                        ImageBrush gh = new ImageBrush(tb);
                        gh.Stretch = Stretch.Fill;

                        Gr.Background = gh;
                    }
                    else
                    {
                        Image rotated90 = new Image();
                        TransformedBitmap tb = new TransformedBitmap();

                        tb.BeginInit();
                        tb.Source = imageSource;
                        // Set image rotation.
                        RotateTransform transform = new RotateTransform(90);
                        tb.Transform = transform;
                        tb.EndInit();

                        ImageBrush gh = new ImageBrush(tb);
                        gh.Stretch = Stretch.Fill;

                        Gr.Background = gh;
                    }
            
                 
                }
                ));

                   
                
            };
            camera.Closed += (g,j)=> { cam.Dispatcher.Invoke(new Action(() => Sock_Closed(g, j))); };
            camera.Open();
          

            audio = new WebSocket4Net.WebSocket("ws://" + ip + ":9676");
        
            var ou = new WaveOut(WaveOut.Devices[0], 8000, 16, 1);
            audio.DataReceived += (gh, data) => {
              
             ou.Play(data.Data, 0, data.Data.Length);
              
               
           };
            audio.Closed += (h, d) => { ou.Dispose(); };
          
           
                
            audio.Open();
            oi = new WaveIn(WaveIn.Devices[0], 8000, 16, 1, 400);

            speaker = new WebSocket4Net.WebSocket("ws://" + ip + ":9679");

            oi.BufferFull += Oi_BufferFull;
          
           


            speaker.Open();
        }
        WaveIn oi; 
        private void Sock_Closed(object sender, EventArgs e)
        {
            if(camera != null)
            {
                camera.Dispose();
                audio.Dispose();
                speaker.Dispose();

            }
            WelcomeMessageSnackbar.Visibility = Visibility.Visible;
            queue.Enqueue("Connection Error");
            bze.Visibility = Visibility.Hidden;
            cam.Visibility = Visibility.Hidden;
            mic.Visibility = Visibility.Hidden;
            Flash.Visibility = Visibility.Hidden;
            PopupBox.Visibility = Visibility.Visible;
        }
     SnackbarMessageQueue queue = new SnackbarMessageQueue(TimeSpan.FromMinutes(3));
        private void Done_Click(object sender, RoutedEventArgs e)
        {

            PopupBox.IsPopupOpen = false;
            connect(output.Text);
       
            WelcomeMessageSnackbar.MessageQueue = queue;
            queue.Enqueue("Please wait while we check the IpAdress");
        }

        private void mic_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(mic.Tag) == "0")
            {
                //Set mic to record
               
                mice.Kind = PackIconKind.RecordVoiceOver;
               
                oi.Start();
                mic.Tag = "1";
            }
            else
            {
                //Set to stop recording


                mice.Kind = PackIconKind.Record;
       
                oi.Stop();
                mic.Tag = "0";
            }
        }

        private void Oi_BufferFull(byte[] buffer)
        {
            speaker.Send(buffer,0,buffer.Length);
        }

        private void cam_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(cam.Tag) == "0")
            {
                //Set to Back Camera
                camera.Send("back");
                cme.Kind = PackIconKind.CameraFront;


                cam.Tag = "1";
            }
            else
            {
                //Set to Front Camera
               camera.Send("front"); 
                       cme.Kind = PackIconKind.CameraIris;
                cam.Tag = "0";
            }
            
        }

        private void Flash_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(Flash.Tag) == "on")
            {
                //Set to Back Camera
                camera.Send("lightoff");
                Flashm.Kind = PackIconKind.Flash;
               

                Flash.Tag = "off";
            }
            else
            {
                //Set to Front Camera
                camera.Send("lighton");
                Flashm.Kind = PackIconKind.FlashOff;
                Flash.Tag = "on";
            }
        }

        private void Sock(object sender, RoutedEventArgs e)
        {
            try
            {
   camera.Close();
                speaker.Close();
                audio.Close();
            }
            catch (Exception)
            {

         }
         
            Sock_Closed(sender, e);
        }
    }
   
}
