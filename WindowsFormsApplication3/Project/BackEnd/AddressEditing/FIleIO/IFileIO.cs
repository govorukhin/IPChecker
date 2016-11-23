using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface IFileIO
    {
        List<HostUri> ReadListAddress(string filePath);
        void WriteListAddress(string filePath, HostUri[] adresses);
    }
}
