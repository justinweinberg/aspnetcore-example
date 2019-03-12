using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Models
{
    /// <summary>
    /// The set of parameters to filter Karts by
    /// </summary>
    public class KartResourceParameters
    {
        const int MAX_PAGE_SIZE = 50;

        private int _pageSize = 20;
        private int _start;

        /// <summary>
        /// Where to start paging
        /// </summary>
        public int Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = Math.Min(Math.Max(value, 0), Int32.MaxValue);
            }
        }

        /// <summary>
        /// Limit of size of results returned
        /// </summary>
        public int Size
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = Math.Min( value, MAX_PAGE_SIZE);
            }
        }
 
        /// <summary>
        /// Filter by color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Filter by model
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Filter by style
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Filter by seat count 
        /// </summary>
        public int? Seats { get; set; }
    }
}
