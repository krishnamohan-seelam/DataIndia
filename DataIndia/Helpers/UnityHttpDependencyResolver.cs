using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http.Dependencies;

using Microsoft.Practices.Unity;

namespace DataIndia.Helpers
{
    public class UnityHttpDependencyResolver : IDependencyResolver
    {
         private IUnityContainer _container;

        public UnityHttpDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityHttpDependencyResolver(child);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                if (!_container.IsRegistered(serviceType) && (serviceType.IsAbstract) && (serviceType.IsInterface))
                    return null;
                else
                    return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
    }
}