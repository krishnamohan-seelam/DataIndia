using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * The old singleton code  uses locking mechanism  null checks leading us to write more code, instead we leverage on compiler feature
 *  to use private static constructor 
 */
namespace DataIndia.Repository
{
    public static class DataModelContainer
    {

        
        private static IUnityContainer _instance;

        static DataModelContainer()
        {
            _instance = new UnityContainer();
        }
        public static IUnityContainer Instance
        {
            get
            {
                _instance.RegisterType<IStateRepository, StateRepository>(new HierarchicalLifetimeManager());
                _instance.RegisterType<IDistrictRepository, DistrictRepository>(new HierarchicalLifetimeManager());
                return _instance;
            }

        }
    }
}
