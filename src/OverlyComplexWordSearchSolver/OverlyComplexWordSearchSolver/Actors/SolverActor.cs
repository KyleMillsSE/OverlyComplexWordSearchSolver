using Akka.Actor;
using OverlyComplexWordSearchSolver.Domain;
using System;
using System.Collections.Generic;

namespace OverlyComplexWordSearchSolver.Actors
{
    public class SolverActor : ReceiveActor
    {
        public static Props Props() => Akka.Actor.Props.Create(() => new SolverActor());

        public SolverActor()
        {
            Receive<SolveWordMessage>(message =>
            {
                var positions = message.PositionReadOnlyMemory.Span;
                var word = message.Word;
                
                Console.WriteLine($"{DateTime.UtcNow}|I am finding word '{word}'");

                var solvedPositions = new List<Position>();

                Recurse(positions, word, positions[0], solvedPositions);

                Console.WriteLine($"{DateTime.UtcNow}|Found '{word}'");
            });
        }

        public void Recurse(ReadOnlySpan<Position> positions, string word, Position possiblePosition, List<Position> solvedPositions) // change x and of and start with possible position
        {
            foreach (var position in positions)
            {
                if (position.Value == word[solvedPositions.Count])
                {
                
                    break;
                }
            }
        }
    }
}
