using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using VTS.DependencyInjectionRegister;
using VTS.BL;

namespace VTS.Test
{
    public class TestBase
    {
        protected IVehiclesManager vehiclesManager;
        public TestBase()
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
