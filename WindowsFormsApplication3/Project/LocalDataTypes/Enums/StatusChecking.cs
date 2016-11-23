using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public enum StatusChecking {
        nostarted, // Проверки ещё не было.
        nostartedFinished, // Введено чтобы визуально отличать ещё не обработанных от тех, которые не будут обработаны.
        canceled,
        fail,
        win
    };
}
