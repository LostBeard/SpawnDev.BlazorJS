using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.Blazor.UnitTesting
{
    public static class TaskExtensions
    {
        public static async Task<object?> GetResult(this Task _this)
        {
            await _this;
            var typeofTask = _this.GetType();
            if (!typeofTask.IsGenericType) return null;
            var retValue = _this.GetType().GetProperty("Result").GetValue(_this, null);
            return retValue;
        }
    }
}
