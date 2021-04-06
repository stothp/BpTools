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

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<BpTools.Stage, Stage> stageDict;

        public MainWindow()
        {
            InitializeComponent();
            Canvas1.Children.Add(new ArrowedLine(new Point(100, 100), new Point(200, 200)));
            Canvas1.Children.Add(new ArrowedLine(new Point(100, 200), new Point(0, 0)));
        }

        private void PasteXml()
        {
            Canvas1.Children.Clear();
            BpTools.IBaseElement element;
            try
            {
                element = new BpTools.Interpreter.Interpreter(Clipboard.GetText()).GetElement();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                return;
            }
            if (!(element is BpTools.StageSet))
            {
                return;
            }

            stageDict = new Dictionary<BpTools.Stage, Stage>();
            TranslateTransform cTrans = new TranslateTransform();
            int? left = null, top = null, right = null, bottom = null;
            foreach (BpTools.Stage bpStage in (BpTools.StageSet)element)
            {
                //Line line = new Line(new Point(0, 0), new Point(bpStage.X, bpStage.Y));
                //line.Transforms.Children.Add(cTrans);
                //Canvas1.Children.Add(line);
                if (bpStage is BpTools.ITraversable)
                {
                    if (bpStage is BpTools.StageChoice)
                    {
                        if (((BpTools.StageChoice)bpStage).ChoiceEnd != null)
                        {
                            Line line = new Line()
                            {
                                X1 = bpStage.X,
                                Y1 = bpStage.Y,
                                X2 = ((BpTools.StageChoice)bpStage).ChoiceEnd.X,
                                Y2 = ((BpTools.StageChoice)bpStage).ChoiceEnd.Y,
                                Stroke = Brushes.Gray,
                                StrokeThickness = 1
                            };
                            line.RenderTransform = cTrans;
                            Canvas1.Children.Add(line);
                            Canvas.SetZIndex(line, 1);
                        }
                        foreach (BpTools.Choice bpChoice in ((BpTools.StageChoice)bpStage).Choices)
                        {
                            Choice choice = new Choice(bpChoice);
                            choice.Transforms.Children.Add(new TranslateTransform(bpStage.X, bpStage.Y));
                            choice.Transforms.Children.Add(cTrans);
                            Canvas1.Children.Add(choice);
                            Canvas.SetZIndex(choice, 2);
                            if (bpChoice.OnTrue != null)
                            {
                                ArrowedLine line = new ArrowedLine(new Point(bpStage.X, bpStage.Y + bpChoice.Distance), new Point(bpChoice.OnTrue.X, bpChoice.OnTrue.Y));
                                line.Transforms.Children.Add(cTrans);
                                Canvas1.Children.Add(line);
                                Canvas.SetZIndex(line, 1);
                            }
                        }
                    }
                    else
                    {
                        foreach (BpTools.Stage nextStage in ((BpTools.ITraversable)bpStage).NextStages)
                        {
                            ArrowedLine line = new ArrowedLine(new Point(bpStage.X, bpStage.Y), new Point(nextStage.X, nextStage.Y));
                            line.Transforms.Children.Add(cTrans);
                            Canvas1.Children.Add(line);
                            Canvas.SetZIndex(line, 1);
                        }
                    }
                }
            }
            foreach (BpTools.Stage bpStage in (BpTools.StageSet)element)
            {
                Stage stage = StageFactory.GetObject(bpStage);
                Canvas1.Children.Add(stage);
                stage.Transforms.Children.Add(cTrans);
                if (stage is StageBlock)
                {
                    Canvas.SetZIndex(stage, 0);
                }
                else
                {
                    Canvas.SetZIndex(stage, 2);
                }
                stageDict.Add(bpStage, stage);

                int stageLeft, stageTop, stageRight, stageBottom;
                if (!(bpStage is BpTools.StageBlock))
                {
                    stageLeft = bpStage.X - bpStage.Width / 2;
                    stageTop = bpStage.Y - bpStage.Height / 2;
                    stageRight = bpStage.X + bpStage.Width / 2;
                    stageBottom = bpStage.Y + bpStage.Height / 2;
                }
                else
                {
                    stageLeft = bpStage.X;
                    stageTop = bpStage.Y;
                    stageRight = bpStage.X + bpStage.Width;
                    stageBottom = bpStage.Y + bpStage.Height;
                }

                if (left == null || stageLeft < left)
                {
                    left = stageLeft;
                }
                if (top == null || stageTop < top)
                {
                    top = stageTop;
                }
                if (right == null || stageRight > right)
                {
                    right = stageRight;
                }
                if (bottom == null || stageBottom > bottom)
                {
                    bottom = stageBottom;
                }
            }

            cTrans.X = (double)left * -1 + 15;
            cTrans.Y = (double)top * -1 + 15;

            Canvas1.Width = (double)(right - left + 30);
            Canvas1.Height = (double)(bottom - top + 30);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasteXml();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                PasteXml();
            }
        }
    }
}
