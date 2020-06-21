﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportService" in both code and config file together.
    [ServiceContract(CallbackContract= typeof(IReportServiceCallback))]
    public interface IReportService
    {
        [OperationContract(IsOneWay=false)]
        void ProcessReport();
    }


    public interface IReportServiceCallback
    {
        [OperationContract(IsOneWay = false)]
        void ReportProgress(int percentageCompleted);
    }
}
