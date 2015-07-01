using Ninject;
using Ninject.Extensions.Conventions;

namespace E203.uManage
{
    public static class DependencyConfig
    {
        public static IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind(x =>
            {
                x.FromAssembliesMatching("E203.uManage.*.dll")
                    .SelectAllClasses()
                    .BindAllInterfaces();
            });

            return kernel;
        }
    }
}
