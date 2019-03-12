using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Models
{
    /// <summary>
    /// A result set returned from querying Karts
    /// </summary>
    public class KartResponse
    {
        /// <summary>
        /// The total items that matched all filters
        /// </summary>
        public int TotalHits { get; set; }
        /// <summary>
        /// The position of the first result in hits as related to all filtered items
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// The number of items returned as related to all filtered items
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The set of Karts that matches the filtered criteria
        /// </summary>
        public List<KartItem> Hits { get; set; }
    }
}
