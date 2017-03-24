using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace DataIndia.Helpers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
         private IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (!_container.IsRegistered(serviceType) && (serviceType.IsAbstract) && (serviceType.IsInterface))
                return null;
            else
                return _container.Resolve(serviceType);

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
    }
}