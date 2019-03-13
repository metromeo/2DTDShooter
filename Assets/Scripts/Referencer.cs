using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Referencer {
    static Dictionary<Type, object> refs = new Dictionary<Type, object>();

    public static void Add(Type key, object value)   {
        if (!refs.ContainsKey(key))
            refs.Add(key, value);
    }

    public static T Get<T>() where T : class{
        object ret = null;
        if (refs.TryGetValue(typeof(T), out ret))
            return ret as T;
        return default(T);
    }

    public static void ResetReferences() {
        refs.Clear();
    }

}

