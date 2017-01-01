using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.StockExchange.Mapping
{
    public static class AutoMapperProfiles
    {
        public static IEnumerable<Profile> Get() =>
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(a =>
                a.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>());
    }
}