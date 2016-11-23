using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    partial class Page_AddressEditing //IAddressEditingPanels 
    {
        public event Action DiapasonChoiseRequired = delegate { };
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DiapasonChoiseRequired();
        }

        public event Action RandomIPChoiseRequired = delegate { };
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            RandomIPChoiseRequired();
        }

        public event Action LoadRequired = delegate { };
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadRequired();
        }
        public event Action SaveRequired = delegate { };
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveRequired();
        }
    }
}
