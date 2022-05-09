using BMS.Bll.Extensions;
using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using BMS.Interface;
using BMS.WebApi.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ApiBaseController<IEmployeeService, Employee, DtoEmployee>
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            this.employeeService = employeeService; 
        }

        //Employee için eklemeyi eziyoruz.
        [HttpPost("Add")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IResponse<DtoEmployee> Add(DtoEmployee entity)
        {
            try
            {
                return employeeService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPut("UpdatePassword")]
        public IResponse<DtoEmployee> UpdatePassword(DtoEmployeePassword entity)
        {
            try
            {
                return employeeService.UpdatePassword(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
