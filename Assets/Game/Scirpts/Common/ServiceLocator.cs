using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        if(!services.ContainsKey(typeof(T)))
        {
            services.Add(typeof(T), service);
        }
    }

    public static bool TryGet<T>()
    {
        if(services.ContainsKey(typeof(T))) return true;

        return false;
    }
    public static T Get<T>()
    {
        return (T)services[typeof(T)];
    }

    public static void Clear()
    {
        services.Clear();
    }
}

public interface IService
{
    public void Execute();
}
