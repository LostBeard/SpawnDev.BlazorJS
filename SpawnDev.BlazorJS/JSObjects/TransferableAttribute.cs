namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Indicates the class type is a transferable object.<br/>
    /// Transferable objects are objects that own resources that can be transferred from one context to another,<br/>
    /// ensuring that the resources are only available in one context at a time. Following a transfer, the original <br/>
    /// object is no longer usable; it no longer points to the transferred resource, and any attempt to read or write<br/>
    /// the object will throw an exception.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Web_Workers_API/Transferable_objects
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TransferableAttribute : Attribute { }
}
