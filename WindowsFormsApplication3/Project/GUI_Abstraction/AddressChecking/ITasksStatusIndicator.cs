using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface ITasksStatusIndicator
    {
        IProgress<int> Progress { get; }
        int TasksCompleted { get; set; }
        int TasksTotalCount { get; set; }
        string LabelSeparator { get; set; }
    }
}
