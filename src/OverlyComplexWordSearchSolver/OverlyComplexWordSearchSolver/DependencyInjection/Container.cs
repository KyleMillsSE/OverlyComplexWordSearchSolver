using Unity;

namespace OverlyComplexWordSearchSolver.DependencyInjection
{
    public sealed class Container
    {
        private static readonly object _objectLock = new object();

        private static UnityContainer _instance;
        public static UnityContainer Instance
        {
            get
            {
                lock (_objectLock)
                {
                    return _instance ??= new UnityContainer();
                }
            }
        }

        private Container()
        { }
    }
}
