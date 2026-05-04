using SnakePathFind.Snake.Controllers;
using SnakePathFind.Snake;


var controller = new SvenController();

var game = new SnakeGame() { Width = 10, Height = 10, TickRate = 16, Controller = controller };

while (true)
{
    Console.Clear();
    game.StartGame();
    Console.WriteLine("Dead");
    Console.ReadKey();
}