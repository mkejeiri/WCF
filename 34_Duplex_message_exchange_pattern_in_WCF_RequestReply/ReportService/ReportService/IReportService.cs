﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IReportServiceCallBack))]
    public interface IReportService
    {
        [OperationContract]
        void ProgressReport();
    }


    [ServiceContract]
    public interface IReportServiceCallBack
    {
        [OperationContract]
        void Progress(int PercentageCompleted);
    }

}
