using Akka.Actor;
using OverlyComplexWordSearchSolver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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

                StartSearch(positions.ToArray(), word, solvedPositions);

                Console.WriteLine($"{DateTime.UtcNow}|Found '{word}' at {solvedPositions.Aggregate("", (x, y) => x += $"'{y.Value} ({y.X},{y.Y})' ")}");
            });
        }

        public void StartSearch(Position[] positions, string word, List<Position> solvedPositions)
        {
            foreach (var possiblePosition in positions.Where(x => x.Value == word.First()))
            {
                EvalPossiblePosition(positions, word, possiblePosition, solvedPositions);

                if (solvedPositions.Count == word.Length)
                {
                    return;
                }
            }
        }

        public void EvalPossiblePosition(Position[] positions, string word, Position possiblePosition, List<Position> solvedPositions)
        {
            solvedPositions.Add(possiblePosition);

            if (solvedPositions.Count == word.Length)
            {
                return;
            }

            var nextPossiblePositions = positions.Where(x => x.Value == word[solvedPositions.Count] &&
                                                             (x.X == possiblePosition.X - 1 && x.Y == possiblePosition.Y // Look left
                                                              || x.X == possiblePosition.X + 1 && x.Y == possiblePosition.Y // Look right
                                                              || x.X == possiblePosition.X && x.Y == possiblePosition.Y - 1 // Look down
                                                              || x.X == possiblePosition.X && x.Y == possiblePosition.Y + 1)).ToList(); // Look up


            if (!nextPossiblePositions.Any())
            {
                solvedPositions.Remove(possiblePosition);
                return;
            }

            foreach (var nextPossiblePosition in nextPossiblePositions)
            {
                EvalPossiblePosition(positions, word, nextPossiblePosition, solvedPositions);

                if (solvedPositions.Count == word.Length)
                {
                    return;
                }
            }

            if (solvedPositions.Count != word.Length)
            {
                solvedPositions.Remove(possiblePosition);
            }
        }
    }
}
