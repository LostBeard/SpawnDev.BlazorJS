using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class NotificationEvent : ExtendableEvent
    {
        public NotificationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
