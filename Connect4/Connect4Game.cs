using Sorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public class Connect4Game
    {
        public required IConnect4Controller[] Players { get; set; }
        public required int Width { get; set; }
        public required int Height { get; set; }


        public int[,] _board = new int[0, 0];
        private IConnect4Controller? _winner = null;

        public void StartGame()
        {
            _board = new int[Width, Height];

            // create board


            //for (int x = 0; x < Width; x++) {
            //    for (int y = 0; y < Height; y++)
            //    {

            //    }
            //}





            while (_winner is null)
            {
                for (int i = 0; i < Players.Length; i++)
                {
                    var player = Players[i];

                    var selectedRow = player.OnTurn(this);

                    Drop(selectedRow, i+1);

                    
                }


            }



        }

        public void Drop(int x, int val)
        {
            var nextFreeY = Height -1;

            while (_board[x,nextFreeY] != 0) { 
                nextFreeY--;
            }

            _board[x, nextFreeY] = val;
        }

        public bool CanDrop(int x) {

            //if(x <= 0 || Width)
            return false;
        }




        public void Draw()
        {
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.White;


            Console.Write("  ");
            for(int y = 0; y < Width; y++)
            {
                Console.Write(y.ToString().PadLeft(2));
            }

            Console.WriteLine();

            for (int y = 0; y < Width + 2; y++)
            {
                Console.Write("██");
            }

            Console.WriteLine();

            for (int y = 0; y < Height; y++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("██");
                for (int x = 0; x < Width; x++)
                {
                    var fieldOwner = Players.FirstOrDefault(p => p.PieceId == _board[x, y]);
                    if (fieldOwner != null)
                    {
                        Console.ForegroundColor = fieldOwner.Color;
                        Console.Write("██");
                    } else
                    {
                        Console.Write("  ");

                    }

                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("██");

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            for (int y = 0; y < Width + 2; y++)
            {
                Console.Write("██");
            }
            Console.WriteLine();

        }
    }
}
