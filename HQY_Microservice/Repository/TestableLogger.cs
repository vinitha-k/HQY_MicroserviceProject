using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQY_Microservice.Repository
{
    public class TestableLogger :ILoggingService
    {
        private readonly ILogger _logger;
        public TestableLogger(ILogger<TestableLogger> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params Object[] parameters)
        {
            _logger.LogInformation(message, parameters);

        }
    }
}
