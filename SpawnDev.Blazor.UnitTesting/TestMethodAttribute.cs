namespace SpawnDev.Blazor.UnitTesting
{
    public class TestMethodAttribute : Attribute
    { 
        public string Name { get; set; }
        public TestMethodAttribute(string name = "") {
            Name = name;
        }

    }
}
