using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Domain
{
    public static class Extensions
    {
        public static SinglyLinkedList<Point> BFS(Field field, Point start, Point end)
        {
            var queue = new Queue<SinglyLinkedList<Point>>();
            var visited = new HashSet<Point>();
            queue.Enqueue(new SinglyLinkedList<Point>(start));
            visited.Add(start);
            SinglyLinkedList<Point> resultPath = new SinglyLinkedList<Point>(start);
            var isFindEnd = false;

            while (!isFindEnd && queue.Count != 0)
            {
                var path = queue.Dequeue();
                foreach (var nextPoint in MakeIncedentCells(field, path.Value))
                {
                    if (visited.Contains(nextPoint) ||
                        field.Cells[nextPoint.X, nextPoint.Y] == Cell.Empty) continue;
                    var extendedPath = new SinglyLinkedList<Point>(nextPoint, path);
                    if (end.Equals(nextPoint))
                    {
                        resultPath = extendedPath;
                        isFindEnd = true;
                        break;
                    }
                    visited.Add(nextPoint);
                    queue.Enqueue(extendedPath);
                }
            }

            return resultPath ?? null;
        }

        public static IEnumerable<Point> MakeIncedentCells(Field field, Point point)
        {
            for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                {
                    var newPoint = new Point(point.X + dx, point.Y + dy);
                    if ((dx != 0 && dy != 0) ||
                        newPoint.X < 0 || newPoint.Y < 0 ||
                        newPoint.X >= field.Width ||
                        newPoint.Y >= field.Height ||
                        point.Equals(newPoint)) continue;
                    yield return newPoint;
                }
        }

    }
}
