using Akka.Actor;
using OverlyComplexWordSearchSolver.Actors;
using OverlyComplexWordSearchSolver.Initialisers;
using OverlyComplexWordSearchSolver.Initialisers.Memory;
using OverlyComplexWordSearchSolver.Runner;
using System;
using Unity;
using Container = OverlyComplexWordSearchSolver.DependencyInjection.Container;

namespace OverlyComplexWordSearchSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // The fun idea to use as many frameworks as possible to solve a simple word search

            // Entry components
            Container.Instance.RegisterType<ApplicationRunner>();

            // Solver components
            Container.Instance.RegisterType<IGridInitialiser, FromMemoryGridInitialiser>(TypeLifetime.PerResolve);

            // Akka components
            Container.Instance.RegisterFactory<ActorSystem>(container => ActorSystem.Create("OverlyComplicatedWordSearchSolverActorSystem"), FactoryLifetime.Singleton);
            Container.Instance.RegisterFactory<SolvingDelegatorActorProvider>(container =>
            {
                SolvingDelegatorActorProvider provider = () => container.Resolve<ActorSystem>().ActorOf(SolvingDelegatorActor.Props());

                return provider;

            }, FactoryLifetime.PerResolve);


            // Execute runner
            Container.Instance.Resolve<ApplicationRunner>().Execute();

           // Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
