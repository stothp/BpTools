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
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<BpTools.Stage, Stage> stageDict;
        BpTools.StageSet stageSet;

        public MainWindow()
        {
            InitializeComponent();
            //Canvas1.Children.Add(new ArrowedLine(new Point(100, 100), new Point(200, 200)));
            //Canvas1.Children.Add(new ArrowedLine(new Point(100, 200), new Point(0, 0)));
        }

        private void RefreshXml()
        {
            XmlData.Text = new BpTools.Generator.Generator(stageSet).GetXml();
        }

        private void CopyXml()
        {
           Clipboard.SetText(new BpTools.Generator.Generator(stageSet).GetXml());
        }

        private void PasteXml()
        {            
            Canvas1.Children.Clear();
            stageSet = null;
            BpTools.IBaseElement element;
            try
            {
                //XDocument doc = XDocument.Parse(Clipboard.GetText());
                //XmlData.Text = doc.ToString();
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

            stageSet = (BpTools.StageSet)element;
            
            stageDict = new Dictionary<BpTools.Stage, Stage>();
            TranslateTransform cTrans = new TranslateTransform();
            int? left = null, top = null, right = null, bottom = null;

            foreach (BpTools.Stage bpStage in stageSet)
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

                if (bpStage is BpTools.StageData || bpStage is BpTools.StageCollection)
                {
                    stage.ContextMenu = new ContextMenu();
                    MenuItem menuItem = new MenuItem() { Header = "Refactor rename" };
                    menuItem.Click += (sender, e) =>
                    {
                        Stage_Rename(stage);
                    };
                    stage.ContextMenu.Items.Add(menuItem);
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
            RefreshXml();
        }

        private void Stage_Rename(Stage stage)
        {
            if (!(stage is StageData || stage is StageCollection))
            {
                return;
            }
            
            Stage sd = (Stage)stage;
            string originalName = sd.DisplayName;
            DataRenameWindow dialog = new DataRenameWindow()
            {
                DataName = originalName
            };

            if (dialog.ShowDialog() != true)
            {
                return;
            }
            sd.DisplayName = dialog.DataName;

            foreach (BpTools.Stage bpStage in stageSet)
            {
                if (bpStage is BpTools.IExpressionHolder)
                {
                    foreach (BpTools.MutableExpression expression in ((BpTools.IExpressionHolder)bpStage).Expressions)
                    {
                        if (stage is StageData)
                        {
                            expression.Value = expression.Value.Replace("[" + originalName + "]", "[" + dialog.DataName + "]");
                        } else if (stage is StageCollection)
                        {
                            expression.Value = expression.Value.Replace("[" + originalName + "]", "[" + dialog.DataName + "]");
                            expression.Value = expression.Value.Replace("[" + originalName + ".", "[" + dialog.DataName + ".");
                        }
                    }
                }
                if (bpStage is BpTools.IDataNameHolder)
                {
                    foreach (BpTools.MutableDataName dataName in ((BpTools.IDataNameHolder)bpStage).DataNames)
                    {
                        if (stage is StageData)
                        {
                            if (dataName.Value.Equals(originalName))
                            {
                                dataName.Value = dialog.DataName;
                            }
                        } 
                        else if (stage is StageCollection) 
                        {
                            if (dataName.Value.Equals(originalName))
                            {
                                dataName.Value = dialog.DataName;
                            } else if (dataName.Value.StartsWith(originalName + "."))
                            {
                                dataName.Value = Regex.Replace(dataName.Value, "^" + originalName + ".", dialog.DataName + ".");
                            }

                        }
                    }
                }
            }

            RefreshXml();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasteXml();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CopyXml();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                PasteXml();
            }
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                CopyXml();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CollectionGeneratorDialog dialog = new CollectionGeneratorDialog();
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            Canvas1.Children.Clear();
            stageSet = null;

            BpTools.StageCollection coll = new BpTools.StageCollection()
            {
                Name = "Collection1",
                Description = "Auto generated collection",
                HideFromOtherPages = true,
                ResetToInitialValueAtStart = true
            };

            bool first = true;
            string[] headers = null;
            foreach(string row in dialog.TabData.Split("\r\n".ToCharArray()))
            {
                if (first)
                {
                    headers = row.Split('\t');
                    foreach (string field in headers)
                    {
                        coll.Columns.Add(new BpTools.CollectionColumn()
                        {
                            Name = field,
                            Type = BpTools.DataType.Text
                        });
                    }
                    first = false;
                } 
                else
                {
                    if (row.Trim().Equals(""))
                    {
                        continue;
                    }
                    BpTools.CollectionRow cRow = new BpTools.CollectionRow();
                    string[] fields = row.Split('\t');
                    for  (int i = 0; i < headers.Length; i++)
                    {
                        if (fields.Length < i + 1)
                        {
                            break;
                        }
                        cRow.Add(new BpTools.CollectionField()
                        {
                            Name = headers[i],
                            Value = fields[i]
                        });
                    }
                    if (cRow.Count == headers.Length)
                    {
                        coll.Rows.Add(cRow);
                    }
                }
            }

            StageCollection stageColl = new StageCollection(coll);
            Canvas1.Children.Add(stageColl);
            stageSet = new BpTools.StageSet();
            stageSet.Add(coll);

            TranslateTransform cTrans = new TranslateTransform();
            stageColl.Transforms.Children.Add(cTrans);
            
            cTrans.X = (double)coll.Width / 2 + 15;
            cTrans.Y = (double)coll.Height / 2 + 15;

            Canvas1.Width = (double)(coll.Width + 30);
            Canvas1.Height = (double)(coll.Height + 30);

            RefreshXml();
        }
    }
}
