using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class UIEvent : Event
    {
        public UIEvent(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
    }
}
