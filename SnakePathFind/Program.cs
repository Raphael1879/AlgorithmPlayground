using SnakePathFind.Snake.Controllers;
using SnakePathFind.Snake;


var controller = new OptimizedSolver();

var game = new SnakeGame() { Width = 8, Height = 8, TickRate = 1, Controller = controller };

while (true)
{
    Console.Clear();
    game.StartGame();
    Console.WriteLine("Dead");
    Console.ReadKey();
}