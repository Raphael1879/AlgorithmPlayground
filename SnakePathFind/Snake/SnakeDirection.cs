using SnakePathFind.Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;




namespace SnakePathFind.Snake
{
    public enum SnakeDirection
    {
        Up = 0,
        Left = 1,
        Down = 2,
        Right = 3,
    }

    static class Constants
    {

        public static Dictionary<SnakeDirection, Point> SankeDirectionLookup = new Dictionary<SnakeDirection, Point>
        {
            { SnakeDirection.Up, new Point(0, -1) },
            { SnakeDirection.Down, new Point(0, 1) },
            { SnakeDirection.Left, new Point(-1, 0) },
            { SnakeDirection.Right, new Point(1, 0) },
        };
    }


}

