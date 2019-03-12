using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace demo.V1.Models.V1HealthCheck
{
    public class HealthCheckItem
    {
      
        public static HealthCheckItem Ok() => new HealthCheckItem()
        {
            Details = null,
            StatusValue = HealthCheckStatusType.ok
        };

        public static HealthCheckItem Failure(string details)
        {
            return new HealthCheckItem()
            {
                Details = details,
                StatusValue = HealthCheckStatusType.ko
            };
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public HealthCheckStatusType  StatusValue {get;set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }
    }
}