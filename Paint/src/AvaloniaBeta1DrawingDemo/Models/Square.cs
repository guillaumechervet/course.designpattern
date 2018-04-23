using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBeta1DrawingDemo.Models
{
    public class Square : Shape
    {
        public int Begin {get;set;}
        public int End {get;set;}

        public Rectangle square;
        public Square(Canvas drawingCanvas, Color color) : base(drawingCanvas, color)
        {
            square = new Rectangle();
            var colorBrush = new SolidColorBrush();
            colorBrush.Color = this.color;
            square.Fill = colorBrush;

            //square.   
            square.Width = 400;
            square.Height = 400;


            square.Margin = new Thickness(0, 50, 0, 0);
            //var container = new StackPanel();
            drawingCanvas.Children.Add(square);
            
        }

        public void Move(Point point)
        {
            Canvas.SetTop(square, point.X);
            Canvas.SetLeft(square, point.Y);
        }

        public override void Draw()
        {
            //this.drawingCanvas.Content = container;
            //this.drawingCanvas.
        }

    }
}
