using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using VTS.Repository;
using VTS.BL;
namespace VTS.DependencyInjectionRegister
{
    /// <summary>
    /// Dependency injection implementation using autofac library
    /// </summary>
    public class ServiceRegistry
    {
        /// <summary>
        /// Cerntal method to register the mapping of interfaces and thier implementation
        /// </summary>
        /// <param name="builder">Autofac Container builder</param>
        /// <returns>Return instance of Autofac Container builder with registered services</returns>
        public static ContainerBuilder Register(ContainerBuilder builder)
        {

            #region Repositories

            builder.RegisterType<VehicleRepository>().As<IVehicleRepository>().InstancePerLifetimeScope();

            #endregion

            #region Managers

            builder.RegisterType<VehiclesManager>().As<IVehiclesManager>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerManager>().As<ICustomerManager>().InstancePerLifetimeScope();

            #endregion

            return builder;
        }
    }
}
