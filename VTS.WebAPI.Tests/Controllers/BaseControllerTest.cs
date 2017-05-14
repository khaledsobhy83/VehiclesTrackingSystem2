using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VTS.WebAPI;
using VTS.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using VTS.DependencyInjectionRegister;
using VTS.BL;

namespace VTS.WebAPI.Tests.Controllers
{
    [TestClass]
    public class BaseControllerTest
    {
        protected IVehiclesManager vehiclesManager;
        public BaseControllerTest()
        {
            //Dependency injection configuration
            var builder = new ContainerBuilder();

            builder = ServiceRegistry.Register(builder);

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                vehiclesManager = scope.Resolve<IVehiclesManager>();
            }
        }
    }
}
