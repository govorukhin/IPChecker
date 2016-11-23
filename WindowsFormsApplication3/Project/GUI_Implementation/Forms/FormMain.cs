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
    public partial class FormMain : Form
    {
        public FormMain(Control content)
        {
            InitializeComponent();

            this.Controls.Add(content);
            content.Show();
        }
    }
}
