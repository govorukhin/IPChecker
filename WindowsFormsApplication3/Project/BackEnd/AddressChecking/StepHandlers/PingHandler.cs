using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{    
    public class PingHandler :ITaskHandler_AddressChecking<PingReply, bool>
    {        
        public async Task<bool> HandleAsync(CheckRow checkRow, Task<PingReply> task)
        {
            bool isContinue = false;
            if (task == null)                
                checkRow.ResultPing = StatusChecking.fail;
            else
            {
                try
                {
                    PingReply reply = await task;
                    isContinue = true;                    
                    checkRow.ResultPing = StatusChecking.win;
                }
                catch
                {
                    if (task.IsCanceled)                        
                        checkRow.ResultPing = StatusChecking.canceled;
                    if (task.IsFaulted)
                        checkRow.ResultPing = StatusChecking.fail;
                }
            }
            return isContinue;
        }
    }
}
