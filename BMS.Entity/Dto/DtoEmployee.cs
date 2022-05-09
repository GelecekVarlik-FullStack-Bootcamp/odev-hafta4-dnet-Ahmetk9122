using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoEmployee :DtoBase
    {
        //data transfer object
        //Model ve dto tutarlı olması için modeldeki ve dto daki isimlerin ve dönüş tiplerinin birebir aynı olması gerekmektedir.
        //Dönüşümler manuelde gerçekleştirilebilir ancak mapper ile otomatik yapmak için aynı olmak zorunda.
        public DtoEmployee()
        {
           
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeDep { get; set; }
        public string EmployeeAuth { get; set; }
        public string EmployeePass { get; set; }
    }
}
