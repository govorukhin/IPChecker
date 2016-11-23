using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TypeAddons
{
    // Чем плох обычный Ping? 
    // * Не может породить новый task, пока не завершился предидущий.
    // * Его метод отмены не работает, а рабочие методы не принимают canceltoken.        
    // 
    // Благо, на текущий момент оригинальный Ping не имеет свойств, влияющих на процесс пингования, 
    // поэтому можно порождать новые пинги, не настраивая их.

    public class PingCancellation
    {
        private delegate void Delegate_LaunchSendAsyncPing(Ping ping);


        public Task<PingReply> SendPingAsync(string host, int timeout, CancellationToken cancelToken)
        {
            return PuppetSendPingAsync(cancelToken, (Ping ping) => { ping.SendAsync(host, timeout, null); });            
        }

        public Task<PingReply> SendPingAsync(string host, CancellationToken cancelToken)
        {
            return PuppetSendPingAsync(cancelToken, (Ping ping) => { ping.SendAsync(host, null); });
        }



        private Task<PingReply> PuppetSendPingAsync(CancellationToken cancelToken, Delegate_LaunchSendAsyncPing actionLaunchSendAsyncPing)
        {
            TaskCompletionSource<PingReply> tcs = new TaskCompletionSource<PingReply>();
            if (cancelToken.IsCancellationRequested)
                tcs.TrySetCanceled();
            else
            {
                Ping ping = new Ping();

                ping.PingCompleted += (object sender, PingCompletedEventArgs e) =>
                {
                    if (e.Cancelled)
                        tcs.TrySetCanceled();
                    else if (e.Error != null)
                        tcs.TrySetException(e.Error);
                    else
                        tcs.TrySetResult(e.Reply);
                    ping.Dispose();
                };
                cancelToken.Register(() =>
                {
                    tcs.TrySetCanceled();
                    ping.Dispose();
                });

                actionLaunchSendAsyncPing(ping);
            };
            return tcs.Task;
        }
    }  
}
