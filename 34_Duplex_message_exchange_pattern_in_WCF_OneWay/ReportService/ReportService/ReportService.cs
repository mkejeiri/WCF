using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ReportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportService" in both code and config file together.
     //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class ReportService : IReportService
    {
        public void ProgressReport()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                OperationContext.Current.GetCallbackChannel<IReportServiceCallBack>().Progress(i);
            }
        }     
    }
}
