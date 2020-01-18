using System;
using System.Collections.Generic;

namespace CCL_WEB.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public int LogId { get; set; }
        public int StatusCode { get; set; }
        public string LogMessage { get; set; }
        public DateTime? Created { get; set; }
    }
}
