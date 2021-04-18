using BpToolsLib;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BPT = BpToolsLib;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Stage : UserControl, INotifyPropertyChanged
    {
        public BPT.Stage BpStage { get; }
        public string DisplayName { 
            get 
            { 
                return BpStage.Name; 
            }
            set
            {
                BpStage.Name = value;
                OnPropertyChanged("DisplayName");
            }
        }
        public string Description { get { return BpStage.Description; } }
        public string BpFontFamily { get { return BpStage.Font.Family; } }
        public int BpFontSize { get { return BpStage.Font.Size; } }
        public Brush BpFontColor { get { return (SolidColorBrush)new BrushConverter().ConvertFrom("#" + BpStage.Font.Color); } }
        public string BpFontStyle { get { return BpStage.Font.Style; } }
        public TransformGroup Transforms { get; } = new TransformGroup();
        public TranslateTransform StageTranslate { get; } = new TranslateTransform();

        public Stage(BPT.Stage stage)
        {
            BpStage = stage;
            this.Height = BpStage.Height;
            this.Width = BpStage.Width;
            StageTranslate.X = BpStage.X - BpStage.Width / 2;
            StageTranslate.Y = BpStage.Y - BpStage.Height / 2;
            Transforms.Children.Add(StageTranslate);
            this.RenderTransform = Transforms;

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
