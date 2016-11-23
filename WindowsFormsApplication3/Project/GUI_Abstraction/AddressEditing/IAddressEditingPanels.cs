using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface IAddressEditingPanels
    {
        event Action DiapasonChoiseRequired;
        event Action RandomIPChoiseRequired;
        event Action LoadRequired;
        event Action SaveRequired;
    }
}