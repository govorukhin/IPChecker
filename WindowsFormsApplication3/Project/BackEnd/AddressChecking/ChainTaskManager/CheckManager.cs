using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using WindowsFormsApplication1;

namespace WindowsFormsApplication3
{
    public class CheckManager : ICheckManager
    {
        private IChainTasks_AddressChecking addressChecker;
        public CheckManager(IChainTasks_AddressChecking addressChecker)
        {
            this.addressChecker = addressChecker;
        }

        private CancellationTokenSource cts = new CancellationTokenSource();

        private void UpdateCTS()
        {
            cts.Dispose();
            cts = new CancellationTokenSource();
        }

        public void CancelCheckingAsync()
        {
            cts.Cancel();
            UpdateCTS();
        }

        public async Task RunCheckingAsync(BindingList<CheckRow> checkRows, IProgress<int> progress)
        {
            int countCompletedTasks = 0;
            object progressLocker = new object();

            var chainsTasks = checkRows.Select( async checkRow =>
            {
                await addressChecker.CheckAddressAsync(checkRow, cts.Token);

                // Задача обработана. Сообщаем о прогрессе.
                lock (progressLocker)
                {
                    countCompletedTasks++;
                    progress.Report(countCompletedTasks);
                }

            });

            await Task.WhenAll(chainsTasks);
        }
    }
}
