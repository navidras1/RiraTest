using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Operation is done successfully";
        public List<string> Warnings { get; set; } = new();
    }
}
