using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace OPCServer1.Backend.Serwer
{
    public interface PlcS7NetLibraryInterface
    {
        ConnectionStatus ConnectionStatus { get; }

        void Connect();

        void Disconnect();

        List<Tag> ReadItems(List<Tag> itemList);

        void ReadClass(object sourceClass, int db);

        void WriteClass(object sourceClass, int db);

        void WriteItems(List<Tag> itemList);

    }
}
