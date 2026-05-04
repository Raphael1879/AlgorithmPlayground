using System.Drawing;

namespace SnakePathFind.Snake.Controllers;

public class SvenController : ISnakeController
{
    private Point NextDirection = new Point(0, -1);

    public Point OnTick(int Tick, SnakeGame gameInstance)
    {

        if (gameInstance.Food.Count > 0)
        {
            SimplePathfind(gameInstance.Snake[0], gameInstance.Food[0]);
        }
        return NextDirection;
    }


    private void SimplePathfind(Point start, Point target)
    {
        Point Diff = target.Sub(start);

        if (Diff.X > 0)
        {
            NextDirection = new Point(1, 0);
            return;
        }
        if (Diff.X < 0)
        {
            NextDirection = new Point(-1, 0);
            return;
        }
        if (Diff.Y > 0)
        {
            NextDirection = new Point(0, 1);
            return;
        }
        if (Diff.Y < 0)
        {
            NextDirection = new Point(0, -1);
            return;
        }
    }
}
