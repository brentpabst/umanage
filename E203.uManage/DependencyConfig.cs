using Ninject;
using Ninject.Extensions.Conventions;

namespace S203.uManage
{
    public static class DependencyConfig
    {
        public static IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind(x =>
            {
                x.FromAssembliesMatching("S203.uManage.*.dll")
                    .SelectAllClasses()
                    .BindAllInterfaces();
            });

            return kernel;
        }
    }
}
