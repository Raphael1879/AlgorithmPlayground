using SnakePathFind.Snake.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePathFind.Snake.Controllers
{
    public class BogusController : ISnakeController
    {

        private Stack<Point>? _path;
        private List<Point>? _pathList;
        private SnakeGame? _game;
        private Point? _startPoint;

        private SnakeDirection[] _directions = { SnakeDirection.Up, SnakeDirection.Left, SnakeDirection.Down, SnakeDirection.Right };


        public Point OnTick(int tick, SnakeGame gameInstance)
        {
            var head = gameInstance.Snake[0];

            if (_pathList is null)
            {
                _startPoint = head;
                _path = new Stack<Point>();
                _game = gameInstance;

                if (GenerateNext(head))
                {
                    _pathList = _path.ToList();
                    _pathList.Add(head);
                }
            }

            var currentPathIndex = _pathList!.FindIndex(p => p.Equals(head));
            var nextIndex = currentPathIndex + 1;
            if(nextIndex == _pathList.Count)
            {
                nextIndex = 0;
            }
            var nextPathPoint = _pathList.ElementAt(nextIndex);

            return nextPathPoint.Sub(head);
        }

        public bool GenerateNext(Point currentPos)
        {
            foreach (var nextDirection in _directions)
            {
                var nextDirPoint = Constants.SankeDirectionLookup[nextDirection];
                var nextPoint = currentPos.Add(nextDirPoint);

                if(_game!.IsOutOfBounds(nextPoint)) continue;
                if (IsTraversed(nextPoint)) continue;
                if(_startPoint.Equals(nextPoint))
                {
                    if(CheckIfFullyTraversed())
                    {
                        //finished
                        return true;
                    }
                    continue;
                }
                _path!.Push(nextPoint);
                var nextResult = GenerateNext(nextPoint);

                if(!nextResult)
                {
                    _path.Pop();
                    continue;
                }
                return nextResult;

            }

            return false;
        }


        private bool IsTraversed(Point pos)
        {
            return _path!.Contains(pos);
        }

        private bool CheckIfFullyTraversed()
        {
            var totalCellCount = (_game!.Width * _game!.Height) - 1;
            return totalCellCount == _path!.Count;
        }
    }
}
