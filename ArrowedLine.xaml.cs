﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for Choice.xaml
    /// </summary>
    public partial class ArrowedLine : UserControl
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public Point CenterPoint { get; }

        public TransformGroup Transforms { get; } = new TransformGroup();

        public ArrowedLine(Point startPoint, Point endPoint)
        {
            InitializeComponent();
            DataContext = this;
            //double left = startPoint.X < endPoint.X ? startPoint.X : endPoint.X;
            //double top = startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y;
            //StartPoint = new Point(startPoint.X - left, startPoint.Y - top);          
            //EndPoint = new Point(endPoint.X - left, endPoint.Y - top);
            //this.RenderTransform = new TranslateTransform(left, top);

            //double theta = Math.Atan2((double)endPoint.Y - startPoint.Y, (double)endPoint.X - startPoint.X);
            //theta *= 180 / Math.PI;
            //LineArrow.Angle = theta;
            this.RenderTransform = Transforms;
            StartPoint = startPoint;
            EndPoint = endPoint;
            CenterPoint = new Point(startPoint.X + (endPoint.X - startPoint.X) / 2, startPoint.Y + (endPoint.Y - startPoint.Y) / 2);

            LineArrow.RenderTransform = new TranslateTransform(CenterPoint.X - 5, CenterPoint.Y - 5);
            double theta = Math.Atan2((double)endPoint.Y - startPoint.Y, (double)endPoint.X - startPoint.X);
            theta *= 180 / Math.PI;
            LineArrow.Angle = theta;

        }
    }
}