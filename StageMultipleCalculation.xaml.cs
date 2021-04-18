using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageMultipleCalculation : Stage
    {
        public StageMultipleCalculation(BpToolsLib.StageMultipleCalculation stageMultipleCalculation) : base(stageMultipleCalculation)
        {
            InitializeComponent();
        }
    }
}
