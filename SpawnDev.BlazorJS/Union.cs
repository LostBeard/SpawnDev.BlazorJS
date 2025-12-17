using SpawnDev.BlazorJS.JsonConverters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public abstract class Union
    {
        protected byte _type = 0;
        public object? Value { get; protected set; }
        public Type ValueType { get; protected set; }
        protected Union(object? value, Type valueType, byte type)
        {
            Value = value;
            ValueType = valueType;
            _type = type;
        }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2> : Union
    {
        public static implicit operator Union<T1, T2>(T1 instance) => instance == null ? null : new Union<T1, T2>(instance);
        public static implicit operator Union<T1, T2>(T2 instance) => instance == null ? null : new Union<T1, T2>(instance);
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3> : Union
    {
        public static implicit operator Union<T1, T2, T3>(T1 instance) => instance == null ? null : new Union<T1, T2, T3>(instance);
        public static implicit operator Union<T1, T2, T3>(T2 instance) => instance == null ? null : new Union<T1, T2, T3>(instance);
        public static implicit operator Union<T1, T2, T3>(T3 instance) => instance == null ? null : new Union<T1, T2, T3>(instance);
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public static implicit operator Union<T1, T2, T3, T4>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4>(instance);
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
    }
    [JsonConverter(typeof(UnionJsonConverter))]
    public sealed class Union<T1, T2, T3, T4, T5> : Union
    {
        public static implicit operator Union<T1, T2, T3, T4, T5>(T1 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T2 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T3 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T4 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public static implicit operator Union<T1, T2, T3, T4, T5>(T5 instance) => instance == null ? null : new Union<T1, T2, T3, T4, T5>(instance);
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
                case 5:
                    return typeof(T) == typeof(T5);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4,
            Action<T5> matchT5
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
                case 5:
                    matchT5((T5)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4,
            Func<T5, T> matchT5
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
                case 5:
                    return matchT5((T5)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
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
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
                case 5:
                    return typeof(T) == typeof(T5);
                case 6:
                    return typeof(T) == typeof(T6);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4,
            Action<T5> matchT5,
            Action<T6> matchT6
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
                case 5:
                    matchT5((T5)Value!);
                    return;
                case 6:
                    matchT6((T6)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4,
            Func<T5, T> matchT5,
            Func<T6, T> matchT6
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
                case 5:
                    return matchT5((T5)Value!);
                case 6:
                    return matchT6((T6)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
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
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
                case 5:
                    return typeof(T) == typeof(T5);
                case 6:
                    return typeof(T) == typeof(T6);
                case 7:
                    return typeof(T) == typeof(T7);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4,
            Action<T5> matchT5,
            Action<T6> matchT6,
            Action<T7> matchT7
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
                case 5:
                    matchT5((T5)Value!);
                    return;
                case 6:
                    matchT6((T6)Value!);
                    return;
                case 7:
                    matchT7((T7)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4,
            Func<T5, T> matchT5,
            Func<T6, T> matchT6,
            Func<T7, T> matchT7
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
                case 5:
                    return matchT5((T5)Value!);
                case 6:
                    return matchT6((T6)Value!);
                case 7:
                    return matchT7((T7)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
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
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        public Union(T8 value) : base(value, typeof(T8), 8) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
                case 5:
                    return typeof(T) == typeof(T5);
                case 6:
                    return typeof(T) == typeof(T6);
                case 7:
                    return typeof(T) == typeof(T7);
                case 8:
                    return typeof(T) == typeof(T8);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4,
            Action<T5> matchT5,
            Action<T6> matchT6,
            Action<T7> matchT7,
            Action<T8> matchT8
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
                case 5:
                    matchT5((T5)Value!);
                    return;
                case 6:
                    matchT6((T6)Value!);
                    return;
                case 7:
                    matchT7((T7)Value!);
                    return;
                case 8:
                    matchT8((T8)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4,
            Func<T5, T> matchT5,
            Func<T6, T> matchT6,
            Func<T7, T> matchT7,
            Func<T8, T> matchT8
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
                case 5:
                    return matchT5((T5)Value!);
                case 6:
                    return matchT6((T6)Value!);
                case 7:
                    return matchT7((T7)Value!);
                case 8:
                    return matchT8((T8)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
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
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        public Union(T8 value) : base(value, typeof(T8), 8) { }
        public Union(T9 value) : base(value, typeof(T9), 9) { }
        public bool Is<T>()
        {
            switch (_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
                case 5:
                    return typeof(T) == typeof(T5);
                case 6:
                    return typeof(T) == typeof(T6);
                case 7:
                    return typeof(T) == typeof(T7);
                case 8:
                    return typeof(T) == typeof(T8);
                case 9:
                    return typeof(T) == typeof(T9);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4,
            Action<T5> matchT5,
            Action<T6> matchT6,
            Action<T7> matchT7,
            Action<T8> matchT8,
            Action<T9> matchT9
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
                case 5:
                    matchT5((T5)Value!);
                    return;
                case 6:
                    matchT6((T6)Value!);
                    return;
                case 7:
                    matchT7((T7)Value!);
                    return;
                case 8:
                    matchT8((T8)Value!);
                    return;
                case 9:
                    matchT9((T9)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4,
            Func<T5, T> matchT5,
            Func<T6, T> matchT6,
            Func<T7, T> matchT7,
            Func<T8, T> matchT8,
            Func<T9, T> matchT9
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
                case 5:
                    return matchT5((T5)Value!);
                case 6:
                    return matchT6((T6)Value!);
                case 7:
                    return matchT7((T7)Value!);
                case 8:
                    return matchT8((T8)Value!);
                case 9:
                    return matchT9((T9)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
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
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        public Union(T8 value) : base(value, typeof(T8), 8) { }
        public Union(T9 value) : base(value, typeof(T9), 9) { }
        public Union(T10 value) : base(value, typeof(T10), 10) { }
        public bool Is<T>()
        {
            switch(_type)
            {
                case 1:
                    return typeof(T) == typeof(T1);
                case 2:
                    return typeof(T) == typeof(T2);
                case 3:
                    return typeof(T) == typeof(T3);
                case 4:
                    return typeof(T) == typeof(T4);
                case 5:
                    return typeof(T) == typeof(T5);
                case 6:
                    return typeof(T) == typeof(T6);
                case 7:
                    return typeof(T) == typeof(T7);
                case 8:
                    return typeof(T) == typeof(T8);
                case 9:
                    return typeof(T) == typeof(T9);
                case 10:
                    return typeof(T) == typeof(T10);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public void Match(
            Action<T1> matchT1,
            Action<T2> matchT2,
            Action<T3> matchT3,
            Action<T4> matchT4,
            Action<T5> matchT5,
            Action<T6> matchT6,
            Action<T7> matchT7,
            Action<T8> matchT8,
            Action<T9> matchT9,
            Action<T10> matchT10
            )
        {
            switch (_type)
            {
                case 1:
                    matchT1((T1)Value!);
                    return;
                case 2:
                    matchT2((T2)Value!);
                    return;
                case 3:
                    matchT3((T3)Value!);
                    return;
                case 4:
                    matchT4((T4)Value!);
                    return;
                case 5:
                    matchT5((T5)Value!);
                    return;
                case 6:
                    matchT6((T6)Value!);
                    return;
                case 7:
                    matchT7((T7)Value!);
                    return;
                case 8:
                    matchT8((T8)Value!);
                    return;
                case 9:
                    matchT9((T9)Value!);
                    return;
                case 10:
                    matchT10((T10)Value!);
                    return;
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
        public T Match<T>(
            Func<T1, T> matchT1,
            Func<T2, T> matchT2,
            Func<T3, T> matchT3,
            Func<T4, T> matchT4,
            Func<T5, T> matchT5,
            Func<T6, T> matchT6,
            Func<T7, T> matchT7,
            Func<T8, T> matchT8,
            Func<T9, T> matchT9,
            Func<T10, T> matchT10
            )
        {
            switch (_type)
            {
                case 1:
                    return matchT1((T1)Value!);
                case 2:
                    return matchT2((T2)Value!);
                case 3:
                    return matchT3((T3)Value!);
                case 4:
                    return matchT4((T4)Value!);
                case 5:
                    return matchT5((T5)Value!);
                case 6:
                    return matchT6((T6)Value!);
                case 7:
                    return matchT7((T7)Value!);
                case 8:
                    return matchT8((T8)Value!);
                case 9:
                    return matchT9((T9)Value!);
                case 10:
                    return matchT10((T10)Value!);
            }
            throw new InvalidOperationException("Union is in an invalid state");
        }
    }
}
