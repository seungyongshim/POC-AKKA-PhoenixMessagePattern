using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMessage.ConsoleApp
{
    class DbServerEmulator : IDbServer
    {
        public void Connect()
        {
            ConnectImpl();
        }
        public Action ConnectImpl { get; set; }
    }
}
