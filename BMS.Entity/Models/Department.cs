using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Models
{
    public partial class Department :EntityBase
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Managers = new HashSet<Manager>();
            Works = new HashSet<Work>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }

}
