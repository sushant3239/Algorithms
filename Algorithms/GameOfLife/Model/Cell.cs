using System;
using GameOfLife.Infrastructure;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace GameOfLife.Model
{
    public class Cell : ISprite
    {
        public Point Position { get; private set; }
        public Rect Bounds { get; private set; }

        public bool IsAlive { get; set; }
        public int CelSize { get { return Game.CELL_SIZE; } }

        public Cell(Point position)
        {
            Position = position;
            Bounds = new Rect(position.X, position.Y, CelSize, CelSize);
            IsAlive = false;
        }

        public void Update(Point point)
        {
            if (IsTouched(point)) IsAlive = !IsAlive;
        }

        private bool IsTouched(Point point)
        {
            return (point.X > Position.X && point.X < Position.X + CelSize) &&
                    (point.Y > Position.Y && point.Y < Position.Y + CelSize);
        }

        public void Draw(Canvas canvas)
        {
            //if (IsAlive) canvas.Children.Add
        }

    }
}
