using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class ConDetails
    {
        [Key]
        public int ConId { get; set; }
        public string ConName { get; set; }
        public string ConNameI { get; set; }
        public string AddressI { get; set; }
        public string AddressII { get; set; }
        public string AddressIII { get; set; }
        public string ServiceTypeNo { get; set; }
        public string PANNo { get; set; }
        public string CINNo { get; set; }
        public string ConDets { get; set; }
        public string BankName { get; set; }
        public long AccountNo { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public string Microcode { get; set; }
        public string Category { get; set; }
        public string NoteI { get; set; }
        public string NoteII { get; set; }
        public string NoteIII { get; set; }
        public string NoteIV { get; set; }
        public string NoteV { get; set; }
        public string NoteVI { get; set; }
        public string GSTIN { get; set; }
        public string ConFor { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
