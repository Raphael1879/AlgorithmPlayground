using SnakePathFind;
using SnakePathFind.Snake;


var controller = new PlayerController();

var game = new SnakeGame() { Width = 10, Height = 10, TickRate = 16, Controller = controller };

while (true)
{
    Console.Clear();
    game.StartGame();
    Console.WriteLine("Dead");
    Console.ReadKey();
}