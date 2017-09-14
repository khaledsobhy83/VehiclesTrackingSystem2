using Effort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Data.Sql;

namespace VTS.Test
{
    public class VTSModelFakeConnection : VTSModel
    {
        public VTSModelFakeConnection(): base(DbConnectionFactory.CreateTransient())
        {

        }
    }
}
