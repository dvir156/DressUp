﻿using BeckEnd.Data;
using BeckEnd.Models;
using HelixToolkit.Wpf;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DressUp_1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members

        private InMemoryDataAccess DataAccess;
        private List<Button> Shirts = new List<Button>();
        private int shirtsLocation = 0;
        private List<Garment<BitmapImage>> mycollection;
        Mode _mode = Mode.Color;

        KinectSensor _sensor;
        MultiSourceFrameReader _reader;
        IList<Body> _bodies;
        bool _dressbody = false;
        bool _displayBody = false;

        #endregion

        #region Constructor
        private void Create3DViewPort()
        {
            var hVp3D = new HelixViewport3D();
            var lights = new DefaultLights();
            var teaPot = new Teapot();
            hVp3D.Children.Add(lights);
            hVp3D.Children.Add(teaPot);
        }
        public MainWindow()
        {
            InitializeComponent();
            ObjReader CurrentHelixObjReader = new ObjReader();
            Model3DGroup MyModel = CurrentHelixObjReader.Read(@"C:\Users\dvir1\Downloads\WpfApplicationMove3DModel\shirt\Tshirt.obj");
            ModelVisual3D v3d = new ModelVisual3D();
            v3d.Content = MyModel;
            helixPort.Children.Add(v3d);

            DataAccess = new InMemoryDataAccess();
            Shirts.Add(shirt1);
            Shirts.Add(shirt2);
            Shirts.Add(shirt3);
            Shirts.Add(shirt4);

            mycollection = DataAccess.getCollection();

            Load_Shirts(shirtsLocation);
        }

        #endregion

        #region Event handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }

            if (_sensor != null)
            {
                _sensor.Close();
            }
        }
        void Load_Shirts(int num)
        {
            for ( num = num*4 ; num < num + 4; num++)
            {
                if (!(num > mycollection.Count))
                {
                    var garment = DataAccess.getCollection();
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = garment[num].garment;
                    Shirts[num].Background = imageBrush;
                }
                else
                    shirtsLocation = 0;
            }
        }

        void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();

            // Color
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (_mode == Mode.Color)
                    {
                        camera.Source = frame.ToBitmap();
                       
                    }
                }
            }

            // Depth
            using (var frame = reference.DepthFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (_mode == Mode.Depth)
                    {
                        camera.Source = frame.ToBitmap();
                    }
                }
            }

            // Infrared
            using (var frame = reference.InfraredFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    if (_mode == Mode.Infrared)
                    {
                        camera.Source = frame.ToBitmap();
                    }
                }
            }

            // Body
            using (var frame = reference.BodyFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    canvas.Children.Clear();

                    _bodies = new Body[frame.BodyFrameSource.BodyCount];

                    frame.GetAndRefreshBodyData(_bodies);

                    foreach (var body in _bodies)
                    {
                        if (body != null)
                        {
                            if (body.IsTracked)
                            {
                                // Draw skeleton.
                                if (_displayBody)
                                {
                                    canvas.DrawSkeleton(body);
                                }
                                if(_dressbody)
                                {

                                    IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                                    Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();
                                    Joint _spineShoulder = joints[JointType.SpineShoulder];
                                    CameraSpacePoint _spineShoulderpos = _spineShoulder.Position;
                                    _spineShoulder = _spineShoulder.ScaleTo(canvas.ActualWidth, canvas.ActualHeight);
                                    Thickness _spineThickness = new Thickness(_spineShoulder.Position.X/2 + _spineShoulder.Position.Z*100 + 100 , (_spineShoulder.Position.Y + (_spineShoulder.Position.Z-0.1)*30)-120 , 0,0);
                                    shirt.Margin = _spineThickness;
                                    shirt.Height = -_spineShoulder.Position.Z*125+500;
                                    shirt.Width = -_spineShoulder.Position.Z * 125+500;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            _mode = Mode.Color;
        }

        private void Depth_Click(object sender, RoutedEventArgs e)
        {
            _mode = Mode.Depth;
        }

        private void Infrared_Click(object sender, RoutedEventArgs e)
        {
            _mode = Mode.Infrared;
        }

        private void Body_Click(object sender, RoutedEventArgs e)
        {
            _displayBody = !_displayBody;
        }

        private void Collection_Click(object sender, RoutedEventArgs e)
        {
            CollectionShirts.Visibility = new Visibility();
        }
        #endregion



        private void Dressbtn_Click_1(object sender, RoutedEventArgs e)
        { 
            var garment = DataAccess.getCollection();
            _dressbody = true;
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = garment[1].garment;
            shirt.Background = imageBrush;
        }

        private void shirt1_Click(object sender, RoutedEventArgs e)
        {
            _dressbody = true;
            shirt.Background = shirt1.Background;
        }

        private void shirt2_Click(object sender, RoutedEventArgs e)
        {
            _dressbody = true;
            shirt.Background = shirt2.Background;
        }

        private void shirt3_Click(object sender, RoutedEventArgs e)
        {
            _dressbody = true;
            shirt.Background = shirt3.Background;
        }

        private void shirt4_Click(object sender, RoutedEventArgs e)
        {
            _dressbody = true;
            shirt.Background = shirt4.Background;
        }

        private void right_Click(object sender, RoutedEventArgs e)
        {
            shirtsLocation++;
            Load_Shirts(shirtsLocation);
        }
    }

    public enum Mode
    {
        Color,
        Depth,
        Infrared
    }
}
