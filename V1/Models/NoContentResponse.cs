using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Models
{
    /// <summary>
    /// Type returned for POST, PUT, and DELETE requests
    /// </summary>
    public class NoContentResponse
    {
        /// <summary>
        /// The status of the action request
        /// </summary>
        string Status { get; set; }
        /// <summary>
        /// The text of the message
        /// </summary>
        string Message { get; set; }

        public NoContentResponse(string status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

    }
}
