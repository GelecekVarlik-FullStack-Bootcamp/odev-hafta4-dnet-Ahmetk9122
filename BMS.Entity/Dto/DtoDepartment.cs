using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoDepartment : DtoBase
    {
        //data transfer object
        //Model ve dto tutarlı olması için modeldeki ve dto daki isimlerin ve dönüş tiplerinin birebir aynı olması gerekmektedir.
        //Dönüşümler manuelde gerçekleştirilebilir ancak mapper ile otomatik yapmak için aynı olmak zorunda.
        public DtoDepartment()
        {
           
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
