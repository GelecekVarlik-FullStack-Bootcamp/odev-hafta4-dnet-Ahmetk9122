using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoEmployeePassword:DtoBase
    {
        public string EmployeeMail { get; set; }
        public string EmployeeOldPassword { get; set; }
        public string EmployeeNewPassword { get; set; }
    }
}
