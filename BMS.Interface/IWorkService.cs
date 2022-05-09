using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Interface
{
    public interface IWorkService : IGenericService<Work, DtoWork>
    {
        //IResponse<DtoWork> GetDepartmentWork(DtoWork work);
        IResponse<List<DtoWork>> FindDepartmetWork(int departmentid);
        IResponse<List<DtoWork>> UnassignedWorks(int departmentid , int WorkOwner);

    }
}
