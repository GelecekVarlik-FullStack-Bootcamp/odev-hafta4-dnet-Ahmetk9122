using BMS.Entity.Base;
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
    public interface IEmployeeService : IGenericService<Employee, DtoEmployee>
    {
        Response AddEmployee(DtoEmployee employee);

        IResponse<DtoEmployee> UpdatePassword (DtoEmployeePassword item, bool saveChanges = true);

    }
}
