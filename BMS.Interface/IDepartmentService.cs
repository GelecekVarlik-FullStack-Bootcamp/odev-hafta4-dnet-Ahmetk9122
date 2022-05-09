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
    public interface IDepartmentService :IGenericService<Department ,DtoDepartment>
    {

    }
}
