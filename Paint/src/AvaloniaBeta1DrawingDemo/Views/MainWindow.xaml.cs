﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using AvaloniaBeta1DrawingDemo.Models;
using Shape = Avalonia.Controls.Shapes.Shape;

namespace AvaloniaBeta1DrawingDemo.Views
{
    public class MainWindow : Window
    {
        private Button btnCreateCircle;
        private Button btnCreateSquare;
        private Button btnCreateTriangle;
        private Canvas drawingCanvas;

        private IList<Shape> shapes = new List<Shape>();

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.btnCreateCircle = this.Find<Button>("btnCreateCircle");
            this.btnCreateCircle.Click += BtnCreateCircle_Click;
            this.btnCreateSquare = this.Find<Button>("btnCreateSquare");
            this.btnCreateSquare.Click += BtnCreateSquare_Click;     
            this.btnCreateTriangle = this.Find<Button>("btnCreateTriangle");
            this.btnCreateTriangle.Click += BtnCreateTriangle_Click;
            this.drawingCanvas = this.Find<Canvas>("drawingCanvas");
            this.drawingCanvas.PointerMoved += DrawingCanvas_PointerMoved;
            this.drawingCanvas.PointerPressed += DrawingCanvas_PointerPressed;
            this.drawingCanvas.PointerReleased += DrawingCanvas_PointerRelease;
        }

        private void DrawingCanvas_PointerRelease(object sender, Avalonia.Input.PointerEventArgs e)
        {
            Console.WriteLine("e.X" + e.GetPosition(this.drawingCanvas).X);
            Console.WriteLine("e.Y" + e.GetPosition(this.drawingCanvas).Y);
        }

        private void DrawingCanvas_PointerPressed(object sender, Avalonia.Input.PointerEventArgs e)
        {
            var square = new Square(drawingCanvas, Colors.Blue);
            square.Move(e.GetPosition(this.drawingCanvas));
            //Console.WriteLine("e.X" + e.GetPosition(this.drawingCanvas).X);
            //Console.WriteLine("e.Y" + e.GetPosition(this.drawingCanvas).Y);
        }

        private void DrawingCanvas_PointerMoved(object sender, Avalonia.Input.PointerEventArgs e)
        {
            var shape = (Square) drawingCanvas.Children[0];
            shape.Move(e.GetPosition(this.drawingCanvas));

            //Console.WriteLine("e" + e.GetPosition(this.drawingCanvas).X);
        }

        private void DrawShape(Models.Shape shape)
        {
            shape.Draw();
        }

        private void BtnCreateTriangle_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
           // var triangle = new Models.Triangle(this.drawingCanvas, Colors.Blue);
           // this.DrawShape(triangle);
        }

        private void BtnCreateSquare_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var square = new Models.Square(drawingCanvas, Colors.Green);
            this.DrawShape(square);
        }

        private void BtnCreateCircle_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
         //   var circle = new Models.Circle(this.drawingCanvas, Colors.Red);
            //this.DrawShape(circle);
        }
    }
}
