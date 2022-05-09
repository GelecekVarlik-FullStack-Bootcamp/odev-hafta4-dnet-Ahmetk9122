using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using BMS.Interface;
using BMS.WebApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerLoginController : ControllerBase
    {
        private readonly IManagerLoginService managerService;
        public ManagerLoginController(IManagerLoginService managerService)
        {
            this.managerService = managerService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        //token olmadan da bu işlemi gerçekleştir.
        public IResponse<DtoManagerToken>Login(DtoLogin login)
        {
            try
            {
                return managerService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoManagerToken>
                {
                    Message = "Error :" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        /*public IActionResult Index()
        {
            return View();
        }
        */
    }
}
