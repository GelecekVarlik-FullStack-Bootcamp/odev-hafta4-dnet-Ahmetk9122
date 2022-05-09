using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLoginController : ControllerBase
    {
        private readonly IEmployeeLoginService employeeService;

        public EmployeeLoginController(IEmployeeLoginService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        //token olmadan da bu işlemi gerçekleştir.
        public IResponse<DtoEmployeeToken> Login(DtoLoginE login)
        {
            try
            {
                return employeeService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoEmployeeToken>
                {
                    Message = "Error :" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

    }
}
