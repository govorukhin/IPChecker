using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    // Сшивает воедино поведение IPageChecking
    public class PresenterAddressChecking
    {
        public PresenterAddressChecking(
            ICheckManager checkManager,
            IResultsTableProvider resultsTableProvider,
            ICheckingControlPanel checkingControlPanel,
            ITasksStatusIndicator tasksStatusIndicator
        )
        {
            // проверка адресов
            checkingControlPanel.IsRun_Changed += async () => {
                if (checkingControlPanel.IsRun)
                {
                    // подготовка к проверке
                    tasksStatusIndicator.TasksCompleted = 0;
                    foreach (CheckRow item in resultsTableProvider.CheckRows)
                    {
                        item.ResultPing = StatusChecking.nostarted;
                        item.ResultGet = StatusChecking.nostarted;
                    }

                    // сама проверка
                    await checkManager.RunCheckingAsync(
                        resultsTableProvider.CheckRows,
                        tasksStatusIndicator.Progress
                        );

                    // постготовка
                    checkingControlPanel.IsRun = false;
                }
                else
                    checkManager.CancelCheckingAsync();                
            };




            // При вставке нового списака в эту форму обнуляем индикатор задач.
            resultsTableProvider.CheckRowsChanged += () => {
                tasksStatusIndicator.TasksCompleted = 0;
                tasksStatusIndicator.TasksTotalCount = resultsTableProvider.CheckRows.Count();
            };
        }
    }
}