using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TypeAddons;
using TypeExtensions;

namespace WindowsFormsApplication3
{
    public class AddressGenerator : IAddressGenerator
    {
        public Random Random { get; set; } = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);


        public HostUri CreateRandom_HostUri(DiapasonChoiserData diapason)
        {
            IPAddress ip = IPAddressOperations.CreateRandomIP(Random, diapason.IP_From, diapason.IP_To);
            string host = ip.ToString();
            HostUri result = new HostUri()
            {
                Host = host,
                Uri = CreateUri(diapason.Scheme, host, diapason.Port, diapason.Path, diapason.AddressFamily)
            };

            return result;
        }
        
        public BindingList<HostUri> CreateList_HostUri(DiapasonChoiserData diapason)
        {
            BindingList<HostUri> result = new BindingList<HostUri>();            
            IPAddress[] ips = IPAddressOperations.CreateDiapasonIP(diapason.IP_From, diapason.IP_To);
            foreach (IPAddress ip in ips)
            {
                string host = ip.ToString();
                result.Add(new HostUri() {
                    Host = host,
                    Uri = CreateUri(diapason.Scheme, host, diapason.Port, diapason.Path, diapason.AddressFamily)
                });
            }
            return result;
        }





        private string CreateUri(string scheme, string host, ushort? port, string path, AddressFamily ipver)
        {            
            string result = (ipver == AddressFamily.InterNetwork)
                //ipv4
                ? scheme + 
                  "://" + 
                  host +  
                  ((port != null) ? ":" + port.Value.ToString() : "") +
                  path
                //ipv6
                : scheme +
                  "://" +
                  "[" + host + "]" +
                  ((port != null) ? ":" + port.Value.ToString() : "") +
                  path;
            return result;
        }
    }
}
