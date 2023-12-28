using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleType { get; set; }
        public string Description { get; set; }
        public bool IsCancel { get; set; }
    }
}
