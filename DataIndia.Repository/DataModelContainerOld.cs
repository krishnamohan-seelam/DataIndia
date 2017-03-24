using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIndia.Repository
{
    public static class DataModelContainerOld
    {

        private static readonly object SingletonKey = new object();
        private static IUnityContainer _instance;

        public static IUnityContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SingletonKey)
                    {
                        if (_instance == null)
                        {
                            _instance = new UnityContainer();
                            _instance.RegisterType<IStateRepository, StateRepository>();
                        }
                    }
                }
                return _instance;
            }

        }
    }
}
