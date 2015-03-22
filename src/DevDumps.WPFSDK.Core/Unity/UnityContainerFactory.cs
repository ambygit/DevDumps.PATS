using System;
using Microsoft.Practices.Unity;

namespace DevDumps.WPFSDK.Core.Unity
{
    public static class UnityContainerFactory
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    throw new InvalidOperationException("Container has been requested, but has not been initialized yet");
                }
                return _container;
            }
        }

        public static bool IsInitialised
        {
            get { return _container != null; }
        }

        //Hide constructor for class

        /// <summary>
        /// Set the _container to be served
        /// </summary>
        /// <param name="unityContainer"></param>
        public static void Init(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }
    }
}
