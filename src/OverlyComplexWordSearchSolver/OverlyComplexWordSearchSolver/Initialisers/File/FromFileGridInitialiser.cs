using System;
using System.Collections.Generic;
using OverlyComplexWordSearchSolver.Domain;

namespace OverlyComplexWordSearchSolver.Initialisers.File
{
    public class FromFileGridInitialiser : IGridInitialiser
    {
        private readonly FromFileGridInitialiserConfiguration _fromFileGridInitialiserConfiguration;

        public FromFileGridInitialiser(FromFileGridInitialiserConfiguration fromFileGridInitialiserConfiguration)
        {
            _fromFileGridInitialiserConfiguration = fromFileGridInitialiserConfiguration;
        }

        public IReadOnlyCollection<Position> GetPositions()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<string> GetWords()
        {
            throw new NotImplementedException();
        }
    }
}
