using BMS.Dal.Abstract;
using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using BMS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Bll
{
    public class DepartmentManager : GenericManager<Department, DtoDepartment>, IDepartmentService
    {
        public readonly IDepartmentRepository departmentRepository;
        public DepartmentManager(IServiceProvider service) : base(service)
        {
            departmentRepository = service.GetService<IDepartmentRepository>();
        }


         }
}
