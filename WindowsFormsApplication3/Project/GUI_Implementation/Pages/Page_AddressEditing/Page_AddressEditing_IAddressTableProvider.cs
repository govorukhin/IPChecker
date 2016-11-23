using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public partial class Page_AddressEditing //IAddressTableProvider
    {
        private BindingList<HostUri> _addresses = new BindingList<HostUri>();
        public BindingList<HostUri> Addresses
        {
            get
            {
                ClearSelectionInDataGridView();
                return _addresses;
            }
        }
        private BindingListView<HostUri> bindingListView;

        
        private void Initialize_IAddressTableProvider()
        {
            bindingListView = new BindingListView<HostUri>(Addresses);
            dataGridView1.DataSource = bindingListView;
        }

        private void ClearSelectionInDataGridView()
        {
            // очищаем выделение для борьбы с паразитной пустой строкой
            // возниающий при добавленнии новых элементов
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }
    }
}
