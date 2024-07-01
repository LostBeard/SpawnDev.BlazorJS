namespace SpawnDev.Blazor.UnitTesting
{
    public class UnitTestResolverEvent
    {
        public object? TypeInstance { get; set; } = null;
        public Type TestType { get; private set; }
        public UnitTestResolverEvent(Type testType)
        {
            TestType = testType;
        }
    }
}
