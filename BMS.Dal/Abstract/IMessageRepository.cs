using BMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Abstract
{
    public interface IMessageRepository
    {
        List<Message> WorkCorrespondence(int Manager, int Employee);
    }
}
