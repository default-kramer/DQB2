﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace STGDAT
{
	internal class OnOffGridCanvas : Canvas
	{
		private readonly int Column = 64;
		private readonly int Size = 10;

		public OnOffGridCanvas()
		{
			//MouseDown += OnMouseDown;
		}

		public void ClearElement()
		{
			Children.Clear();
		}

		public void AddElement(bool flag)
		{
			var index = Children.Count;

			var rect = new Rectangle();
			rect.Width = Size;
			rect.Height = Size;
			rect.Stroke = Brushes.Black;
			rect.StrokeThickness = 0.5;
			rect.Fill = flag ? Brushes.Red : Brushes.Blue;
			Canvas.SetLeft(rect, index % Column * Size);
			Canvas.SetTop(rect, index / Column * Size);
			Children.Add(rect);
		}

		public void AddGuidElement()
		{
			// Cross Line Vector(0, 0)
			var line = new Line();
			line.X1 = 0;
			line.X2 = Column * Size;
			line.Y1 = Column * Size / 2;
			line.Y2 = line.Y1;
			line.Stroke = Brushes.Yellow;
			line.StrokeThickness = 1;
			Children.Add(line);

			line = new Line();
			line.X1 = Column * Size / 2;
			line.X2 = line.X1;
			line.Y1 = 0;
			line.Y2 = Column * Size;
			line.Stroke = Brushes.Yellow;
			line.StrokeThickness = 1;
			Children.Add(line);
		}

		public List<bool> GetFlags()
		{
			var result = new List<bool>();
			foreach (var element in Children)
			{
				var rect = element as Rectangle;
				if (rect == null) continue;
				result.Add(rect.Fill == Brushes.Red);
			}

			return result;
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			var pos = e.GetPosition(this);
			var index = ((int)pos.Y / Size) * Column + ((int)pos.X / Size);
			var rect = Children[index] as Rectangle;
			if (rect == null) return;
			rect.Fill = Brushes.Red;
		}
	}
}