using System.Windows;
using System.Windows.Media;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageException : Stage
    {
        public StageException(BpToolsLib.StageException stageException) : base(stageException)
        {
            InitializeComponent();
        }
    }
}
