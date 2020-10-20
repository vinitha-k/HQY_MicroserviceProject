using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQY_Microservice.Repository
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] parameter);
    }
}
