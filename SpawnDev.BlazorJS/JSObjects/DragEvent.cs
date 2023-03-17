using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/DragEvent
    public class DragEvent : MouseEvent
    {
        public DragEvent(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
        public DataTransfer DataTransfer => JSRef.Get<DataTransfer>("dataTransfer");
    }
}
