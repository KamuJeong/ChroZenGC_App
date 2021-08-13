using Autofac;
using Autofac.Core;

namespace ChroZenService
{
    public static class Resolver
    {
        private static IContainer container;

        public static void Initialize(IContainer container)
        {
            Resolver.container = container;
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static T Resolve<T>(params Parameter[] namedParameters)
        {
            return container.Resolve<T>(namedParameters);
        }
    }
}