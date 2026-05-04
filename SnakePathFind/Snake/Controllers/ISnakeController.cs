using SnakePathFind.Snake;
using System.Drawing;

namespace SnakePathFind.Snake.Controllers; 

public interface ISnakeController
{
    public Point OnTick(int tick, SnakeGame gameInstance);
}