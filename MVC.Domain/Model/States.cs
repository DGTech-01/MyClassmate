using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class States
    {
        [Key]
        public int Id { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public bool IsCancel { get; set; }
    }
}
