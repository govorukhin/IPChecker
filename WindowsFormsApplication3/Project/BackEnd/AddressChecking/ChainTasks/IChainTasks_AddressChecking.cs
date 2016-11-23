using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public interface IChainTasks_AddressChecking
    {
        Task CheckAddressAsync(CheckRow checkRow, CancellationToken cancelToken);
    }
}