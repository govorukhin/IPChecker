using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TypeExtensions;

namespace WindowsFormsApplication3
{
    public interface IAddressGenerator
    {
        HostUri CreateRandom_HostUri(DiapasonChoiserData diapason);
        BindingList<HostUri> CreateList_HostUri(DiapasonChoiserData diapason);
    }
}
