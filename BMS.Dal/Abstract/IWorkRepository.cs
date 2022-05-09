using BMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Abstract
{
    public interface IWorkRepository
    {
        // Work GetDepartmentWork(Work work);
        List<Work> FindDepartmetWork(int departmentid);
        List<Work> UnassignedWorks(int departmentid, int WorkOwner);
    }
}
