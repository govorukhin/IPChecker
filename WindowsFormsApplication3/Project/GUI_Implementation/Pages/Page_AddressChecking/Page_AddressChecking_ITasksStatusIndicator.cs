using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressChecking // ITasksStatusIndicator
    {
        public IProgress<int> Progress { get; private set; }
        private void Initialize_ITasksStatusIndicator()
        {            
            Progress = new Progress<int>((int completedTasksCount) => { TasksCompleted = completedTasksCount; });
        }

        private string _labelSeparator = " из ";
        public string LabelSeparator {
            get { return _labelSeparator; }
            set
            {
                _labelSeparator = value;
                UpdateLabel();
            }
        }
               
        private int tasksCompleted = 0;
        public int TasksCompleted {
            get { return tasksCompleted; }
            set
            {
                tasksCompleted = value;
                UpdateLabel();
            }
        }
        private int tasksTotalCount = 0;
        public int TasksTotalCount {
            get { return tasksTotalCount; }
            set
            {
                tasksTotalCount = value;
                UpdateLabel();
            }
        }    
        
        private void UpdateLabel()
        {
            toolStripLabel2.Text = TasksCompleted.ToString() +
                                   LabelSeparator +
                                   TasksTotalCount.ToString();
        }
    }
}
