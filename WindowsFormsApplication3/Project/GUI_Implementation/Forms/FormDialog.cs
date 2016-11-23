using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class FormDialog : Form
    {        
        public FormDialog(Control content)
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(content, 0, 0);
        }
    }
}
