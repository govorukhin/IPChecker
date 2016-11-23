using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface ICheckingControlPanel
    {
        bool IsRun { get; set; }
        event Action IsRun_Changed;
    }
}
