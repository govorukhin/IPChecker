using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    /// <summary>
    /// Запускает проверку всех адресов в целом. 
    /// Т.е. конкретные checkRows он не обрабатывает. 
    /// 
    /// Почему отмена не cancelTokenом?
    /// Чтобы не было смысла заключать RunCheckingAsync в try.
    /// Т.к. этот таск просто ждёт выполнения подтасков, и не должен знать об их результатах.    
    /// </summary>
    public interface ICheckManager
    {
        Task RunCheckingAsync(BindingList<CheckRow> checkRows, IProgress<int> progress);
        void CancelCheckingAsync();
    }
}