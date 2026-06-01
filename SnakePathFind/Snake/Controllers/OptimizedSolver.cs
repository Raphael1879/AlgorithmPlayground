using SnakePathFind.Snake.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePathFind.Snake.Controllers
{
    public class SolverInfo {
        public int steps;
        public int maxDepth;

        public void IncreaseStep() {
            steps += 1;
            if (steps % 100000 == 0) {
                Console.WriteLine($"{steps} steps checked");
            }
        }
    }

    public class OptimizedSolver : ISnakeController
    {
        private Point? _target;
        private List<Point>? _path;
        private SnakeGame? _game;
        private bool _looked = false;

        private SnakeDirection[] _directions = { SnakeDirection.Up, SnakeDirection.Left, SnakeDirection.Down, SnakeDirection.Right };

        public Point OnTick(int tick, SnakeGame gameInstance)
        {
            Point start = gameInstance.Snake[0];
            _game = gameInstance;
            _target = gameInstance.Snake[0];

            if (_path is null && _looked == false)
            {
                _looked = true;
                Console.WriteLine($"Optimized Solver used for {_game.Width} x {_game.Height} Board");
                Stack<Point> PathStack = new Stack<Point>();
                Dictionary<Point, bool> Discovered = new Dictionary<Point, bool>();
                SolverInfo Info = new SolverInfo();
                
                if (GenerateNext(start, PathStack, Discovered, Info))
                {
                    _path = PathStack.ToList();
                    _path.Add(start);
                } else 
                {
                    Console.WriteLine("No Path found");
                }
            }

            if (_path is not null) {
                var currentPathIndex = _path!.FindIndex(p => p.Equals(start));
                var nextIndex = currentPathIndex + 1;
                if(nextIndex == _path.Count)
                {
                    nextIndex = 0;
                }
                var nextPathPoint = _path.ElementAt(nextIndex);
                return nextPathPoint.Sub(start);
            } 
            else 
            {
                return Constants.SankeDirectionLookup[_directions[0]];
            }
        }

        public bool GenerateNext(Point currentPos, Stack<Point> currentPath, Dictionary<Point, bool> currentDiscovery, SolverInfo info)
        {
            foreach (var nextDirection in _directions)
            {
                Point nextPoint = currentPos.Add(Constants.SankeDirectionLookup[nextDirection]);

                // Logging
                info.IncreaseStep();

                if(_game!.IsOutOfBounds(nextPoint)) continue;
                if (IsTraversed(currentDiscovery, nextPoint)) continue;
                if(_target.Equals(nextPoint))
                {
                    if(CheckIfFullyTraversed(currentPath))
                    {
                        //finished
                        return true;
                    }
                    continue;
                }
                currentPath.Push(nextPoint);
                currentDiscovery.Add(nextPoint, true);
                var nextResult = GenerateNext(nextPoint, currentPath, currentDiscovery, info);

                if(!nextResult)
                {
                    currentPath.Pop();
                    currentDiscovery.Remove(nextPoint);
                    continue;
                }
                return nextResult;
            }
            return false;
        }


        private bool IsTraversed(Dictionary<Point, bool> currentDiscovery, Point pos)
        {
            return currentDiscovery.ContainsKey(pos);
        }

        private bool CheckIfFullyTraversed(Stack<Point> currentPath)
        {
            var totalCellCount = (_game!.Width * _game!.Height) - 1;
            return totalCellCount == currentPath!.Count;
        }
    }
}
