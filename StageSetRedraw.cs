using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsWPFClientTest
{
    static class StageSetRedraw
    {
        static Rect? GetStageSetBoundary(BpToolsLib.StageSet stageSet)
        {
            int? left = null, top = null, right = null, bottom = null;

            foreach (BpToolsLib.Stage bpStage in stageSet)
            {
                int stageLeft, stageTop, stageRight, stageBottom;

                if (!(bpStage is BpToolsLib.StageBlock))
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

            if (left == null || right == null || top == null || bottom == null)
            {
                return null;
            }
            else
            {
                return new Rect()
                {
                    X = (double)left,
                    Y = (double)top,
                    Width = (double)(right - left),
                    Height = (double)(bottom - top)
                };
            }
        }

        static void DrawChoiceArrows(MainCanvas canvas, BpToolsLib.StageChoice bpStageChoice, TranslateTransform cTrans)
        {
            if (bpStageChoice.ChoiceEnd != null)
            {
                Line line = new Line()
                {
                    X1 = bpStageChoice.X,
                    Y1 = bpStageChoice.Y,
                    X2 = (bpStageChoice).ChoiceEnd.X,
                    Y2 = (bpStageChoice).ChoiceEnd.Y,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 1
                };
                line.RenderTransform = cTrans;
                canvas.Children.Add(line);
                Canvas.SetZIndex(line, 1);
            }
            foreach (BpToolsLib.Choice bpChoice in bpStageChoice.Choices)
            {
                Choice choice = new Choice(bpChoice);
                choice.Transforms.Children.Add(new TranslateTransform(bpStageChoice.X, bpStageChoice.Y));
                choice.Transforms.Children.Add(cTrans);
                canvas.Children.Add(choice);
                Canvas.SetZIndex(choice, 2);
                if (bpChoice.OnTrue != null)
                {
                    LineWithArrow line = new LineWithArrow(new Point(bpStageChoice.X, bpStageChoice.Y + bpChoice.Distance), new Point(bpChoice.OnTrue.X, bpChoice.OnTrue.Y));
                    line.Transforms.Children.Add(cTrans);
                    canvas.Children.Add(line);
                    Canvas.SetZIndex(line, 1);
                }
            }
        }

        public static void DrawRegularLines(MainCanvas canvas, BpToolsLib.Stage bpStage, TranslateTransform cTrans)
        {
            foreach (BpToolsLib.Stage nextStage in ((BpToolsLib.ITraversable)bpStage).NextStages)
            {
                LineWithArrow line = new LineWithArrow(new Point(bpStage.X, bpStage.Y), new Point(nextStage.X, nextStage.Y));
                line.Transforms.Children.Add(cTrans);
                canvas.Children.Add(line);
                Canvas.SetZIndex(line, 1);
            }
        }

        public static void Draw(MainCanvas canvas, BpToolsLib.StageSet stageSet)
        {
            canvas.Children.Clear();

            TranslateTransform cTrans = new TranslateTransform();

            foreach (BpToolsLib.Stage bpStage in stageSet)
            {
                if (bpStage is BpToolsLib.ITraversable)
                {
                    if (bpStage is BpToolsLib.StageChoice)
                    {
                        DrawChoiceArrows(canvas, (BpToolsLib.StageChoice)bpStage, cTrans);
                    }
                    else
                    {
                        DrawRegularLines(canvas, bpStage, cTrans);
                    }
                }
            }

            foreach (BpToolsLib.Stage bpStage in stageSet)
            {
                Stage stage = StageFactory.GetObject(bpStage);
                canvas.Children.Add(stage);
                stage.Transforms.Children.Add(cTrans);
                if (stage is StageBlock)
                {
                    Canvas.SetZIndex(stage, 0);
                }
                else
                {
                    Canvas.SetZIndex(stage, 2);
                }
            }

            Rect? stageBoundary = GetStageSetBoundary(stageSet);

            if (!stageBoundary.HasValue)
            {
                return;
            }

            cTrans.X = stageBoundary.Value.X * -1 + 15;
            cTrans.Y = stageBoundary.Value.Y * -1 + 15;
            canvas.Width = (double)(stageBoundary.Value.Width + 30);
            canvas.Height = (double)(stageBoundary.Value.Height + 30);
        }
    }
}
