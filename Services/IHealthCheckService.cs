using demo.V1.Models.V1HealthCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Services
{
    public interface IHealthCheckService
    {
         HealthCheckResponse GetStatus(int detailed);

    }
}
