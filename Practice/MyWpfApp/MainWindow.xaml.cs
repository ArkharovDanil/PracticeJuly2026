using MyWpfApp.Bridge;
using MyWpfApp.Classes;
using MyWpfApp.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfApp;

public partial class MainWindow : Window
{
    private Random _random = new Random();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        GenerateGraphics();
    }

    private void GenerateGraphics()
    {
 

        // Для левой части 
        int x1 = _random.Next(20, 350);
        int y1 = _random.Next(20, 400);
        int x2 = _random.Next(20, 350);
        int y2 = _random.Next(20, 400);

        int bx1 = _random.Next(20, 350);
        int by1 = _random.Next(20, 400);
        int bx2 = _random.Next(20, 350);
        int by2 = _random.Next(20, 400);
        int bx3 = _random.Next(20, 350);
        int by3 = _random.Next(20, 400);
        int bx4 = _random.Next(20, 350);
        int by4 = _random.Next(20, 400);

        // Для правой части
        int x1r = _random.Next(450, 750);
        int y1r = _random.Next(20, 400);
        int x2r = _random.Next(450, 750);
        int y2r = _random.Next(20, 400);

        int bx1r = _random.Next(450, 750);
        int by1r = _random.Next(20, 400);
        int bx2r = _random.Next(450, 750);
        int by2r = _random.Next(20, 400);
        int bx3r = _random.Next(450, 750);
        int by3r = _random.Next(20, 400);
        int bx4r = _random.Next(450, 750);
        int by4r = _random.Next(20, 400);

        //левая часть
        Classes.Point a1 = new Classes.Point(x1, y1);
        Classes.Point b1 = new Classes.Point(x2, y2);
        Classes.Line line = new Classes.Line(a1, b1);


        Classes.Point c1 = new Classes.Point(bx1, by1);
        Classes.Point d1 = new Classes.Point(bx2, by2);
        Classes.Point e1 = new Classes.Point(bx3, by3);
        Classes.Point f1 = new Classes.Point(bx4, by4);
        Bezier bez = new Bezier(c1, d1, e1, f1);


        Implement greenScheme = new LineGreen();

        VisualLine visualLine = new VisualLine(line, greenScheme);
        VisualBezier visualBezier = new VisualBezier(bez, greenScheme);

        visualLine.SegmentsCount = 15;
        visualBezier.SegmentsCount = 50;

        //правая часть
      
        Classes.Point a2 = new Classes.Point(x1r, y1r);
        Classes.Point b2 = new Classes.Point(x2r, y2r);
        Classes.Line line2 = new Classes.Line(a2, b2);

   
        Classes.Point c2 = new Classes.Point(bx1r, by1r);
        Classes.Point d2 = new Classes.Point(bx2r, by2r);
        Classes.Point e2 = new Classes.Point(bx3r, by3r);
        Classes.Point f2 = new Classes.Point(bx4r, by4r);
        Bezier bez2 = new Bezier(c2, d2, e2, f2);

        Implement blackScheme = new BezierBlack();

        VisualLine visualLine2 = new VisualLine(line2, blackScheme);
        VisualBezier visualBezier2 = new VisualBezier(bez2, blackScheme);

        visualLine2.SegmentsCount = 15;
        visualBezier2.SegmentsCount = 50;

        //левая часть
        DrawingVisual leftVisual = new DrawingVisual();
        using (DrawingContext dc = leftVisual.RenderOpen())
        {
            visualLine.Draw(dc);
            visualBezier.Draw(dc);
        }

        //правая часть
        DrawingVisual rightVisual = new DrawingVisual();
        using (DrawingContext dc = rightVisual.RenderOpen())
        {
            visualLine2.Draw(dc);
            visualBezier2.Draw(dc);
        }
        
       //канвас
        LeftCanvas.Children.Add(new Image
        {
            Source = new DrawingImage(leftVisual.Drawing),
            Width = 400,
            Height = 450,
            Stretch = Stretch.None
        });

        RightCanvas.Children.Add(new Image
        {
            Source = new DrawingImage(rightVisual.Drawing),
            Width = 400,
            Height = 450,
            Stretch = Stretch.None
        });
    }
}