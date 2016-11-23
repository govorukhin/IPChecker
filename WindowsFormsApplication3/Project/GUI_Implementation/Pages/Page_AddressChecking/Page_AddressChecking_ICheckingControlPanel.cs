using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressChecking // ICheckingControlPanel
    {        
        private void Initialize_ICheckingControlPanel()
        {
            UnBlockPanel();
        }

        public event Action IsRun_Changed = delegate { };
        private bool isRun = false;
        public bool IsRun
        {
            get { return isRun; }
            set
            {
                isRun = value;
                if (isRun)                
                    BlockPanel();                                    
                else
                    UnBlockPanel();
                IsRun_Changed();
            }
        }


        private void BlockPanel()
        {
            toolStripButton_Check.Enabled = false;
            toolStripButton_Cancel.Enabled = true;
            toolStripButton_Edit.Enabled = false;
        }
        private void UnBlockPanel()
        {
            toolStripButton_Check.Enabled = true;
            toolStripButton_Cancel.Enabled = false;
            toolStripButton_Edit.Enabled = true;
        }


        private void toolStripButton_Check_Click(object sender, EventArgs e)
        {
            IsRun = true;
        }

        private void toolStripButton_Cancel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IsRun = false;
            Cursor.Current = Cursors.Default;
        }

    }
}
