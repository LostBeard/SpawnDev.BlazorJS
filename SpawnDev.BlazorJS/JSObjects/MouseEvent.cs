using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{

    public class MouseEvent : UIEvent
    {
        public MouseEvent(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
    }
}
