using System;
using System.Collections.Generic;
using OverlyComplexWordSearchSolver.Domain;

namespace OverlyComplexWordSearchSolver.Actors
{
    public class StartSolvingMessage
    {
        public IReadOnlyCollection<string> Words { get; }
        public ReadOnlyMemory<Position> PositionReadOnlyMemory { get; }

        public StartSolvingMessage(IReadOnlyCollection<string> words, ReadOnlyMemory<Position> positionReadOnlyMemory)
        {
            Words = words;
            PositionReadOnlyMemory = positionReadOnlyMemory;
        }
    }
}
