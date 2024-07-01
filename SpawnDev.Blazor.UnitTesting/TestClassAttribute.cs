namespace SpawnDev.Blazor.UnitTesting
{
    public class TestClassAttribute : Attribute
    {
        public string Name { get; set; }
        public TestClassAttribute(string name = "")
        {
            Name = name;
        }

    }
}
