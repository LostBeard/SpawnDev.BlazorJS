using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Notification : JSObject
    {
        public Notification(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Notification(string title) : base(JS.New(nameof(Notification), title)) { }
        public Notification(string title, NotificationOptions options) : base(JS.New(nameof(Notification), title, options)) { }
        /// <summary>
        /// A string representing the current permission to display notifications. Possible values are:
        /// <b>denied</b>: the user refuses to have notifications displayed.
        /// <b>granted</b>: the user accepts having notifications displayed.
        /// <b>default</b>: the user choice is unknown and therefore the browser will act as if the value were denied.
        /// </summary>
        public static string Permission => JS.Get<string>("Notification.permission");
        public static bool IsSupported => !JS.IsUndefined("Notification");
        public static Task<string> RequestPermission() => JS.CallAsync<string>("Notification.requestPermission");
    }
}
