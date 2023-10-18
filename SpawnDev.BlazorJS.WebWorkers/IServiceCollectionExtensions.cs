using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWebWorkerService(this IServiceCollection _this)
        {
            return _this.AddSingleton<WebWorkerService>();
        }
        /// <summary>
        /// Register the type that will be 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceWorker<T>(this IServiceCollection _this) where T : ServiceWorkerBase
        {
            return _this.AddSingleton<WebWorkerService>();
        }
    }
}
