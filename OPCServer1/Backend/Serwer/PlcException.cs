using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCServer1.Backend.Serwer
{
    class PlcException : Exception
    {

        public ErrorCode Error { get; private set; }

        public PlcException(ErrorCode codeErr)
        {
            this.Error = codeErr;
        }

    }
}
