using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVC_all.Comp;

namespace MVC_all.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryDBComp>().As<IDBComp>().SingleInstance();
            var container = builder.Build();
            
            var innerResolver = new AutofacDependencyResolver(container);
            //var derivedResolver = new DerivedAutofacDependencyResolver(container, innerResolver);
            // DependencyResolver.SetResolver(derivedResolver);
            DependencyResolver.SetResolver(innerResolver);
        }

    }

    //public class DerivedAutofacDependencyResolver : AutofacDependencyResolver, IDependencyResolver
    //{
    //    readonly AutofacDependencyResolver _dependencyResolver;

    //    public DerivedAutofacDependencyResolver(IContainer container, AutofacDependencyResolver dependencyResolver)
    //        : base(container)
    //    {
    //        _dependencyResolver = dependencyResolver;
    //    }

    //    object IDependencyResolver.GetService(Type serviceType)
    //    {
    //        return _dependencyResolver.GetService(serviceType);
    //    }

    //    IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
    //    {
    //        return _dependencyResolver.GetServices(serviceType);
    //    }
    //}
}