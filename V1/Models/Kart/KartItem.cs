using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Models
{
    /// <summary>
    /// The available fuel types for Karts
    /// </summary>
    public enum KartFuelType
    {
        SunShine,
        Rainbows,
        StarDust
    }

    /// <summary>
    /// A single KartItem.
    /// </summary>
    public class KartItem : IEquatable<KartResourceParameters>
    {
        /// <summary>
        /// The vehicle identification number 
        /// </summary>
        public string VIN { get; set; }
        /// <summary>
        /// The model number of the Kart
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// The style of the kart
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// The total number of seats in the kart
        /// </summary>
        public int Seats { get; set; }
        /// <summary>
        /// The color of the Kart
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// The total MPG the Kart gets
        /// </summary>
        public decimal MPG { get; set; }
        /// <summary>
        /// The type of fuel the kart runs on
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KartFuelType FuelType { get; set; }

        /// <summary>
        /// Last date the Kart was taken in for service
        /// </summary>
        public DateTime LastServiceDate { get; set; }

        /// <summary>
        /// Checks whether the filters in the parameters match for this cart
        /// </summary>
        /// <param name="kartResourceParameters"></param>
        /// <returns></returns>
        public bool Equals(KartResourceParameters kartResourceParameters)
        {
            return
               paramStringMatch(this.Color, kartResourceParameters.Color) &&
               paramStringMatch(this.Style, kartResourceParameters.Style) &&
               paramStringMatch(this.Model, kartResourceParameters.Model) &&
               this.Seats == (kartResourceParameters.Seats ?? this.Seats);
        }

        /// <summary>
        /// Check if source value matches spec value or spec value is null.
        /// If either are true, the parameter is considered matched.
        /// </summary>
        /// <param name="sourceValue"></param>
        /// <param name="specValue"></param>
        /// <returns></returns>
        private bool paramStringMatch(string sourceValue, string specValue)
        {
            if (specValue is null) return true;
            return sourceValue.ToLowerInvariant() == specValue.ToLowerInvariant();
        }
    }
}
