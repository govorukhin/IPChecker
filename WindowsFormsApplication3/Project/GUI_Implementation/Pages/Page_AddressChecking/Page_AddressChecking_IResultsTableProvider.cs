using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressChecking // IResultsTableProvider
    {
        public event Action CheckRowsChanged = delegate { };
        private BindingList<CheckRow> _checkRows = new BindingList<CheckRow>();
        public BindingList<CheckRow> CheckRows
        {
            get { return _checkRows; }
            set
            {
                _checkRows = value;
                bindingListView.DataSource = _checkRows;
                CheckRowsChanged();
            }
        }

        private BindingListView<CheckRow> bindingListView;
        private void Initialize_IResultsTableProvider()
        {
            bindingListView = new BindingListView<CheckRow>(CheckRows);
            dataGridView1.DataSource = bindingListView;
        }
    }
}
