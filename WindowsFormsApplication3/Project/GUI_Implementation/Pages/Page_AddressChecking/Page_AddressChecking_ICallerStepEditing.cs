using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressChecking // ICallerStepEditing
    {        
        public event Action StepEditing_required = delegate { };
        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            StepEditing_required();
        }
    }
}
