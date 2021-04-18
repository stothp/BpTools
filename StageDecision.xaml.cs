using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageDecision : Stage
    {
        public StageDecision(BpToolsLib.StageDecision stageDecision) : base(stageDecision)
        {
            InitializeComponent();
        }
    }
}
