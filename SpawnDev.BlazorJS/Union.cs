using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public abstract class Union
    {
        public object? Value { get; protected set; }
        public Type ValueType { get; protected set; }
        protected Union(object? value, Type valueType)
        {
            Value = value;
            ValueType = valueType;
        }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2> : Union
    {
        public static implicit operator Union<T1, T2>(T1 instance) => instance == null ? null : new Union<T1, T2>(instance);
        public static implicit operator Union<T1, T2>(T2 instance) => instance == null ? null : new Union<T1, T2>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3> : Union
    {
        public static implicit operator Union<T1, T2, T3>(T1 instance) => instance == null ? null : new Union<T1, T2, T3>(instance);
        public static implicit operator Union<T1, T2, T3>(T2 instance) => instance == null ? null : new Union<T1, T2, T3>(instance);
        public static implicit operator Union<T1, T2, T3>(T3 instance) => instance == null ? null : new Union<T1, T2, T3>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
        public Union(T5 value) : base(value, typeof(T5)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5, T6> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T6 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
        public Union(T5 value) : base(value, typeof(T5)) { }
        public Union(T6 value) : base(value, typeof(T6)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5, T6, T7> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T6 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T7 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
        public Union(T5 value) : base(value, typeof(T5)) { }
        public Union(T6 value) : base(value, typeof(T6)) { }
        public Union(T7 value) : base(value, typeof(T7)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5, T6, T7, T8> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T6 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T7 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T8 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
        public Union(T5 value) : base(value, typeof(T5)) { }
        public Union(T6 value) : base(value, typeof(T6)) { }
        public Union(T7 value) : base(value, typeof(T7)) { }
        public Union(T8 value) : base(value, typeof(T8)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
        public Union(T5 value) : base(value, typeof(T5)) { }
        public Union(T6 value) : base(value, typeof(T6)) { }
        public Union(T7 value) : base(value, typeof(T7)) { }
        public Union(T8 value) : base(value, typeof(T8)) { }
        public Union(T9 value) : base(value, typeof(T9)) { }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        public Union(T1 value) : base(value, typeof(T1)) { }
        public Union(T2 value) : base(value, typeof(T2)) { }
        public Union(T3 value) : base(value, typeof(T3)) { }
        public Union(T4 value) : base(value, typeof(T4)) { }
        public Union(T5 value) : base(value, typeof(T5)) { }
        public Union(T6 value) : base(value, typeof(T6)) { }
        public Union(T7 value) : base(value, typeof(T7)) { }
        public Union(T8 value) : base(value, typeof(T8)) { }
        public Union(T9 value) : base(value, typeof(T9)) { }
        public Union(T10 value) : base(value, typeof(T10)) { }
    }
}
