using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageRecover : Stage
    {
        public StageRecover(BpToolsLib.StageRecover stageRecover) : base(stageRecover)
        {
            InitializeComponent();
        }
    }
}
