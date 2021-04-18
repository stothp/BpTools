using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageAlert : Stage
    {
        public StageAlert(BpToolsLib.StageAlert stageAlert) : base(stageAlert)
        {
            InitializeComponent();
        }
    }
}
