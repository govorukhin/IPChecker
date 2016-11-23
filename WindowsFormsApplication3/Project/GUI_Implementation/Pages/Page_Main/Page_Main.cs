using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Page_Main : UserControl, IViewerPages
    {
        private Control page_AddressEditing;
        private Control page_AddressChecking;
        

        public Page_Main(Control page_AddressEditing, Control page_AddressChecking)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.page_AddressEditing = page_AddressEditing;
            this.page_AddressChecking = page_AddressChecking;
                       
            Controls.Add(page_AddressEditing);
            page_AddressEditing.Show();
            Controls.Add(page_AddressChecking);
            page_AddressEditing.Show();
            Show_PageAddressEditing();
        }


        public void Show_PageAddressChecking()
        {
            page_AddressChecking.BringToFront();                   
        }

        public void Show_PageAddressEditing()
        {
            page_AddressEditing.BringToFront();                     
        }
    }
}
