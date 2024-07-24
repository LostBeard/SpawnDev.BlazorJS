using System.Reflection;

namespace SpawnDev.BlazorJS.DTO;
public static class ReflectionMapper
{
    static Dictionary<Type, Dictionary<string, PropertyInfo>> _typeProperties = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

    static Dictionary<string, PropertyInfo> GetTypeProperties(Type type)
    {
        lock (_typeProperties)
        {
            if (_typeProperties.TryGetValue(type, out Dictionary<string, PropertyInfo>? fnd)) return fnd;
            var ret = new Dictionary<string, PropertyInfo>();
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in props) ret.Add(p.Name, p);
            _typeProperties.Add(type, ret);
            return ret;
        }
    }

    public static void Map<TSource, TResult>(TSource source, TResult target, Func<PropertyInfo, bool>? shouldCopyCallback = null) where TResult : class
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (target == null) throw new ArgumentNullException(nameof(target));
        var typeSource = typeof(TSource);
        var typeResult = typeof(TResult);
        var propsSource = GetTypeProperties(typeSource);
        var propsResult = GetTypeProperties(typeResult);
        foreach (var prop in propsSource.Values)
        {
            if (!propsResult.TryGetValue(prop.Name, out PropertyInfo? propSource)) continue;
            var shouldCopy = shouldCopyCallback == null || shouldCopyCallback(prop);
            if (!shouldCopy) continue;
            prop.SetValue(target, propSource.GetValue(source));
        }
    }

    public static TResult Map<TSource, TResult>(TSource source, Func<PropertyInfo, bool>? shouldCopyCallback = null) where TResult : class
    {
        var typeResult = typeof(TResult);
        var targetItem = (TResult)Activator.CreateInstance(typeResult)!;
        Map<TSource, TResult>(source, targetItem, shouldCopyCallback);
        return targetItem;
    }

    public static List<TResult> Map<TSource, TResult>(IEnumerable<TSource> sourceList, Func<PropertyInfo, bool>? shouldCopyCallback = null) where TResult : class
    {
        var typeSource = typeof(TSource);
        var typeResult = typeof(TResult);
        var propsSource = GetTypeProperties(typeSource);
        var propsResult = GetTypeProperties(typeResult);
        var ret = new List<TResult>();
        foreach(var sourceItem in sourceList)
        {
            var targetItem = (TResult)Activator.CreateInstance(typeResult)!;
            Map<TSource, TResult>(sourceItem, targetItem, shouldCopyCallback);
            ret.Add(targetItem);
        }
        return ret;
    }

    public static void MapFromBaseClass<TSource, TResult>(TSource source, TResult target, Func<PropertyInfo, bool>? shouldCopyCallback = null) where TResult : TSource
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (target == null) throw new ArgumentNullException(nameof(target));
        var typeSource = typeof(TSource);
        var typeResult = typeof(TResult);
        var propsSource = GetTypeProperties(typeSource);
        var propsResult = GetTypeProperties(typeResult);
        foreach (var prop in propsSource.Values)
        {
            if (!propsResult.TryGetValue(prop.Name, out PropertyInfo? propSource)) continue;
            var shouldCopy = shouldCopyCallback == null || shouldCopyCallback(prop);
            if (!shouldCopy) continue;
            prop.SetValue(target, propSource.GetValue(source));
        }
    }

    public static TResult MapFromBaseClass<TSource, TResult>(TSource source, Func<PropertyInfo, bool>? shouldCopyCallback = null) where TResult : TSource
    {
        var typeResult = typeof(TResult);
        var targetItem = (TResult)Activator.CreateInstance(typeResult)!;
        MapFromBaseClass<TSource, TResult>(source, targetItem, shouldCopyCallback);
        return targetItem;
    }

    public static List<TResult> MapFromBaseClass<TSource, TResult>(IEnumerable<TSource> sourceList, Func<PropertyInfo, bool>? shouldCopyCallback = null) where TResult : TSource
    {
        var typeSource = typeof(TSource);
        var typeResult = typeof(TResult);
        var propsSource = GetTypeProperties(typeSource);
        var propsResult = GetTypeProperties(typeResult);
        var ret = new List<TResult>();
        foreach (var sourceItem in sourceList)
        {
            var targetItem = (TResult)Activator.CreateInstance(typeResult)!;
            MapFromBaseClass<TSource, TResult>(sourceItem, targetItem, shouldCopyCallback);
            ret.Add(targetItem);
        }
        return ret;
    }
}
