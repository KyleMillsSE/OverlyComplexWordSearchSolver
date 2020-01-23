using System;
using System.Collections.Generic;
using System.Text;

namespace OverlyComplexWordSearchSolver.Domain
{
    public struct Position
    {
        public char Value { get; }
        public int X { get; }
        public int Y { get; }
        
        public Position(char value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
    }
}
