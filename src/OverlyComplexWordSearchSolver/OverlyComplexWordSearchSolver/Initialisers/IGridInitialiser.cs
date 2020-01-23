using System.Collections.Generic;
using OverlyComplexWordSearchSolver.Domain;

namespace OverlyComplexWordSearchSolver.Initialisers
{
    public interface IGridInitialiser
    {
        /// <summary>
        /// Method to return collection of words to be found within the grid
        /// </summary>
        /// <returns>Readonly collection of string to be found</returns>
        IReadOnlyCollection<string> GetWords();

        /// <summary>
        /// Method to return create grid as a two dimensional structure
        /// </summary>
        /// <returns>Grid as two dimensional collection</returns>
        IReadOnlyCollection<Position> GetPositions();
    }
}
