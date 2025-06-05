using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling
{
    public interface IErrorHandler
    {
        void ExecuteWithErrorHandling(Action action);
    }
}
