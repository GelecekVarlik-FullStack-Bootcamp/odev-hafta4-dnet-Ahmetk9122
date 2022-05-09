using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoLoginManager:DtoBase
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerMail { get; set; }

    }
}
