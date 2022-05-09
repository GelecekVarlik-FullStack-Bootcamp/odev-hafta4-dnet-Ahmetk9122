using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Models
{
    public partial class Work :EntityBase
    {
        public int WorkId { get; set; }
        public string RequestNo { get; set; }
        public string RequestTitle { get; set; }
        public string RequestBody { get; set; }
        public int Department { get; set; }
        public DateTime? OpeningDate { get; set; }
        public int Requester { get; set; }
        public int WorkOwner { get; set; }
        public string Priority { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
        public virtual Manager RequesterNavigation { get; set; }
        public virtual Employee WorkOwnerNavigation { get; set; }
    }

}
