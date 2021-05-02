using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for Choice.xaml
    /// </summary>
    public partial class LineWithArrow : UserControl
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public Point CenterPoint { get; }

        public TransformGroup Transforms { get; } = new TransformGroup();

        public LineWithArrow(Point startPoint, Point endPoint)
        {
            InitializeComponent();
            DataContext = this;

            this.RenderTransform = Transforms;
            StartPoint = startPoint;
            EndPoint = endPoint;
    CenterPoint = new Point(startPoint.X + (endPoint.X - startPoint.X) / 2, startPoint.Y + (endPoint.Y - startPoint.Y) / 2);

    double angle = Math.Atan2((double)endPoint.Y - startPoint.Y, (double)endPoint.X - startPoint.X) * 180 / Math.PI;

    TransformGroup transformGroup = new TransformGroup();
    transformGroup.Children.Add(new RotateTransform(angle));
    transformGroup.Children.Add(new TranslateTransform(CenterPoint.X - 5, CenterPoint.Y - 5));
    Arrow.RenderTransform = transformGroup;
        }
    }
}
