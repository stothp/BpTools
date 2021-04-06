using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for Choice.xaml
    /// </summary>
    public partial class Choice : UserControl
    {
        public TransformGroup Transforms { get; } = new TransformGroup();

        public Choice(BpTools.Choice choice)
        {
            InitializeComponent();
            Width = 10;
            Height = 10;
            this.RenderTransform = Transforms;
            Transforms.Children.Add(new TranslateTransform(-5, -5 + choice.Distance));
        }
    }
}
