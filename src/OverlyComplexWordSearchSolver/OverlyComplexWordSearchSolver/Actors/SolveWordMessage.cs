using OverlyComplexWordSearchSolver.Domain;
using System;

namespace OverlyComplexWordSearchSolver.Actors
{
    public class SolveWordMessage
    {
        public string Word { get; }
        public ReadOnlyMemory<Position> PositionReadOnlyMemory { get; }

        public SolveWordMessage(string word, ReadOnlyMemory<Position> positionReadOnlyMemory)
        {
            Word = word;
            PositionReadOnlyMemory = positionReadOnlyMemory;
        }
    }
}
