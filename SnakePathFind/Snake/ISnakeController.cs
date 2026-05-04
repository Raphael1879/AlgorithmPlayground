using SnakePathFind.Snake;
using System.Drawing;

namespace SnakePathFind; 

public interface ISnakeController
{
    public Point OnTick(int tick, SnakeGame gameInstance);
}