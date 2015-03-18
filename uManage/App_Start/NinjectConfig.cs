using Ninject;
using uManage.Directories;
using uManage.Directories.ActiveDirectory;

namespace uManage
{
    /// <summary>
    /// Ninject Wireup
    /// </summary>
    public static class NinjectConfig
    {
        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns></returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IDirectoryService>().To<ActiveDirectoryService>();
            return kernel;
        }
    }
}
