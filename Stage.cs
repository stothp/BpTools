using BpTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using BPT = BpTools;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Stage : UserControl
    {
        protected BPT.Stage bpStage;
        public string DisplayName { get { return bpStage.Name; } }
        public string Description { get { return bpStage.Description; } }
        public string BpFontFamily { get { return bpStage.Font.Family; } }
        public int BpFontSize { get { return bpStage.Font.Size; } }
        public Brush BpFontColor { get { return (SolidColorBrush)new BrushConverter().ConvertFrom("#" + bpStage.Font.Color); } }
        public string BpFontStyle { get { return bpStage.Font.Style; } }
        public TransformGroup Transforms { get; } = new TransformGroup();
        public TranslateTransform StageTranslate { get; } = new TranslateTransform();

        public Stage(BPT.Stage stage)
        {
            bpStage = stage;
            this.Height = bpStage.Height;
            this.Width = bpStage.Width;
            StageTranslate.X = bpStage.X - bpStage.Width / 2;
            StageTranslate.Y = bpStage.Y - bpStage.Height / 2;
            Transforms.Children.Add(StageTranslate);
            this.RenderTransform = Transforms;

            this.DataContext = this;
        }

    }
}
