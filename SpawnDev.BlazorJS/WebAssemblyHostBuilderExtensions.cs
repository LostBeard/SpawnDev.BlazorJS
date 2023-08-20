using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static class WebAssemblyHostBuilderExtensions
    {
        /// <summary>
        /// LoadDomainConfiguration loads domain specific configurations that are merged with the default appsettings.json configuration.<br />
        /// Domain specific configurations should be placed in the folder wwwroot/config and be named [DOMAIN].json or [DOMAIN].Development.json<br />
        /// Examples:<br />
        /// wwwroot/config/www.mysite.com.json<br />
        /// wwwroot/config/www.mysite.com.Development.json<br />
        /// wwwroot/config/localhost.json<br />
        /// wwwroot/config/localhost.Development.json<br />
        /// </summary>
        /// <param name="builder">WebAssemblyHostBuilder</param>
        /// <param name="verbose">Show non-fatal error messages</param>
        /// <param name="loadDevelopmentConfigIfIsDevelopment">Load Development configuration if Environment.IsDevelopment()</param>
        /// <returns></returns>
        public static async Task LoadDomainConfiguration(this WebAssemblyHostBuilder builder, bool verbose = false, bool loadDevelopmentConfigIfIsDevelopment = true)
        {
            var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            var domain = baseAddress.Host;   // Ex. www.mysite.com, localhost
            using var http = new HttpClient() { BaseAddress = baseAddress };
            {
                var domainConfig = $"config/{domain}.json";
                try
                {
                    using var response = await http.GetAsync(domainConfig);
                    using var stream = await response.Content.ReadAsStreamAsync();
                    builder.Configuration.AddJsonStream(stream);
                }
                catch (Exception ex)
                {
                    if (verbose) Console.WriteLine($"LoadDomainConfiguration failed: {domainConfig}");
                }
            }
            if (loadDevelopmentConfigIfIsDevelopment && builder.HostEnvironment.IsDevelopment())
            {
                var domainEnvironmentConfig = $"config/{domain}.{builder.HostEnvironment.Environment}.json";
                try
                {
                    using var response = await http.GetAsync(domainEnvironmentConfig);
                    using var stream = await response.Content.ReadAsStreamAsync();
                    builder.Configuration.AddJsonStream(stream);
                }
                catch (Exception ex)
                {
                    if (verbose) Console.WriteLine($"LoadDomainConfiguration failed: {domainEnvironmentConfig}");
                }
            }
        }
    }
}
