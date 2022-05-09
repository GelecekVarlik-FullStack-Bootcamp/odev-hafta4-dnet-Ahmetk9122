using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Models
{
    public partial class Manager :EntityBase
    {
        public Manager()
        {
            Messages = new HashSet<Message>();
            Works = new HashSet<Work>();
        }

        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerMail { get; set; }
        public string ManagerPhone { get; set; }
        public int ManagerDep { get; set; }
        public string ManagerAuth { get; set; }
        public string ManagerPass { get; set; }

        public virtual Department ManagerDepNavigation { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }

}
