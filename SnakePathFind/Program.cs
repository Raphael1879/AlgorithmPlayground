using SnakePathFind.Snake.Controllers;
using SnakePathFind.Snake;


var controller = new OptimizedSolver();

var game = new SnakeGame() { Width = 15, Height = 10, TickRate = 1, Controller = controller };

while (true)
{
    Console.Clear();
    game.StartGame();
    Console.WriteLine("Dead");
    Console.ReadKey();
}