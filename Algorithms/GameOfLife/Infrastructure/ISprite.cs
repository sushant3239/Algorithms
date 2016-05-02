using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace GameOfLife.Infrastructure
{
    public interface ISprite
    {
        void Update(Point point);
        void Draw(Canvas canvas);
    }
}
