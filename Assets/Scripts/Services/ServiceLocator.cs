using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> listServices = new Dictionary<Type, object>();

    public static void RegisterService<Service>(Service service)
    {
        if (!listServices.ContainsKey(typeof(Service))) listServices.Add(typeof(Service), service);
    }

    public static Service GetService<Service>()
    {
        if (listServices.ContainsKey(typeof(Service)))
            return (Service)listServices[typeof(Service)];
        else
        {
            throw new Exception();
        }
    }
}