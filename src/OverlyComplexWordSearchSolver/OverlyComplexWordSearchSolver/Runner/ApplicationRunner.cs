using Akka.Actor;
using OverlyComplexWordSearchSolver.Actors;
using OverlyComplexWordSearchSolver.Domain;
using OverlyComplexWordSearchSolver.Initialisers;
using System;
using System.Linq;

namespace OverlyComplexWordSearchSolver.Runner
{
    public class ApplicationRunner
    {
        private readonly IGridInitialiser _gridInitialiser;
        private readonly SolvingDelegatorActorProvider _solvingDelegatorActorProvider;

        public ApplicationRunner(IGridInitialiser gridInitialiser, SolvingDelegatorActorProvider solvingDelegatorActorProvider)
        {
            _gridInitialiser = gridInitialiser;
            _solvingDelegatorActorProvider = solvingDelegatorActorProvider;
        }

        public void Execute()
        {
            var words = _gridInitialiser.GetWords();
            var positionReadOnlyMemory = new ReadOnlyMemory<Position>(_gridInitialiser.GetPositions().ToArray());

            // No longer the owner of the readonly memory
            _solvingDelegatorActorProvider().Tell(new StartSolvingMessage(words, positionReadOnlyMemory));
        }
    }
}
