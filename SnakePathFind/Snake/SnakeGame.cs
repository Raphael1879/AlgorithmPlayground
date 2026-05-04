using SnakePathFind.Snake.Controllers;
using SnakePathFind.Snake.Models;
using System.Drawing;
namespace SnakePathFind.Snake
{
    public class SnakeGame
    {
        public required int Width { get; set; }
        public required int Height { get; set; }
        public required int TickRate { get; set; } = 16;
        public required ISnakeController Controller { get; set; }

        public Point CurrentDirection = Constants.SankeDirectionLookup[SnakeDirection.Right];

        private int Tick = 0;

        public List<Point> Snake = new List<Point>();
        public List<Point> Food = new List<Point>();

        private bool _alive = true;
        private int _remainingFramesToTick;


        public void StartGame()
        {
            ResetGameValues();

            while (_alive) {
                _remainingFramesToTick--;
                if(_remainingFramesToTick == 0)
                {
                    Tick++;
                    _remainingFramesToTick = TickRate;
                    CurrentDirection = Controller.OnTick(Tick, this);
                    Update();
                    Draw();
                }
                Thread.Sleep(16);
            }
        }

        private void Update()
        {
            var nextDirection = CurrentDirection;

            var head = Snake.FirstOrDefault();
            var newHead = head.Add(nextDirection);

           
            if (IsOutOfBounds(newHead) || Snake.Contains(newHead))
            {
                _alive = false;
                return;
            }

            Snake.Insert(0, newHead);

            if(Food.Contains(newHead))
            {
               Food = Food.Select(food => food.Equals(newHead) ? GetFoodPosition() : food).ToList();
            } else
            {
               Snake.RemoveAt(Snake.Count - 1);
            }
        }


        private void Draw()
        {
            Console.SetCursorPosition(0, 0);

            // Top border
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('█', Width * 2 + 4));

            for (int y = 0; y < Height; y++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("██"); // left border

                for (int x = 0; x < Width; x++)
                {
                    var current = new Point(x, y);

                    if (Snake.Contains(current))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (current == Snake.First())
                            Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.Write("██");
                    }
                    else if (Food.Contains(current))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("██");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("██"); // right border
            }

            // Bottom border
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('█', Width * 2 + 4));

            Console.ResetColor();
        }

        private Point GetFoodPosition()
        {
            var randomPoint = new Point(Random.Shared.Next(0, Width - 1), Random.Shared.Next(0, Height - 1));

          
            while (Snake.Contains(randomPoint) || Food.Contains(randomPoint))
            {
                randomPoint = new Point(Random.Shared.Next(0, Width - 1), Random.Shared.Next(0, Height - 1));
            }

            return randomPoint;
        }

        private bool IsOpposite(Point a, Point b)
        {
            return a.X == -b.X && a.Y == -b.Y;
        }

        private void ResetGameValues()
        {
            Console.CursorVisible = false;
            _alive = true;
            _remainingFramesToTick = TickRate;
            Food.Clear();
            Snake.Clear();
            Snake.Add(new Point { X = 5, Y = 5 });
            Food.Add(GetFoodPosition());

        }

        private bool IsOutOfBounds(Point point)
        {
            return point.X > Width - 1 || point.X < 0 || point.Y < 0 || point.Y > Height - 1;
        }
    }
}
