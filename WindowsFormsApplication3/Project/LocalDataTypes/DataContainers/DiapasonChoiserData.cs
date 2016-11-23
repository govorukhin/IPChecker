using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class DiapasonChoiserData
    {
        public string Scheme { get; set; }
        public IPAddress IP_From { get; set; }
        public IPAddress IP_To { get; set; }
        public AddressFamily AddressFamily { get; set; }
        public ushort? Port { get; set; }
        public string Path { get; set; }
    }
}
