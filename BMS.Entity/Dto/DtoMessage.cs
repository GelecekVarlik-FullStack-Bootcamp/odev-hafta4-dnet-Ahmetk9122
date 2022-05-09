using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoMessage : DtoBase
    {
        //data transfer object
        //Model ve dto tutarlı olması için modeldeki ve dto daki isimlerin ve dönüş tiplerinin birebir aynı olması gerekmektedir.
        //Dönüşümler manuelde gerçekleştirilebilir ancak mapper ile otomatik yapmak için aynı olmak zorunda.
        public DtoMessage()
        {

        }
        public int MessageId { get; set; }
        public int FromManager { get; set; }
        public int ToEmployee { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
    }
}
