using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Models.V1HealthCheck
{
   /// <summary>
   /// OK for yes, ko for no
   /// </summary>
    public enum HealthCheckStatusType
    {
        ok,
        ko
    }

    public class HealthCheckResponse
    {
        /// <summary>
        /// returns ok for good health checks and ko for falures.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public HealthCheckStatusType Status { get; set; }
        /// <summary>
        /// The version number of the latest build
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// The date that the assembly was last built in UTC
        /// </summary>
        public DateTime BuiltDate { get; set; }
       
        /// <summary>
        /// Individual status checks.  
        /// </summary>
        public Dictionary<string, HealthCheckItem> Checks { get; set; }

        public HealthCheckResponse(HealthCheckStatusType status, string version, DateTime builtDate)
        {
            this.Status = status;
            this.Version = version;
            this.BuiltDate = builtDate;
            this.Checks = new Dictionary<string, HealthCheckItem>();
        }

        public bool ShouldSerializeChecks()
        {
            return this.Checks.Count > 0;
        }

    }
}