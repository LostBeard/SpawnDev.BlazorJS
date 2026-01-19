using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace SpawnDev.BlazorJS.Tests
{
    internal class StaticFileServer
    {
        WebApplication? app;
        Task? runningTask;
        string WWWRoot;
        string RequestPath;
        string Url;
        string devcertPath;
        public StaticFileServer(string wwwroot, string url, string requestPath = "")
        {
            if (string.IsNullOrEmpty(wwwroot) || !Directory.Exists(wwwroot))
            {
                throw new ArgumentNullException(nameof(wwwroot));
            }
            WWWRoot = Path.GetFullPath(wwwroot);
            RequestPath = requestPath;
            Url = url;
            devcertPath = Path.GetFullPath("assets/testcert.pfx");
            if (!File.Exists(devcertPath))
                throw new Exception("testcert.pfx not found. Cannot create static server");
        }
        public bool Running => runningTask?.IsCompleted == false;
        public void Start()
        {
            runningTask ??= StartAsync();
        }
        private async Task StartAsync()
        {
            try
            {
                var builder = WebApplication.CreateBuilder();
                var port = new Uri(Url).Port;

                // Configure static file serving
                builder.WebHost.UseKestrel();
                builder.WebHost.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.Listen(IPAddress.Loopback, port, listenOptions =>
                    {
                        listenOptions.UseHttps(devcertPath, "unittests");
                    });
                });
                // Use the current directory as the web root
                builder.Environment.WebRootPath = WWWRoot;
                builder.WebHost.UseUrls(Url);

                app = builder.Build();

                // enable index.html fallback
                app.UseDefaultFiles(new DefaultFilesOptions
                {
                    FileProvider = new PhysicalFileProvider(WWWRoot),
                    RequestPath = RequestPath
                });
                // enable unknown file types (required)
                app.UseFileServer(new FileServerOptions
                {
                    FileProvider = new PhysicalFileProvider(WWWRoot),
                    RequestPath = RequestPath,
                    EnableDirectoryBrowsing = false, // Optional: allows browsing directory listings
                    StaticFileOptions = {
                        ServeUnknownFileTypes = true, // Crucial: serves all file types, even those without known MIME types
                        DefaultContentType = "application/octet-stream" // Optional: default MIME type for unknown files
                    }
                });
                // start hosting
                await app.RunAsync();
            }
            finally
            {
                app = null;
                runningTask = null;
            }
        }
        public async Task Stop()
        {
            if (app == null || runningTask == null) return;
            try
            {
                await app.StopAsync();
            }
            catch { }
            await app.DisposeAsync();
            if (runningTask != null)
            {
                try
                {
                    await runningTask;
                }
                catch { }
            }
        }
    }
}
