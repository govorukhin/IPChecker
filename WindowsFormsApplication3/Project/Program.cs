using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {                        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form mainForm = CreateApplication();

            Application.Run(mainForm);
        }




        private static Form CreateApplication()
        {
            // Создаём страницу редактирования адресов
            var page_AddressEditing = new Page_AddressEditing();
            new PresenterAddressEditing(
                page_AddressEditing,
                page_AddressEditing,
                new AddressGenerator(),
                new Form_DiapasonAddressChoser(),
                new Form_RandomAddress(),
                new FileIO(),
                new OpenFileDialog() { Filter = "txt files(*.txt) | *.txt" },
                new SaveFileDialog() { Filter = "txt files(*.txt) | *.txt" }
            );



            // Создаём страницу проверки адресов
            ITaskHandler_AddressChecking<PingReply, bool> pingHandler = new PingHandler();
            ITaskHandler_AddressChecking<HttpResponseMessage, bool> getHandler = new GetHandler();
            IChainTasks_AddressChecking addressChecker = new ChainTasks_AddressChecker(pingHandler, getHandler);
            ICheckManager checkManager = new CheckManager(addressChecker);
            Page_AddressChecking page_AddressChecking = new Page_AddressChecking()
            { StatusCheckingToString = new DefaultStatusCheckingToString() };

            new PresenterAddressChecking(
                checkManager,
                page_AddressChecking,
                page_AddressChecking,
                page_AddressChecking
            );



            // Создаём каркас программы
            Page_Main pageMain = new Page_Main(page_AddressEditing, page_AddressChecking);
            FormMain formMain = new FormMain(pageMain);
            new PresenterPageSwitcher(
                pageMain,
                page_AddressEditing,
                page_AddressEditing,
                page_AddressChecking,
                page_AddressChecking                
            );



            return formMain;
        }
    }
}