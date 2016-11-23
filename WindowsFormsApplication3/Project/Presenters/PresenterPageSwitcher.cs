using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class PresenterPageSwitcher
    {
        // Осуществляет переключение страниц
        public PresenterPageSwitcher(
            IViewerPages viewerPages,
            ICallerStepChecking callerStepChecking,
            IAddressTableProvider addressTableProvider,
            ICallerStepEditing callerStepEditing,
            IResultsTableProvider resultsTableProvider            
            )
        {            
            callerStepChecking.StepAddressChecking_required += () => {

                var bindingList = addressTableProvider.Addresses.Select(
                    item => new CheckRow()
                    {
                        Host = item.Host,
                        ResultPing = StatusChecking.nostarted,
                        Uri = item.Uri,
                        ResultGet = StatusChecking.nostarted
                    }).ToList();
                resultsTableProvider.CheckRows = new BindingList<CheckRow>(bindingList);

                viewerPages.Show_PageAddressChecking();
            };
            callerStepEditing.StepEditing_required += viewerPages.Show_PageAddressEditing;
        }
    }
}
