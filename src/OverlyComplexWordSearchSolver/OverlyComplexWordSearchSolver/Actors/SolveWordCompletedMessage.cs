using System.Collections.Generic;
using OverlyComplexWordSearchSolver.Domain;

namespace OverlyComplexWordSearchSolver.Actors
{
    public class SolveWordCompletedMessage
    {
        public string Word { get; }
        public IReadOnlyCollection<Position> Positions { get; }

        public SolveWordCompletedMessage(string word, IReadOnlyCollection<Position> positions)
        {
            Word = word;
            Positions = positions;
        }
    }
}
