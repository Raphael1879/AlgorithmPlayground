using System.Drawing;


namespace SnakePathFind.Snake
{
    public class PlayerController : ISnakeController
    {
        private LastKeyPressedListener? _lastKeyPressedListener;

        public PlayerController() {
            _lastKeyPressedListener = new LastKeyPressedListener();
            _lastKeyPressedListener.StartListening();
        }

        public Point OnTick(int tick, SnakeGame gameInstance)
        {
            var lastKeyPressed = _lastKeyPressedListener?.LastPressedKey;

            var newDirection = lastKeyPressed switch
            {
                ConsoleKey.UpArrow => Constants.SankeDirectionLookup[SnakeDirection.Up],
                ConsoleKey.DownArrow => Constants.SankeDirectionLookup[SnakeDirection.Down],
                ConsoleKey.LeftArrow => Constants.SankeDirectionLookup[SnakeDirection.Left],
                ConsoleKey.RightArrow => Constants.SankeDirectionLookup[SnakeDirection.Right],
                _ => Constants.SankeDirectionLookup[SnakeDirection.Right]
            };
            return newDirection;
        }
    }
}
