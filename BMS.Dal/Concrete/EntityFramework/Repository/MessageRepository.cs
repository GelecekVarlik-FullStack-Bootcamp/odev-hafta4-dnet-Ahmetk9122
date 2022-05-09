using BMS.Dal.Abstract;
using BMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Concrete.EntityFramework.Repository
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {
        }

        public List<Message> WorkCorrespondence(int Manager, int Employee)
        {
            return dbset.Where(x => x.FromManager == Manager && x.ToEmployee == Employee).ToList();
        }
    }
}
