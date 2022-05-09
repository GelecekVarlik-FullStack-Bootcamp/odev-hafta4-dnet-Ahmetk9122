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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }
        public bool IsExist(string email,string passwordHash = null)
        {
            if(!String.IsNullOrEmpty(passwordHash))
            return dbset.FirstOrDefault(x => x.EmployeeMail == email && x.EmployeePass == passwordHash) != null;
            else
            return dbset.FirstOrDefault(x => x.EmployeeMail == email) != null;
        } 


    }
}
