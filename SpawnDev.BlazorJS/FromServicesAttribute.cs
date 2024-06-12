namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Method parameters marked with the FromServices attribute will be resolved from the called side peer service provider
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromServicesAttribute : Attribute { }


    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromLocalAttribute : Attribute { }
}
