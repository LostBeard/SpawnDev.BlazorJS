namespace SpawnDev.BlazorJS
{
    public static class TaskExtensions
    {
        public static async Task<object?> GetResult(this Task _this)
        {
            await _this;
            var typeofTask = _this.GetType();
            if (!typeofTask.IsGenericType) return null;
            var resultProperty = typeofTask.GetProperty("Result");
            if (resultProperty == null) return null;
            var retValue = resultProperty.GetValue(_this, null);
            return retValue;
        }
    }
}
