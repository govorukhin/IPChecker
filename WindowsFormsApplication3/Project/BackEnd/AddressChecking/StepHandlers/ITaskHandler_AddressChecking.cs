using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    /// <summary>
    /// Обрабатывает задачи связаные с проверкой адресов.    
    /// HandlerResult - на основе этого ответа, будет принято решение, продолжать ли цепочку задач, которая состоит из множества ITaskHandler_AddressChecking
    /// </summary>
    /// <typeparam name="TaskResult"></typeparam>
    /// <typeparam name="HandlerResult"></typeparam>
    public interface ITaskHandler_AddressChecking<TaskResult, HandlerResult>
    {
        Task<HandlerResult> HandleAsync(CheckRow checkRow, Task<TaskResult> task);
    }
}
