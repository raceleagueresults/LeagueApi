using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Configuration;
using Infrastructure.Data.MainModule.Repositories;


namespace Infrastructure.CrossCutting.IoC
{
    public static class IoCFactory
    {
        #region Members

        private static IDictionary<string, IUnityContainer> _containersDictionary;

        #endregion

        #region Constructor

        /// <summary>
        /// Wires up the ioc containers
        /// <remarks>
        /// This static constructor remove 'beforeFieldInit' IL annotation
        /// </remarks>
        /// </summary>        
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static IoCFactory()
        {
            InitContainers();
        }

        #endregion

        #region Private Methods

        static void InitContainers()
        {
            /*
             * CREATE DICTIONARY
             */
            _containersDictionary = new Dictionary<string, IUnityContainer>();

            /*
             * CREATE CONTAINERS 
             */
            //Create root container
            IUnityContainer rootContainer = new UnityContainer();

            _containersDictionary.Add("RootContext", rootContainer);

            //Create container for real context, child of root container
            var realAppContainer = rootContainer.CreateChildContainer();

            _containersDictionary.Add("RealAppContext", realAppContainer);

            //Create container for testing, child of root container
            //IUnityContainer fakeAppContainer = rootContainer.CreateChildContainer();
            //_containersDictionary.Add("FakeAppContext", fakeAppContainer);

            /*
             * CONFIGURE CONTAINERS
             */
            ConfigureRootContainer(rootContainer);

			//ConfigureRealContainer(realAppContainer);
            //ConfigureFakeContainer(fakeAppContainer);
        }

        /// <summary>
        /// Configure root container.Register types and life time managers for unity builder process
        /// </summary>
        /// <param name="container">Container to configure</param>
        static void ConfigureRootContainer(IUnityContainer container)
        {
            // Take into account that Types and Mappings registration could be also done using the UNITY XML configuration
            //But we prefer doing it here (C# code) because we'll catch errors at compiling time instead execution time, if any type has been written wrong.


            //Register Services mappings

            //Register Repositories mappings
            container.RegisterType<IClientRepository, ClientRepository>(new TransientLifetimeManager());

            //Register crosscuting mappings
            // container.RegisterType<ITraceManager, TraceManager>(new TransientLifetimeManager());

        }

        /// <summary>
        /// Configure real container. Register types and life time managers for unity builder process
        /// </summary>
        /// <param name="container">Container to configure</param>
		//static void ConfigureRealContainer(IUnityContainer container)
		//{
		//    // container.RegisterType<IMainModuleContext, MainModuleContext>(new PerExecutionContextLifetimeManager());
		//}

        /// <summary>
        /// Configure fake container.Register types and life time managers for unity builder process
        /// </summary>
        /// <param name="container">Container to configure</param>
		//static void ConfigureFakeContainer(IUnityContainer container)
		//{
		//    //Note: Generic register type method cannot be used here, 
		//    //MainModuleFakeContext cannot have implicit conversion to IMainModuleContext

		//    // container.RegisterType(typeof(IMainModuleContext), typeof(MainModuleFakeContext), new PerExecutionContextLifetimeManager());
		//}

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns an injected object instance implementation for the requested interface
        /// IMPORTANT: It uses default IoC Container defined in AppSettings
        /// </summary>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// defaultIocContainer AppSetting key not found
        /// </exception>
        public static T Resolve<T>()
        {
            //We use the default container specified in AppSettings
            string containerName = ConfigurationManager.AppSettings["defaultIoCContainer"];

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException("");
            }

            return Resolve<T>(containerName);


        }


        /// <summary>
        /// Returns an injected implementation for the requested interface
        /// It uses provided IoC Container passed as parameter
        /// </summary>
        public static T Resolve<T>(string containerName)
        {
            //check preconditions
            if (String.IsNullOrEmpty(containerName)
               ||
               String.IsNullOrWhiteSpace(containerName))
            {
                // throw new ArgumentNullException(Messages.exception_DefaultIOCSettings);
            }

            if (!_containersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException("");

            var container = _containersDictionary[containerName];

            return container.Resolve<T>();
        }

        #endregion
    }
}
