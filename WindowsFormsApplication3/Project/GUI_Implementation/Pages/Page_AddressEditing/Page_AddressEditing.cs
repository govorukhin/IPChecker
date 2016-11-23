using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using System.Numerics;
using System.Net;
using System.Net.Sockets;
using TypeExtensions;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressEditing : 
        UserControl, 
        IAddressTableProvider, 
        ICallerStepChecking,
        IAddressEditingPanels
    {        
        public Page_AddressEditing()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            Initialize_IAddressTableProvider();
        }
                                
    }
}