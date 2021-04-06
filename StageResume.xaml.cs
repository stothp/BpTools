using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageResume : Stage
    {
        public StageResume(BpTools.StageResume stageResume) : base(stageResume)
        {
            InitializeComponent();
        }
    }
}
