using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageChoice : Stage
    {
        public StageChoice(BpToolsLib.StageChoice stageChoice) : base(stageChoice)
        {
            InitializeComponent();
        }
    }
}
