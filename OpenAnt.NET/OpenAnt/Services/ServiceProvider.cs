namespace OpenAnt.Services
{
    using System;
    using System.Collections.Generic;
    using Engine;

    /// <summary>
    /// Resolves common services.
    /// </summary>
    public class ServiceProvider : IServiceProvider
    {
        /// <summary>
        /// The resolution lookup cache.
        /// </summary>
        private readonly IDictionary<Type, object> resolutionDictionary;
        
        /// <summary>
        /// The service provider singleton.
        /// </summary>
        private static IServiceProvider singleton;

        /// <summary>
        /// Prevents a default instance of the <see cref="ServiceProvider"/> class from being created.
        /// </summary>
        private ServiceProvider()
        {
            this.resolutionDictionary = new Dictionary<Type, object>();

            this.resolutionDictionary.Add(typeof(IWorldManager), new WorldManager());
        }

        /// <summary>
        /// Gets Instance.
        /// </summary>
        public static IServiceProvider Instance
        {
            get { return singleton ?? (singleton = new ServiceProvider()); }
        }

        /// <summary>
        /// Initializes the service provider.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        public void Initialize(ContentProvider contentProvider)
        {
            this.resolutionDictionary.Add(typeof(ContentProvider), contentProvider);
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <returns>
        /// A service object of type <paramref name="serviceType"/>.-or- null if there is no service object of type <paramref name="serviceType"/>.
        /// </returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param><filterpriority>2</filterpriority>
        public object GetService(Type serviceType)
        {
            return this.resolutionDictionary[serviceType];
        }
    }
}
