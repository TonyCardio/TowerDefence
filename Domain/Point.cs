﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
   public  class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Point(int x, int y) { X = x; Y = y; }

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static bool operator ==(Point p1, Point p2) => (p1.X == p2.X && p1.Y == p2.Y);

        public static bool operator !=(Point p1, Point p2) => (p1.X == p2.X && p1.Y == p2.Y);

        public override string ToString() => $"({X}, {Y})";
    }
}
