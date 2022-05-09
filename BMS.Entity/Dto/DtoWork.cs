using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoWork : DtoBase
    {
        //data transfer object
        //Model ve dto tutarlı olması için modeldeki ve dto daki isimlerin ve dönüş tiplerinin birebir aynı olması gerekmektedir.
        //Dönüşümler manuelde gerçekleştirilebilir ancak mapper ile otomatik yapmak için aynı olmak zorunda.
        public DtoWork()
        {

        }
        // public int WorkId { get; set; }
        /*  public string RequestNo { get; set; }
          public string RequestTitle { get; set; }
          public string RequestBody { get; set; }
          public int Department { get; set; }
          public DateTime OpeningDate { get; set; }
          public int Requester { get; set; }
          public int WorkOwner { get; set; }
          public string Priority { get; set; }*/
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
    }
}
