using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoManager : DtoBase
    {
        //data transfer object
        //Model ve dto tutarlı olması için modeldeki ve dto daki isimlerin ve dönüş tiplerinin birebir aynı olması gerekmektedir.
        //Dönüşümler manuelde gerçekleştirilebilir ancak mapper ile otomatik yapmak için aynı olmak zorunda.
        public DtoManager()
        {
          
        }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerMail { get; set; }
        public string ManagerPhone { get; set; }
        public int ManagerDep { get; set; }
        public string ManagerAuth { get; set; }
        public string ManagerPass { get; set; }
    }
}
