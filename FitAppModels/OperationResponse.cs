using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class OperationResponse
    {
        public bool OperationSuccessful { get; set; }
        public string OperationMessage { get; set; }
        public object ReturnedObject { get; set; }
    }
}
