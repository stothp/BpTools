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
using System.Windows.Shapes;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CollectionGeneratorDialog: Window
    {
        public string TabData { get; set; }
        
        public CollectionGeneratorDialog()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += CollectionGeneratorDialog_Loaded;
        }

        private void CollectionGeneratorDialog_Loaded(object sender, RoutedEventArgs e)
        {
            TableDataTextBox.SelectAll();
            TableDataTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
