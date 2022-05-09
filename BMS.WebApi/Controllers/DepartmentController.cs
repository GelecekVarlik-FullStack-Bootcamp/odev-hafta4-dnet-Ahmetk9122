using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using BMS.Interface;
using BMS.WebApi.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ApiBaseController<IDepartmentService, Department, DtoDepartment>
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            this.departmentService = departmentService;
        }

    }
}
