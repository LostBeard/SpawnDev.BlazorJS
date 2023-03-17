using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DataTransfer : JSObject
    {
        public DataTransfer(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
        public string DropEffect { get => JSRef.Get<string>("dropEffect"); set => JSRef.Set("dropEffect", value); }
        public string EffectAllowed { get => JSRef.Get<string>("effectAllowed"); set => JSRef.Set("effectAllowed", value); }
    }
}
