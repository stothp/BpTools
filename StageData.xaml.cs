using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StageData : Stage /*, INotifyPropertyChanged*/
    {
        public StageData(BpTools.StageData stageData) : base(stageData)
        {
            InitializeComponent();
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //// Create the OnPropertyChanged method to raise the event
        //// The calling member's name will be used as the parameter.
        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
