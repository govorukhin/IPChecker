using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface IResultsTableProvider
    {
        BindingList<CheckRow> CheckRows { get; set; }        
        event Action CheckRowsChanged;
    }
}
