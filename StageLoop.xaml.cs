using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageLoop : Stage
    {
        public StageLoop(BpTools.StageLoop stageLoop) : base(stageLoop)
        {
            InitializeComponent();
        }
    }
}
