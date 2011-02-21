namespace OpenAnt.Extensions
{
    using System;

    /// <summary>
    /// Provides service provider extensions.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Resolves an implementation from the given service type.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        /// <typeparam name="T">
        /// The service type to resolve.
        /// </typeparam>
        /// <returns>
        /// The resolved service.
        /// </returns>
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
