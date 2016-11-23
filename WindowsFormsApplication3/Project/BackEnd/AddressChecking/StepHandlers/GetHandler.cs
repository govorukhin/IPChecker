using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{       
    public class GetHandler : ITaskHandler_AddressChecking<HttpResponseMessage, bool>
    {        
        public async Task<bool> HandleAsync(CheckRow checkRow, Task<HttpResponseMessage> task)
        {
            bool isContinue = false;
            if (task == null)                
                checkRow.ResultGet = StatusChecking.nostartedFinished;
            else
            {
                try
                {
                    HttpResponseMessage reply = await task;
                    isContinue = true;                    
                    checkRow.ResultGet = StatusChecking.win;
                }
                catch
                {
                    if (task.IsCanceled)                        
                        checkRow.ResultGet = StatusChecking.canceled;
                    if (task.IsFaulted)                        
                        checkRow.ResultGet = StatusChecking.fail;
                }
            }
            return isContinue;
        }
    }
}
