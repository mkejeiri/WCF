﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CalculatorService
{ 
    [DataContract()]
    class DividedByZeroFault
    {
        [DataMember()]
        public string error { get; set; }

        [DataMember()]
        public string details { get; set; }

    }
}
