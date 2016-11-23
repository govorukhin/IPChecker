using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class DefaultStatusCheckingToString : Dictionary<StatusChecking, string>
    {
        public DefaultStatusCheckingToString()
        {
            Add(StatusChecking.nostarted, "");
            Add(StatusChecking.nostartedFinished, "---");
            Add(StatusChecking.fail, "fail");
            Add(StatusChecking.canceled, "canceled");
            Add(StatusChecking.win, "win");
        }
    }
}
