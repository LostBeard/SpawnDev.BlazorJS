namespace SpawnDev.BlazorJS.JSObjects
{
    public class PromiseCatchException<TCatch> : Exception
    {
        public TCatch CatchValue { get; init; }
        public PromiseCatchException(TCatch catchValue)
        {
            CatchValue = catchValue;
        }
    }
}
