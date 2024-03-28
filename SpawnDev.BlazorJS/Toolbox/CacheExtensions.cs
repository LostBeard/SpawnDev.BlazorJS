using SpawnDev.BlazorJS.JSObjects;
using System.Text;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Adds extension methods to Cache
    /// </summary>
    public static class CacheExtensions
    {

        private static JsonSerializerOptions JsonSerializerDeserializeOptions { get; set; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip };
        /// <summary>
        /// Non-standard shortcut method to get the cache keys as an array of the Request.url strings instead of Request objects
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> KeyUrls(this Cache _this)
        {
            var tmp = await _this.Keys();
            var ret = tmp.Select(o => o.Url).ToList();
            tmp.DisposeAll();
            return ret;
        }

        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        static string _HostName = "";
        static string HostName
        {
            get
            {
                if (string.IsNullOrEmpty(_HostName))
                {
                    var href = JS.Get<string>("location.href");
                    var uri = new Uri(href);
                    _HostName = uri.Host;
                }
                return _HostName;
            }
        }

        public static Task<List<string>> GetAllDirectories(this Cache _this) => _this.GetDirectories("/", true);
        public static async Task<List<string>> GetDirectories(this Cache _this, string inFolder = "/", bool recursive = false)
        {
            var ret = await _this.GetAllHostFiles(HostName, true);
            if (!inFolder.EndsWith("/")) inFolder += "/";
            var dirs = new HashSet<string>();
            foreach (var o in ret)
            {
                if (!o.StartsWith(inFolder)) continue;
                var subPath = o.Substring(inFolder.Length);
                var pathParts = subPath.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var dir = inFolder;
                for (var i = 0; i < pathParts.Length - 1; i++)
                {
                    var part = pathParts[i];
                    dir += $"{part}/";
                    dirs.Add($"/{dir.Trim('/')}");
                    if (!recursive)
                    {
                        break;
                    }
                }
            }
            return dirs.ToList();
        }

        public static Task<List<string>> GetAllFiles(this Cache _this) => _this.GetFiles("/", true);
        public static async Task<List<string>> GetFiles(this Cache _this, string inFolder = "/", bool recursive = false)
        {
            var ret = await _this.GetAllHostFiles(HostName, true);
            if (!inFolder.EndsWith("/")) inFolder += "/";
            ret = ret.Where(o =>
            {
                if (!o.StartsWith(inFolder)) return false;
                if (!recursive)
                {
                    var subPath = o.Substring(inFolder.Length);
                    var queryPos = subPath.IndexOf('?');
                    if (queryPos > -1) subPath = subPath.Substring(0, queryPos);
                    if (subPath.Contains("/")) return false;
                }
                return true;
            }).ToList();
            return ret;
        }

        public enum CachePathType
        {
            NOT_FOUND,
            DIRECTORY,
            FILE,
        }

        public static async Task<CachePathType> GetPathType(this Cache _this, string path)
        {
            var files = await _this.GetAllFiles();
            if (!files.Any()) return CachePathType.NOT_FOUND;
            path = $"/{path.Trim('/')}/";
            files = files.Select(o => $"/{o.Trim('/')}/").ToList();
            if (files.Contains(path)) return CachePathType.FILE;
            files = files.Where(o => o.StartsWith(path)).ToList();
            if (files.Any()) return CachePathType.DIRECTORY;
            return CachePathType.NOT_FOUND;
        }

        public static async Task<List<string>> GetAllHostFiles(this Cache _this, string hostname, bool returnAbsolutePaths = false)
        {
            var ret = new List<string>();
            var requests = await _this.Keys();
            var hostnameTmp = hostname.Contains("://") ? hostname : $"https://{hostname}";
            var hostUri = new Uri(hostnameTmp);
            foreach (var request in requests)
            {
                var url = request.Url;
                var urlUri = new Uri(url);
                if (hostUri.Host != urlUri.Host) continue;
                var file = returnAbsolutePaths ? urlUri.AbsolutePath : url;
                ret.Add(file);
            }
            requests.DisposeAll();
            return ret;
        }
        public static Task WriteBytes(this Cache _this, string url, byte[] content, string contentType = "")
        {
            using var uint8 = new Uint8Array(content);
            using var uint8Buffer = uint8.Buffer;
            using (var response = new Response(uint8Buffer))
            {
                if (!string.IsNullOrEmpty(contentType)) response.HeaderSet("Content-Type", contentType);
                response.HeaderSet("Content-Length", uint8Buffer.ByteLength.ToString());
                return _this.Put(url, response);
            }
        }

        public static Task WriteUint8Array(this Cache _this, string url, Uint8Array uint8Array, string contentType = "")
        {
            using var buffer = uint8Array.Buffer;
            return _this.WriteArrayBuffer(url, buffer);
        }

        public static Task WriteArrayBuffer(this Cache _this, string url, ArrayBuffer buffer, string contentType = "")
        {
            using (var response = new Response(buffer))
            {
                if (!string.IsNullOrEmpty(contentType)) response.HeaderSet("Content-Type", contentType);
                response.HeaderSet("Content-Length", buffer.ByteLength.ToString());
                return _this.Put(url, response);
            }
        }

        public static Task WriteBlob(this Cache _this, string url, Blob buffer, string contentType = "")
        {
            using (var response = new Response(buffer))
            {
                if (!string.IsNullOrEmpty(contentType)) response.HeaderSet("Content-Type", contentType);
                response.HeaderSet("Content-Length", buffer.Size.ToString());
                return _this.Put(url, response);
            }
        }

        public static Task WriteText(this Cache _this, string url, string content, string contentType = "text/plain")
        {
            return _this.WriteBytes(url, Encoding.UTF8.GetBytes(content), contentType);
        }

        public static Task WriteJSON(this Cache _this, string url, object value, string contentType = "application/json")
        {
            return _this.WriteText(url, JsonSerializer.Serialize(value), contentType);
        }

        public static async Task<byte[]?> ReadBytes(this Cache _this, string url, CacheMatchOptions? options = null)
        {
            using var response = options == null ? await _this.Match(url) : await _this.Match(url, options);
            return response == null ? null : await response.ReadBytes();
        }

        public static async Task<ArrayBuffer?> ReadArrayBuffer(this Cache _this, string url, CacheMatchOptions? options = null)
        {
            using var response = options == null ? await _this.Match(url) : await _this.Match(url, options);
            return response == null ? null : await response.ArrayBuffer();
        }

        public static async Task<Blob?> ReadBlob(this Cache _this, string url, CacheMatchOptions? options = null)
        {
            using var response = options == null ? await _this.Match(url) : await _this.Match(url, options);
            return response == null ? null : await response.Blob();
        }

        public static async Task<string?> ReadText(this Cache _this, string url, CacheMatchOptions? options = null)
        {
            using var response = options == null ? await _this.Match(url) : await _this.Match(url, options);
            return response == null ? null : await response.Text();
        }

        public static async Task<T?> ReadJSON<T>(this Cache _this, string url, CacheMatchOptions? options = null, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            var tmp = await _this.ReadText(url, options);
            if (tmp == null) return default;
            return JsonSerializer.Deserialize<T>(tmp, jsonSerializerOptions != null ? jsonSerializerOptions : JsonSerializerDeserializeOptions) ?? default;
        }

        public static async Task<string?> GetContentType(this Cache _this, string url, CacheMatchOptions? options = null)
        {
            using var response = options == null ? await _this.Match(url) : await _this.Match(url, options);
            if (response == null) return null;
            using var headers = response.JSRef.Get<JSObject>("headers");
            return headers == null ? "" : headers.JSRef.Get<string>("content-type") ?? "";
        }

        public static string GetFilename(this Cache _this, string url, bool nameOnly = false)
        {
            var ret = url.Split('/').Last();
            if (nameOnly)
            {
                // remove query string and hash
                ret = ret.Split('?').First();
                ret = ret.Split('#').First();
            }
            return ret;
        }

        public static async Task<long?> GetSize(this Cache _this, string url, CacheMatchOptions? options = null)
        {
            using var response = options == null ? await _this.Match(url) : await _this.Match(url, options);
            if (response == null) return null;
            using var headers = response.JSRef!.Get<JSObject>("headers");
            var contentLength = headers.JSRef!.Get<string>("content-length");
            if (!string.IsNullOrEmpty(contentLength) && int.TryParse(contentLength, out var val))
            {
                return val;
            }
            else
            {
                using var buffer = await response.ArrayBuffer();
                return buffer.ByteLength;
            }
        }
    }
}
