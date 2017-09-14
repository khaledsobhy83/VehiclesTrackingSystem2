using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace VTS.Testing.DatabaseMocking
{
    public class EffortManager
    {
        public EffortManager()
        {
            builder.RegisterType<DbContext>().As<ICustomerRepository>().InstancePerLifetimeScope();
        }
    }
    }
}
