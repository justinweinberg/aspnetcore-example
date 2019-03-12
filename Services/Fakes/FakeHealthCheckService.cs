using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using demo.V1.Models.V1HealthCheck;

namespace demo.Services.Fakes
{
    public class FakeHealthCheckService : IHealthCheckService
    {
        

        public HealthCheckResponse GetStatus(int detailed)
        {
            var assembly = Assembly.GetEntryAssembly();
            var builtDate = GetBuiltDate(assembly);
            var version = $"{assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}";
            var result=  new HealthCheckResponse(HealthCheckStatusType.ok,  version, builtDate);
            
            if (detailed > 0)
            {
                result.Checks.Add("db_connection", HealthCheckItem.Ok());
                result.Checks.Add("flux_capicator", HealthCheckItem.Failure("1.21 jigawatts not available"));
            }

            return result;
        }
 

        // https://www.meziantou.net/2018/09/24/getting-the-date-of-build-of-a-net-assembly-at-runtime

        private static DateTime GetBuiltDate(Assembly assembly)
        {
            const string BuildVersionMetadataPrefix = "+build";

            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null)
            {
                var value = attribute.InformationalVersion;
                var index = value.IndexOf(BuildVersionMetadataPrefix);
                if (index > 0)
                {
                    value = value.Substring(index + BuildVersionMetadataPrefix.Length);
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                    {
                        return result;
                    }

                }


            }

            return DateTime.MinValue;
        }
    }
}
