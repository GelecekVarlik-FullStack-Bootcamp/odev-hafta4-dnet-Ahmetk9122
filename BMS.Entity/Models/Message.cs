using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Models
{
    public partial class Message:EntityBase
    {
        public int MessageId { get; set; }
        public int FromManager { get; set; }
        public int ToEmployee { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }

        public virtual Manager FromManagerNavigation { get; set; }
        public virtual Employee ToEmployeeNavigation { get; set; }
    }

}
