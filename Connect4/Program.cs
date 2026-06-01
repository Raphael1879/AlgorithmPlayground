using Connect4.Models;
using Sorts;

var p1 = new PlayerController() { Color = ConsoleColor.Red, PieceId = 1 };
var p2 = new PlayerController() { Color = ConsoleColor.Blue, PieceId = 2 };
var p3 = new PlayerController() { Color = ConsoleColor.Magenta, PieceId = 3 };



var game = new Connect4Game() { Height = 6, Width = 7, Players = [p1,p2,p3] };

game.StartGame();