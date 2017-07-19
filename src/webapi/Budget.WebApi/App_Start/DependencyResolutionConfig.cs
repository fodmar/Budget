using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Budget.WebApi.DependencyResolution;
using Budget.WebApi.Filters;
using Newtonsoft.Json;
using StructureMap;

namespace Budget.WebApi
{
    public static class DependencyResolutionConfig
    {
        public static void InitializeDependencyResolution(HttpConfiguration config)
        {
            IContainer container = IoC.Initialize();
            config.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}
