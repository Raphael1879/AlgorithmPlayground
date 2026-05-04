//using SnakePathFind.Snake;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using SnakePathFind.ControllerBase

//namespace SnakePathFind; 

//public struct Path {
//    List<Point> points;
//}

//public class SvenNextGenAI : ISnakeController
//{
//    private List<Point> ?Path;
//    private Point NextDirection = new Point(0, -1);

//    public Point OnTick(int Tick, SnakeGame gameInstance) {

//        if (gameInstance.Food.Count > 0) {
//            SimplePathfind(gameInstance.Snake, gameInstance.Food[0]);
//        }
//        return NextDirection;
//    }


//    private void SimplePathfind(Point snake, Point Target) {

//        Point Start = snake[0];
//        Point currentPos = snake;
//        Point Diff = Target.  Start;

//        if (Diff.X > 0) {
//            NextDirection = new Point(1, 0);
//            return;
//        }
//        if (Diff.X < 0) {
//            NextDirection = new Point(-1, 0);
//            return;
//        }
//        if (Diff.Y > 0) {
//            NextDirection = new Point(0, 1);
//            return;
//        }
//        if (Diff.Y < 0) {
//            NextDirection = new Point(0, -1);
//            return;
//        }
//    }
//}
