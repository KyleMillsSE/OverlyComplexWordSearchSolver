using System;
using System.Linq;
using Akka.Actor;
using Akka.Util.Internal;
using OverlyComplexWordSearchSolver.Domain;

namespace OverlyComplexWordSearchSolver.Actors
{
    public class SolvingDelegatorActor : ReceiveActor
    {
        private ReadOnlyMemory<Position> PositionReadonlyMemory;

        public static Props Props() => Akka.Actor.Props.Create(() => new SolvingDelegatorActor());

        public SolvingDelegatorActor()
        {
            // Initial entry message that will create an actor (thread) per word
            // Inform actor to start executing
            Receive<StartSolvingMessage>(message =>
            {
                PositionReadonlyMemory = message.PositionReadOnlyMemory;

                message.Words.ForEach(word =>
                {
                    var actorRef = Context.ActorOf(SolverActor.Props(), word);

                    actorRef.Tell(new SolveWordMessage(word, PositionReadonlyMemory));
                });
            });

            // Word has been found
            // Stop actor
            Receive<SolveWordCompletedMessage>(message =>
            {
                Console.WriteLine($"'{message.Word}' Found at '{message.Positions.Aggregate("", (accum, position) => accum += $"(X={position.X},Y={position.Y}) ").Trim()}'");

                var actorRef = Context.Child(message.Word);

                if (actorRef != ActorRefs.Nobody)
                {
                    actorRef.Tell(PoisonPill.Instance);
                }
            });
        }
    }
}
