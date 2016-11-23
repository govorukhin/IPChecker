using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TypeAddons;

namespace WindowsFormsApplication3
{
    public class ChainTasks_AddressChecker : IChainTasks_AddressChecking
    {
        private PingCancellation pinger = new PingCancellation();
        private HttpClient httpGetter = new HttpClient();
        private ITaskHandler_AddressChecking<PingReply, bool> handlerPing;
        private ITaskHandler_AddressChecking<HttpResponseMessage, bool> handlerGet;

        public ChainTasks_AddressChecker(ITaskHandler_AddressChecking<PingReply, bool> handlerPing,
                                         ITaskHandler_AddressChecking<HttpResponseMessage, bool> handlerGet)
        {
            this.handlerPing = handlerPing;
            this.handlerGet = handlerGet;
        }

        

        public async Task CheckAddressAsync(CheckRow checkRow, CancellationToken cancelToken)
        {
            Task<PingReply> pingTask = null;
            try { pingTask = pinger.SendPingAsync(checkRow.Host, cancelToken); } catch { }; // Эта странная конструкция на этой строке возведена из-за того что при пинге 0.0.0.2 или ::2 происходит null exception который не хочет дожидаться, пока таск будет затащен в ближайший try. Остальные исключение обрабатываются в хандлерах.
            if (await handlerPing.HandleAsync(checkRow, pingTask) & !cancelToken.IsCancellationRequested) // если ни ошибок в пинге, ни отмены не произошло, совершаем get-запрос                
            {
                Task<HttpResponseMessage> getTask = httpGetter.GetAsync(checkRow.Uri, cancelToken);
                await handlerGet.HandleAsync(checkRow, getTask);
            }
            else
                await handlerGet.HandleAsync(checkRow, null); // Отобразим, что о get-запросе не забыли, а не запросили из-за проблем с пингом или отменой            
        }
    }
}