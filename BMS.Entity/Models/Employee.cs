using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Models
{
    public partial class Employee :EntityBase
    {
        public Employee()
        {
            Messages = new HashSet<Message>();
            Works = new HashSet<Work>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeDep { get; set; }
        public string EmployeeAuth { get; set; }
        public string EmployeePass { get; set; }

        public virtual Department EmployeeDepNavigation { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }

}
