using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface IDiapasonAddressChanger
    {
        event Action<DiapasonChoiserData> AddingAdresses_Required;
        event Action<DiapasonChoiserData> RemovingAdresses_Required;
    }
}
