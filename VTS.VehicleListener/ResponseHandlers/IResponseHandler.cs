using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTS.VehicleListener
{
    public interface IResponseHandler
    {
        string HandleResponse(byte[] response, int responseSize);
    }
}
