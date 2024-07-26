using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Undefined type
    /// </summary>
    public class JSInProcessObjectReferenceUndefined : IJSInProcessObjectReference
    {
        /// <summary>
        /// Indicates that the valeu is undefined when deserialized in Javascript
        /// </summary>
        [JsonPropertyName("__undefinedref__")]
        public bool UndefinedTag { get; } = true;
        /// <summary>
        /// Non-functional method place holder
        /// </summary>
        public void Dispose() { }
        /// <summary>
        /// Non-functional method place holder
        /// </summary>
        public ValueTask DisposeAsync() => ValueTask.CompletedTask;
        /// <summary>
        /// Non-functional method place holder
        /// </summary>
        public TValue Invoke<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string identifier, params object?[]? args) => throw new NotImplementedException();
        /// <summary>
        /// Non-functional method place holder
        /// </summary>
        public ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string identifier, object?[]? args) => throw new NotImplementedException();
        /// <summary>
        /// Non-functional method place holder
        /// </summary>
        public ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string identifier, CancellationToken cancellationToken, object?[]? args) => throw new NotImplementedException();
    }
}