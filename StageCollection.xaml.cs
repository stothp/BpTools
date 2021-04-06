using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageCollection : Stage
    {
        public StageCollection(BpTools.Stage stageCollection) : base(stageCollection)
        {
            InitializeComponent();
        }
    }
}
