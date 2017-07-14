using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApp.DependencyResolution;
using StructureMap;

namespace Budget.WebApp
{
    public class DependencyResolutionConfig
    {
        public static void InitializeDependencyResolution()
        {
            IContainer container = IoC.Initialize();
            IDependencyResolver dependencyResolver = new StructureMapDependencyResolver(container);

            DependencyResolver.SetResolver(dependencyResolver);
        }
    }
}