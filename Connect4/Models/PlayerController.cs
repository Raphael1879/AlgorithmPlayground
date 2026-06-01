using Sorts;
using Sorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class PlayerController : IConnect4Controller
    {
        public ConsoleColor Color { get; set; }
        public int PieceId { get; set; }

        public int OnTurn(Connect4Game gameRef)
        {
            gameRef.Draw();
            return int.Parse(Console.ReadLine());

        }
    }
}
