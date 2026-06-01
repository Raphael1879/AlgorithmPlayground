using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Models
{
    public interface IConnect4Controller
    {
        int PieceId { get; set; }
        ConsoleColor Color { get; set; }
        public int OnTurn(Connect4Game gameRef);
    }
}
