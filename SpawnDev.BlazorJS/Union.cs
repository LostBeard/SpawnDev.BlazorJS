using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Union type
    /// </summary>
    public abstract class Union
    {
        /// <summary>
        /// Invalid state message
        /// </summary>
        protected const string InvalidStateMessage = "Union is in an invalid state";
        /// <summary>
        /// The type index of the value contained in the union
        /// </summary>
        protected byte _type { get; }
        /// <summary>
        /// The value contained in the union
        /// </summary>
        public object? Value { get; }
        /// <summary>
        /// The type of the value contained in the union
        /// </summary>
        public Type ValueType { get; }
        /// <summary>
        /// New union instance
        /// </summary>
        protected Union(object? value, Type valueType, byte type)
        {
            Value = value;
            ValueType = valueType;
            _type = type;
        }
        /// <inheritdoc/>
        public override string ToString() => Value?.ToString() ?? "null";
        /// <summary>
        /// Returns true if the union contains the specified type
        /// </summary>
        public bool Is<T>() => typeof(T) == ValueType;
        /// <summary>
        /// Returns true if the union contains the specified type
        /// </summary>
        public bool Is<T>(out T value)
        {
            if (typeof(T) == ValueType)
            {
                value = (T)Value!;
                return true;
            }
            value = default(T)!;
            return false;
        }
        /// <summary>
        /// Returns true if the union contains the specified type
        /// </summary>
        public bool Is(Type type) => type == ValueType;
        /// <summary>
        /// If the Value is T, Value is returned as T, else default(T) is returned.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <returns>Value as T if Value is type T</returns>
        public T As<T>() => Value is T t ? t : default(T)!;
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2>(T1 instance) => instance == null ? null! : new Union<T1, T2>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2>(T2 instance) => instance == null ? null! : new Union<T1, T2>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2> Map(Func<T1, Union<T1, T2>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2> Map(Func<T2, Union<T1, T2>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2>> MapAsync(Func<T1, Task<Union<T1, T2>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2>> MapAsync(Func<T2, Task<Union<T1, T2>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2> Map<TResult>(Func<T1, Union<TResult, T2>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult> Map<TResult>(Func<T2, Union<T1, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2>>((T2)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult>>((T1)Value!);
                case 2: return map((T2)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public T2 Reduce(Func<T1, T2> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public T1 Reduce(Func<T2, T1> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<T2> ReduceAsync(Func<T1, Task<T2>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<T2>((T2)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<T1> ReduceAsync(Func<T2, Task<T1>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<T1>((T1)Value!);
                case 2: return map((T2)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3> Map(Func<T1, Union<T1, T2, T3>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3> Map(Func<T2, Union<T1, T2, T3>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3> Map(Func<T3, Union<T1, T2, T3>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3>> MapAsync(Func<T1, Task<Union<T1, T2, T3>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3>> MapAsync(Func<T2, Task<Union<T1, T2, T3>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3>> MapAsync(Func<T3, Task<Union<T1, T2, T3>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3> Map<TResult>(Func<T1, Union<TResult, T2, T3>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3> Map<TResult>(Func<T2, Union<T1, TResult, T3>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult> Map<TResult>(Func<T3, Union<T1, T2, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3>>((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3>>((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult>>((T2)Value!);
                case 3: return map((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3> Reduce(Func<T1, Union<T2, T3>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3> Reduce(Func<T2, Union<T1, T3>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2> Reduce(Func<T3, Union<T1, T2>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3>> ReduceAsync(Func<T1, Task<Union<T2, T3>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3>>((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3>> ReduceAsync(Func<T2, Task<Union<T1, T3>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3>>((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2>> ReduceAsync(Func<T3, Task<Union<T1, T2>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2>>((T2)Value!);
                case 3: return map((T3)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4> Map(Func<T1, Union<T1, T2, T3, T4>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4> Map(Func<T2, Union<T1, T2, T3, T4>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4> Map(Func<T3, Union<T1, T2, T3, T4>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4> Map(Func<T4, Union<T1, T2, T3, T4>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4>>((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4>>((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4>>((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult>>((T3)Value!);
                case 4: return map((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4> Reduce(Func<T1, Union<T2, T3, T4>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4> Reduce(Func<T2, Union<T1, T3, T4>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4> Reduce(Func<T3, Union<T1, T2, T4>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3> Reduce(Func<T4, Union<T1, T2, T3>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4>>((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4>>((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4>>((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3>>((T3)Value!);
                case 4: return map((T4)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4, T5> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4, T5> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4, T5> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4, T5> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4, T5> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T5(Union<T1, T2, T3, T4, T5> instance) => instance._type == 5 ? (T5)instance.Value! : default(T5)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5>(T5 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5> Map(Func<T1, Union<T1, T2, T3, T4, T5>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5> Map(Func<T2, Union<T1, T2, T3, T4, T5>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5> Map(Func<T3, Union<T1, T2, T3, T4, T5>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5> Map(Func<T4, Union<T1, T2, T3, T4, T5>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5> Map(Func<T5, Union<T1, T2, T3, T4, T5>> map) => _type == 5 ? map((T5)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4, T5>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4, T5>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4, T5>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4, T5>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5>> MapAsync(Func<T5, Task<Union<T1, T2, T3, T4, T5>>> map) => _type == 5 ? map((T5)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4, T5> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4, T5> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4, T5> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult, T5> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, TResult> Map<TResult>(Func<T5, Union<T1, T2, T3, T4, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4, T5>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4, T5>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4, T5>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<TResult, T2, T3, T4, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4, T5>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4, T5>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4, T5>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, TResult, T3, T4, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4, T5>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4, T5>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4, T5>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, TResult, T4, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult, T5>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult, T5>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult, T5>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult, T5>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, TResult, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, TResult>> MapAsync<TResult>(Func<T5, Task<Union<T1, T2, T3, T4, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, TResult>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, TResult>>((T4)Value!);
                case 5: return map((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4, T5> Reduce(Func<T1, Union<T2, T3, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4, T5> Reduce(Func<T2, Union<T1, T3, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4, T5> Reduce(Func<T3, Union<T1, T2, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T5> Reduce(Func<T4, Union<T1, T2, T3, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4> Reduce(Func<T5, Union<T1, T2, T3, T4>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4, T5>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4, T5>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4, T5>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<T2, T3, T4, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4, T5>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4, T5>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4, T5>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T3, T4, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4, T5>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4, T5>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4, T5>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T4, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T5>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T5>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T5>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T5>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T5>>((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4>> ReduceAsync(Func<T5, Task<Union<T1, T2, T3, T4>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4>>((T4)Value!);
                case 5: return map((T5)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4, T5, T6> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4, T5, T6> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4, T5, T6> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4, T5, T6> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4, T5, T6> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T5(Union<T1, T2, T3, T4, T5, T6> instance) => instance._type == 5 ? (T5)instance.Value! : default(T5)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T6(Union<T1, T2, T3, T4, T5, T6> instance) => instance._type == 6 ? (T6)instance.Value! : default(T6)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T5 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T6 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Map(Func<T1, Union<T1, T2, T3, T4, T5, T6>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Map(Func<T2, Union<T1, T2, T3, T4, T5, T6>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Map(Func<T3, Union<T1, T2, T3, T4, T5, T6>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Map(Func<T4, Union<T1, T2, T3, T4, T5, T6>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Map(Func<T5, Union<T1, T2, T3, T4, T5, T6>> map) => _type == 5 ? map((T5)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Map(Func<T6, Union<T1, T2, T3, T4, T5, T6>> map) => _type == 6 ? map((T6)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4, T5, T6>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4, T5, T6>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4, T5, T6>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4, T5, T6>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> MapAsync(Func<T5, Task<Union<T1, T2, T3, T4, T5, T6>>> map) => _type == 5 ? map((T5)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> MapAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T6>>> map) => _type == 6 ? map((T6)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4, T5, T6> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4, T5, T6> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4, T5, T6> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult, T5, T6> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, TResult, T6> Map<TResult>(Func<T5, Union<T1, T2, T3, T4, TResult, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, TResult> Map<TResult>(Func<T6, Union<T1, T2, T3, T4, T5, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4, T5, T6>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4, T5, T6>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4, T5, T6>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult, T5, T6>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, TResult, T6>> MapAsync<TResult>(Func<T5, Task<Union<T1, T2, T3, T4, TResult, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, TResult>> MapAsync<TResult>(Func<T6, Task<Union<T1, T2, T3, T4, T5, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult>>((T5)Value!);
                case 6: return map((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4, T5, T6> Reduce(Func<T1, Union<T2, T3, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4, T5, T6> Reduce(Func<T2, Union<T1, T3, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4, T5, T6> Reduce(Func<T3, Union<T1, T2, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T5, T6> Reduce(Func<T4, Union<T1, T2, T3, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T6> Reduce(Func<T5, Union<T1, T2, T3, T4, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5> Reduce(Func<T6, Union<T1, T2, T3, T4, T5>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4, T5, T6>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4, T5, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4, T5, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<T2, T3, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T2, T3, T4, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4, T5, T6>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4, T5, T6>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4, T5, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T3, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T3, T4, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4, T5, T6>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4, T5, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4, T5, T6>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T4, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T5, T6>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T5, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T5, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T5, T6>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T5, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T6>> ReduceAsync(Func<T5, Task<Union<T1, T2, T3, T4, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T6>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T6>>((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5>> ReduceAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5>>((T5)Value!);
                case 6: return map((T6)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4, T5, T6, T7> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T5(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 5 ? (T5)instance.Value! : default(T5)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T6(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 6 ? (T6)instance.Value! : default(T6)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T7(Union<T1, T2, T3, T4, T5, T6, T7> instance) => instance._type == 7 ? (T7)instance.Value! : default(T7)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T5 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T6 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T7 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T1, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T2, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T3, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T4, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T5, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 5 ? map((T5)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T6, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 6 ? map((T6)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Map(Func<T7, Union<T1, T2, T3, T4, T5, T6, T7>> map) => _type == 7 ? map((T7)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T5, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 5 ? map((T5)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 6 ? map((T6)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> MapAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map) => _type == 7 ? map((T7)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4, T5, T6, T7> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4, T5, T6, T7> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4, T5, T6, T7> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult, T5, T6, T7> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, TResult, T6, T7> Map<TResult>(Func<T5, Union<T1, T2, T3, T4, TResult, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, TResult, T7> Map<TResult>(Func<T6, Union<T1, T2, T3, T4, T5, TResult, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, TResult> Map<TResult>(Func<T7, Union<T1, T2, T3, T4, T5, T6, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4, T5, T6, T7>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4, T5, T6, T7>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4, T5, T6, T7>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult, T5, T6, T7>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, TResult, T6, T7>> MapAsync<TResult>(Func<T5, Task<Union<T1, T2, T3, T4, TResult, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, TResult, T7>> MapAsync<TResult>(Func<T6, Task<Union<T1, T2, T3, T4, T5, TResult, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, TResult>> MapAsync<TResult>(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult>>((T6)Value!);
                case 7: return map((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4, T5, T6, T7> Reduce(Func<T1, Union<T2, T3, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4, T5, T6, T7> Reduce(Func<T2, Union<T1, T3, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4, T5, T6, T7> Reduce(Func<T3, Union<T1, T2, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T5, T6, T7> Reduce(Func<T4, Union<T1, T2, T3, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T6, T7> Reduce(Func<T5, Union<T1, T2, T3, T4, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T7> Reduce(Func<T6, Union<T1, T2, T3, T4, T5, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6> Reduce(Func<T7, Union<T1, T2, T3, T4, T5, T6>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4, T5, T6, T7>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4, T5, T6, T7>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4, T5, T6, T7>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T5, T6, T7>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T6, T7>> ReduceAsync(Func<T5, Task<Union<T1, T2, T3, T4, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T7>> ReduceAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7>>((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6>> ReduceAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6>>((T6)Value!);
                case 7: return map((T7)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4, T5, T6, T7, T8> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T5(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 5 ? (T5)instance.Value! : default(T5)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T6(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 6 ? (T6)instance.Value! : default(T6)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T7(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 7 ? (T7)instance.Value! : default(T7)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T8(Union<T1, T2, T3, T4, T5, T6, T7, T8> instance) => instance._type == 8 ? (T8)instance.Value! : default(T8)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T5 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T6 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T7 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T8 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T8 value) : base(value, typeof(T8), 8) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T1, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T2, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T3, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T4, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T5, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 5 ? map((T5)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T6, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 6 ? map((T6)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T7, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 7 ? map((T7)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Map(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map) => _type == 8 ? map((T8)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T5, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 5 ? map((T5)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 6 ? map((T6)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 7 ? map((T7)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> MapAsync(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map) => _type == 8 ? map((T8)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4, T5, T6, T7, T8> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4, T5, T6, T7, T8> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4, T5, T6, T7, T8> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult, T5, T6, T7, T8> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, TResult, T6, T7, T8> Map<TResult>(Func<T5, Union<T1, T2, T3, T4, TResult, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, TResult, T7, T8> Map<TResult>(Func<T6, Union<T1, T2, T3, T4, T5, TResult, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, TResult, T8> Map<TResult>(Func<T7, Union<T1, T2, T3, T4, T5, T6, TResult, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, TResult> Map<TResult>(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return map((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4, T5, T6, T7, T8>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4, T5, T6, T7, T8>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4, T5, T6, T7, T8>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult, T5, T6, T7, T8>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, TResult, T6, T7, T8>> MapAsync<TResult>(Func<T5, Task<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, TResult, T7, T8>> MapAsync<TResult>(Func<T6, Task<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, TResult, T8>> MapAsync<TResult>(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T6)Value!);
                case 7: return map((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, TResult>> MapAsync<TResult>(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult>>((T7)Value!);
                case 8: return map((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4, T5, T6, T7, T8> Reduce(Func<T1, Union<T2, T3, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4, T5, T6, T7, T8> Reduce(Func<T2, Union<T1, T3, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4, T5, T6, T7, T8> Reduce(Func<T3, Union<T1, T2, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T5, T6, T7, T8> Reduce(Func<T4, Union<T1, T2, T3, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T6, T7, T8> Reduce(Func<T5, Union<T1, T2, T3, T4, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T7, T8> Reduce(Func<T6, Union<T1, T2, T3, T4, T5, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T8> Reduce(Func<T7, Union<T1, T2, T3, T4, T5, T6, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
                case 8: return (T8)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7> Reduce(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return map((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4, T5, T6, T7, T8>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4, T5, T6, T7, T8>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4, T5, T6, T7, T8>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T5, T6, T7, T8>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T6, T7, T8>> ReduceAsync(Func<T5, Task<Union<T1, T2, T3, T4, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T7, T8>> ReduceAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T8>> ReduceAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T6)Value!);
                case 7: return map((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8>>((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7>> ReduceAsync(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7>>((T7)Value!);
                case 8: return map((T8)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T5(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 5 ? (T5)instance.Value! : default(T5)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T6(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 6 ? (T6)instance.Value! : default(T6)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T7(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 7 ? (T7)instance.Value! : default(T7)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T8(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 8 ? (T8)instance.Value! : default(T8)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T9(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> instance) => instance._type == 9 ? (T9)instance.Value! : default(T9)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T8 value) : base(value, typeof(T8), 8) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T9 value) : base(value, typeof(T9), 9) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }

        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T1, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T2, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T3, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T4, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T5, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 5 ? map((T5)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T6, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 6 ? map((T6)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T7, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 7 ? map((T7)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 8 ? map((T8)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Map(Func<T9, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map) => _type == 9 ? map((T9)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T5, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 5 ? map((T5)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 6 ? map((T6)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 7 ? map((T7)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 8 ? map((T8)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync(Func<T9, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map) => _type == 9 ? map((T9)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9> Map<TResult>(Func<T5, Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9> Map<TResult>(Func<T6, Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9> Map<TResult>(Func<T7, Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9> Map<TResult>(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return map((T8)Value!);
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Map<TResult>(Func<T9, Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return map((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>> MapAsync<TResult>(Func<T5, Task<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>> MapAsync<TResult>(Func<T6, Task<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>> MapAsync<TResult>(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T6)Value!);
                case 7: return map((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>> MapAsync<TResult>(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T7)Value!);
                case 8: return map((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> MapAsync<TResult>(Func<T9, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>((T8)Value!);
                case 9: return map((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4, T5, T6, T7, T8, T9> Reduce(Func<T1, Union<T2, T3, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4, T5, T6, T7, T8, T9> Reduce(Func<T2, Union<T1, T3, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4, T5, T6, T7, T8, T9> Reduce(Func<T3, Union<T1, T2, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T5, T6, T7, T8, T9> Reduce(Func<T4, Union<T1, T2, T3, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T6, T7, T8, T9> Reduce(Func<T5, Union<T1, T2, T3, T4, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T7, T8, T9> Reduce(Func<T6, Union<T1, T2, T3, T4, T5, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T8, T9> Reduce(Func<T7, Union<T1, T2, T3, T4, T5, T6, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T9> Reduce(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return map((T8)Value!);
                case 9: return (T9)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8> Reduce(Func<T9, Union<T1, T2, T3, T4, T5, T6, T7, T8>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return map((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4, T5, T6, T7, T8, T9>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4, T5, T6, T7, T8, T9>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4, T5, T6, T7, T8, T9>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T5, T6, T7, T8, T9>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T6, T7, T8, T9>> ReduceAsync(Func<T5, Task<Union<T1, T2, T3, T4, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T7, T8, T9>> ReduceAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T8, T9>> ReduceAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T6)Value!);
                case 7: return map((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T9>> ReduceAsync(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T7)Value!);
                case 8: return map((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9>>((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>> ReduceAsync(Func<T9, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8>>((T8)Value!);
                case 9: return map((T9)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
    /// <summary>
    /// Union type
    /// </summary>
    [JsonConverter(typeof(UnionJsonConverter))]
    public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : Union
    {
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T1(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 1 ? (T1)instance.Value! : default(T1)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T2(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 2 ? (T2)instance.Value! : default(T2)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T3(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 3 ? (T3)instance.Value! : default(T3)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T4(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 4 ? (T4)instance.Value! : default(T4)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T5(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 5 ? (T5)instance.Value! : default(T5)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T6(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 6 ? (T6)instance.Value! : default(T6)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T7(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 7 ? (T7)instance.Value! : default(T7)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T8(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 8 ? (T8)instance.Value! : default(T8)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T9(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 9 ? (T9)instance.Value! : default(T9)!;
        /// <summary>
        /// Conversion operators for each type in the union.<br/>
        /// If the Union contains a value of the specified type, returns that value, otherwise returns the default value of the specified type.
        /// </summary>
        public static explicit operator T10(Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> instance) => instance._type == 10 ? (T10)instance.Value! : default(T10)!;
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// Conversion operators for each type in the union
        /// </summary>
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 instance) => instance == null ? null! : new Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(instance);
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T1 value) : base(value, typeof(T1), 1) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T2 value) : base(value, typeof(T2), 2) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T3 value) : base(value, typeof(T3), 3) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T4 value) : base(value, typeof(T4), 4) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T5 value) : base(value, typeof(T5), 5) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T6 value) : base(value, typeof(T6), 6) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T7 value) : base(value, typeof(T7), 7) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T8 value) : base(value, typeof(T8), 8) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T9 value) : base(value, typeof(T9), 9) { }
        /// <summary>
        /// New union instance
        /// </summary>
        public Union(T10 value) : base(value, typeof(T10), 10) { }
        /// <summary>
        /// Runs an action based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a value based on the type contained in the union
        /// </summary>
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
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #region Map
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T1, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 1 ? map((T1)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T2, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 2 ? map((T2)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T3, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 3 ? map((T3)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T4, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 4 ? map((T4)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T5, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 5 ? map((T5)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T6, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 6 ? map((T6)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T7, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 7 ? map((T7)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 8 ? map((T8)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T9, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 9 ? map((T9)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map(Func<T10, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map) => _type == 10 ? map((T10)Value!) : this;
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T1, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 1 ? map((T1)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T2, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 2 ? map((T2)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T3, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 3 ? map((T3)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T4, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 4 ? map((T4)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T5, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 5 ? map((T5)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 6 ? map((T6)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 7 ? map((T7)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 8 ? map((T8)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T9, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 9 ? map((T9)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync(Func<T10, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map) => _type == 10 ? map((T10)Value!) : Task.FromResult(this);
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10> Map<TResult>(Func<T1, Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10> Map<TResult>(Func<T2, Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10> Map<TResult>(Func<T3, Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10> Map<TResult>(Func<T4, Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10> Map<TResult>(Func<T5, Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10> Map<TResult>(Func<T6, Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10> Map<TResult>(Func<T7, Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10> Map<TResult>(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return map((T8)Value!);
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10> Map<TResult>(Func<T9, Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return map((T9)Value!);
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Map<TResult>(Func<T10, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return map((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync<TResult>(Func<T1, Task<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>> MapAsync<TResult>(Func<T2, Task<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>> MapAsync<TResult>(Func<T3, Task<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>> MapAsync<TResult>(Func<T4, Task<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>> MapAsync<TResult>(Func<T5, Task<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>> MapAsync<TResult>(Func<T6, Task<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>> MapAsync<TResult>(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T6)Value!);
                case 7: return map((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>> MapAsync<TResult>(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T7)Value!);
                case 8: return map((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>> MapAsync<TResult>(Func<T9, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T8)Value!);
                case 9: return map((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Returns a Union
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> MapAsync<TResult>(Func<T10, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>((T9)Value!);
                case 10: return map((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
        #region Reduce
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T2, T3, T4, T5, T6, T7, T8, T9, T10> Reduce(Func<T1, Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T3, T4, T5, T6, T7, T8, T9, T10> Reduce(Func<T2, Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return map((T2)Value!);
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T4, T5, T6, T7, T8, T9, T10> Reduce(Func<T3, Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return map((T3)Value!);
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T5, T6, T7, T8, T9, T10> Reduce(Func<T4, Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return map((T4)Value!);
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T6, T7, T8, T9, T10> Reduce(Func<T5, Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return map((T5)Value!);
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T7, T8, T9, T10> Reduce(Func<T6, Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return map((T6)Value!);
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T8, T9, T10> Reduce(Func<T7, Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return map((T7)Value!);
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T9, T10> Reduce(Func<T8, Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return map((T8)Value!);
                case 9: return (T9)Value!;
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T10> Reduce(Func<T9, Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return map((T9)Value!);
                case 10: return (T10)Value!;
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Reduce(Func<T10, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> map)
        {
            switch (_type)
            {
                case 1: return (T1)Value!;
                case 2: return (T2)Value!;
                case 3: return (T3)Value!;
                case 4: return (T4)Value!;
                case 5: return (T5)Value!;
                case 6: return (T6)Value!;
                case 7: return (T7)Value!;
                case 8: return (T8)Value!;
                case 9: return (T9)Value!;
                case 10: return map((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>> ReduceAsync(Func<T1, Task<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return map((T1)Value!);
                case 2: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T2, T3, T4, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>> ReduceAsync(Func<T2, Task<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return map((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T3, T4, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>> ReduceAsync(Func<T3, Task<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return map((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T4, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>> ReduceAsync(Func<T4, Task<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return map((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T5, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>> ReduceAsync(Func<T5, Task<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T4)Value!);
                case 5: return map((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T6, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>> ReduceAsync(Func<T6, Task<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T5)Value!);
                case 6: return map((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T7, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>> ReduceAsync(Func<T7, Task<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T6)Value!);
                case 7: return map((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T8, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>> ReduceAsync(Func<T8, Task<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T7)Value!);
                case 8: return map((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T9, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>> ReduceAsync(Func<T9, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T8)Value!);
                case 9: return map((T9)Value!);
                case 10: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T10>>((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        /// <summary>
        /// Use Reduce to process one of the Union types into another, returning a new Union without the processed type, or the value of the last type if only 1 type remains
        /// </summary>
        public Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>> ReduceAsync(Func<T10, Task<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> map)
        {
            switch (_type)
            {
                case 1: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T1)Value!);
                case 2: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T2)Value!);
                case 3: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T3)Value!);
                case 4: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T4)Value!);
                case 5: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T5)Value!);
                case 6: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T6)Value!);
                case 7: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T7)Value!);
                case 8: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T8)Value!);
                case 9: return Task.FromResult<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((T9)Value!);
                case 10: return map((T10)Value!);
            }
            throw new InvalidOperationException(InvalidStateMessage);
        }
        #endregion
    }
}
