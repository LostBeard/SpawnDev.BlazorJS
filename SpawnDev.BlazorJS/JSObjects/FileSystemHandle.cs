using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    [JsonConverter(typeof(JSObjectConverter<FileSystemHandle>))]
    public class FileSystemHandle : JSObject
    {
        public FileSystemHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Name => JSRef.Get<string>("name");
        public string Kind => JSRef.Get<string>("kind");
        public bool IsSameEntry(FileSystemHandle fsHandle) => JSRef.Call<bool>("isSameEntry", fsHandle);

        public static async Task<List<T>> IterateAsync<T>(IJSInProcessObjectReference iteratee)
        {
            var ret = new List<T>();
            while (true)
            {
                using (var next = await iteratee.CallAsync<IJSInProcessObjectReference>("next"))
                {
                    if (next.Get<bool>("done")) break;
                    ret.Add(next.Get<T>("value"));
                }
            }
            return ret;
        }

        //public enum ReadWritePermissions
        //{
        //    NOT_ALLOWED,
        //    READ,
        //    READ_WRITE,
        //}

        public async Task<string> GetReadWritePermissions()
        {
            if (await IsWritable()) return "rw";
            if (await IsReadable()) return "r";
            return "";
        }

        public async Task<bool> IsWritable()
        {
            try
            {
                return await VerifyPermission(true, false);
            }
            catch { }
            return false;
        }

        public async Task<bool> IsReadable()
        {
            try
            {
                return await VerifyPermission(false, false);
            }
            catch { }
            return false;
        }

        public async Task<string> QueryPermission(bool writePermission = false)
        {
            dynamic options = new ExpandoObject();
            options.mode = writePermission ? "readwrite" : "read";
            return await JSRef.CallAsync<string>("queryPermission", (object)options);
        }

        public async Task<string> RequestPermission(bool writePermission = false)
        {
            dynamic options = new ExpandoObject();
            options.mode = writePermission ? "readwrite" : "read";
            return await JSRef.CallAsync<string>("requestPermission", (object)options);
        }

        public async Task<bool> VerifyPermission(bool readWrite = true, bool askIfNeeded = true)
        {
            dynamic options = new ExpandoObject();
            options.mode = readWrite ? "readwrite" : "read";
            if ((await JSRef.CallAsync<string>("queryPermission", (object)options)) == "granted") return true;
            if (askIfNeeded && (await JSRef.CallAsync<string>("requestPermission", (object)options)) == "granted") return true;
            return false;
        }
    }
}
