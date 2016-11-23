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

namespace WindowsFormsApplication3
{    
    public partial class Page_AddressChecking : 
        UserControl,
        IResultsTableProvider,
        ICallerStepEditing,
        ICheckingControlPanel,
        ITasksStatusIndicator,
        IResultsTableView
    {                         
        public Page_AddressChecking()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            Initialize_IResultsTableProvider();
            Initialize_ITasksStatusIndicator();
            Initialize_ICheckingControlPanel();
        }
    }
}
