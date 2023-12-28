using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class ResponseMessage
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }

}
