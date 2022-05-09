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
    public class ManagerLoginRepository : GenericRepository<Manager>, IManagerLoginRepository
    {
        public ManagerLoginRepository(DbContext context) : base(context)
        {
        }

        public Manager Login(Manager login)
        {
            var manager =dbset.Where(x=>x.ManagerMail == login.ManagerMail && x.ManagerPass == login.ManagerPass).SingleOrDefault();
            return manager;
        }
    }
}
