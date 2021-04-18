using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageCalculation : Stage
    {
        public StageCalculation(BpToolsLib.StageCalculation stageCalculation) : base(stageCalculation)
        {
            InitializeComponent();
        }
    }
}
