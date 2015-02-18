using Ninject;
using uManage.Directories;
using uManage.Directories.ActiveDirectory;

namespace uManage
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IDirectoryService>().To<ActiveDirectoryService>();
            return kernel;
        }
    }
}
