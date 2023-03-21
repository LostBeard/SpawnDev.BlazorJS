namespace SpawnDev.BlazorJS
{
    public abstract class Union
    {
        public int TIndex { get; protected set; } = 0;
        public object? Value { get;protected set; }
        public Type ValueType { get; protected set; }
        public Union(object? value, Type valueType)
        {
            Value = value;
            ValueType = valueType;
        }
    }
    public class Union<T1, T2> : Union
    {
        public static implicit operator Union<T1, T2>(T1 instance) => new Union<T1, T2>(instance);
        public static implicit operator Union<T1, T2>(T2 instance) => new Union<T1, T2>(instance);
        public T1? ValueT1 { get; protected set; }
        public T2? ValueT2 { get; protected set; }
        public Union(T1 value) : base(value, typeof(T1)) {
            TIndex = 1;
            ValueT1 = value;
        }
        public Union(T2 value) : base(value, typeof(T2))
        {
            TIndex = 2;
            ValueT2 = value;
        }
    }
    public class Union<T1, T2, T3> : Union
    {
        public static implicit operator Union<T1, T2, T3>(T1 instance) => new Union<T1, T2, T3>(instance);
        public static implicit operator Union<T1, T2, T3>(T2 instance) => new Union<T1, T2, T3>(instance);
        public static implicit operator Union<T1, T2, T3>(T3 instance) => new Union<T1, T2, T3>(instance);
        public T1? ValueT1 { get; protected set; }
        public T2? ValueT2 { get; protected set; }
        public T3? ValueT3 { get; protected set; }
        public Union(T1 value) : base(value, typeof(T1))
        {
            TIndex = 1;
            ValueT1 = value;
        }
        public Union(T2 value) : base(value, typeof(T2))
        {
            TIndex = 2;
            ValueT2 = value;
        }
        public Union(T3 value) : base(value, typeof(T3))
        {
            TIndex = 3;
            ValueT3 = value;
        }
    }
    public class Union<T1, T2, T3, T4> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4>(T1 instance) => new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T2 instance) => new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T3 instance) => new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T4 instance) => new Union<T1, T2, T3, T4>(instance);
        public T1? ValueT1 { get; protected set; }
        public T2? ValueT2 { get; protected set; }
        public T3? ValueT3 { get; protected set; }
        public T4? ValueT4 { get; protected set; }
        public Union(T1 value) : base(value, typeof(T1))
        {
            TIndex = 1;
            ValueT1 = value;
        }
        public Union(T2 value) : base(value, typeof(T2))
        {
            TIndex = 2;
            ValueT2 = value;
        }
        public Union(T3 value) : base(value, typeof(T3))
        {
            TIndex = 3;
            ValueT3 = value;
        }
        public Union(T4 value) : base(value, typeof(T4))
        {
            TIndex = 4;
            ValueT4 = value;
        }
    }
    public class Union<T1, T2, T3, T4, T5> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5>(T1 instance) => new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T2 instance) => new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T3 instance) => new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T4 instance) => new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T5 instance) => new Union<T1, T2, T3, T4, T5>(instance);
        public T1? ValueT1 { get; protected set; }
        public T2? ValueT2 { get; protected set; }
        public T3? ValueT3 { get; protected set; }
        public T4? ValueT4 { get; protected set; }
        public T5? ValueT5 { get; protected set; }
        public Union(T1 value) : base(value, typeof(T1))
        {
            TIndex = 1;
            ValueT1 = value;
        }
        public Union(T2 value) : base(value, typeof(T2))
        {
            TIndex = 2;
            ValueT2 = value;
        }
        public Union(T3 value) : base(value, typeof(T3))
        {
            TIndex = 3;
            ValueT3 = value;
        }
        public Union(T4 value) : base(value, typeof(T4))
        {
            TIndex = 4;
            ValueT4 = value;
        }
        public Union(T5 value) : base(value, typeof(T5))
        {
            TIndex = 5;
            ValueT5 = value;
        }
    }
    public class Union<T1, T2, T3, T4, T5, T6> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T1 instance) => new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T2 instance) => new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T3 instance) => new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T4 instance) => new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T5 instance) => new Union<T1, T2, T3, T4, T5, T6>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T6 instance) => new Union<T1, T2, T3, T4, T5, T6>(instance);
        public T1? ValueT1 { get; protected set; }
        public T2? ValueT2 { get; protected set; }
        public T3? ValueT3 { get; protected set; }
        public T4? ValueT4 { get; protected set; }
        public T5? ValueT5 { get; protected set; }
        public T6? ValueT6 { get; protected set; }
        public Union(T1 value) : base(value, typeof(T1))
        {
            TIndex = 1;
            ValueT1 = value;
        }
        public Union(T2 value) : base(value, typeof(T2))
        {
            TIndex = 2;
            ValueT2 = value;
        }
        public Union(T3 value) : base(value, typeof(T3))
        {
            TIndex = 3;
            ValueT3 = value;
        }
        public Union(T4 value) : base(value, typeof(T4))
        {
            TIndex = 4;
            ValueT4 = value;
        }
        public Union(T5 value) : base(value, typeof(T5))
        {
            TIndex = 5;
            ValueT5 = value;
        }
        public Union(T6 value) : base(value, typeof(T6))
        {
            TIndex = 6;
            ValueT6 = value;
        }
    }
}
