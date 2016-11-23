using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressChecking // IResultsTableView
    {
        public Dictionary<StatusChecking, string> StatusCheckingToString { get; set; }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].ValueType == typeof(StatusChecking) &&
                StatusCheckingToString != null)
            {
                StatusChecking value = (StatusChecking)e.Value;
                if (StatusCheckingToString.ContainsKey(value))
                    e.Value = StatusCheckingToString[value];
            }
        }
    }
}
