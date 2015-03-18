using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

namespace uManage
{
    /// <summary>
    /// Ninject Dependency Scoper
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot _resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyScope"/> class.
        /// </summary>
        /// <param name="resolver">The resolver.</param>
        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            _resolver = resolver;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        /// <exception cref="System.ObjectDisposedException">this;This scope has already been disposed</exception>
        public object GetService(Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return _resolver.TryGet(serviceType);
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        /// <exception cref="System.ObjectDisposedException">this;This scope has already been disposed</exception>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return _resolver.GetAll(serviceType);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            _resolver = null;

        }
    }

    /// <summary>
    /// Ninject Dependency Resolver
    /// </summary>
    public class NinjectResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel _kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectResolver"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            _kernel = null;

        }
    }
}
