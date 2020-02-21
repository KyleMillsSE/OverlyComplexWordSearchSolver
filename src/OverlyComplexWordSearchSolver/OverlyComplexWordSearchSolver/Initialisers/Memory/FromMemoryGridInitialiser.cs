using OverlyComplexWordSearchSolver.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OverlyComplexWordSearchSolver.Initialisers.Memory
{
    public class FromMemoryGridInitialiser : IGridInitialiser
    {
        private readonly IReadOnlyCollection<string> _searchWords = new List<string>()
        {
            "dog",
            "cat",
            "frog"
        };

        private readonly IReadOnlyCollection<IReadOnlyCollection<char>> _grid = new List<List<char>>()
        {
            new List<char>() { 'c', 'a', 't', 't', 'f', 'g' },
            new List<char>() { 'l', 'f', 'r', 'o', 'g', 'i' },
            new List<char>() { 'c', 'a', 'o', 'o', 'e', 'c' },
            new List<char>() { 'f', 'o', 'g', 'g', 'o', 'd' }
        };

        /// <inheritdoc/>
        public IReadOnlyCollection<string> GetWords() => _searchWords;

        /// <inheritdoc/>
        public IReadOnlyCollection<Position> GetPositions() => _grid.Reverse().Select((characters, y) => characters.Select((cha, x) => new Position(cha, x + 1, y + 1))).SelectMany(x => x).ToList();
    }
}
