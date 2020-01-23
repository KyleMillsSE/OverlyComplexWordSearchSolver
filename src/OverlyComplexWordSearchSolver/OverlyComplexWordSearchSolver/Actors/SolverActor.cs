using System;
using Akka.Actor;

namespace OverlyComplexWordSearchSolver.Actors
{
    public class SolverActor : ReceiveActor
    {
        public static Props Props() => Akka.Actor.Props.Create(() => new SolverActor());

        public SolverActor()
        {
            Receive<SolveWordMessage>(message =>
            {
                // Execute
                Console.WriteLine($"I am finding word '{message.Word}' - I promise");
            });
        }
    }
}
