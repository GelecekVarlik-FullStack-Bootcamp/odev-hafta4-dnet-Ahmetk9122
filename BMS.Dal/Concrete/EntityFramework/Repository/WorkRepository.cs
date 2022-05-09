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
    public class WorkRepository : GenericRepository<Work>, IWorkRepository
    {
        public WorkRepository(DbContext context) : base(context)
        {

        }

        public List<Work> FindDepartmetWork(int departmentid)
        {
            return dbset.Where(x=>x.Department == departmentid).ToList();
            
        }

        public List<Work> UnassignedWorks(int departmentid, int WorkOwner)
        {
            
                if (WorkOwner == 4)
                {
                    return dbset.Where(x => x.Department == departmentid && x.WorkOwner == 4).ToList();
                }
                else
                {
                    return null;
                }
        }




        /*public Work GetDepartmentWork(Work work)
        {
            var works = dbset.Where(x => x.Department ==work.Department).FirstOrDefault();
            return works ;
        }*/
    }
}
