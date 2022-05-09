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
    public class EmployeeLoginRepository : GenericRepository<Employee>, IEmployeeLoginRepository
    {
        public EmployeeLoginRepository(DbContext context) : base(context)
        {
        }

        public Employee Login(Employee login)
        {
            var employee = dbset.Where(x => x.EmployeeMail == login.EmployeeMail && x.EmployeePass == login.EmployeePass).SingleOrDefault();
            return employee;
        }
    }
}
