using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    partial class Page_AddressEditing // ICallerStepChecking
    {
        public event Action StepAddressChecking_required = delegate { };

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            StepAddressChecking_required();
        }
    }
}
