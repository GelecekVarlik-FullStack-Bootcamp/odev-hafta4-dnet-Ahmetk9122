using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.Models;
using BMS.Interface;
using BMS.WebApi.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ApiBaseController<IManagerService, Manager, DtoManager>
    {
        private readonly IManagerService managerService;
        private readonly IEmployeeService employeeService;
        public ManagerController(IManagerService managerService,IEmployeeService employeeService) : base(managerService)
        {
            this.managerService = managerService;
            this.employeeService = employeeService;

        }

        [HttpPost("AddEmployee")]
        public Response AddEmployee(DtoEmployee employee)
        {
            return employeeService.AddEmployee(employee);
        }



    }
}
