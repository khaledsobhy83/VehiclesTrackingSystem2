using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTS.StatusListner
{
    public interface IListner
    {
        void Initialize();

        void Start();

        void Stop();

        void Process();
    }
}
