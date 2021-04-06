using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for Choice.xaml
    /// </summary>
    public partial class LineArrow : UserControl
    {
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(string), typeof(UserControl));

        public double Angle
        {
            get
            {
                return rotateTransform.Angle;
            }
            set
            {
                rotateTransform.Angle = value;
            }
        }

        
        private RotateTransform rotateTransform = new RotateTransform();

        public LineArrow()
        {

            InitializeComponent();
            this.Width = 10;
            this.Height = 10;
            ArrowPath.RenderTransform = rotateTransform;
        }
    }
}
