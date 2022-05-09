using BMS.Dal.Abstract;
using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using BMS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Bll
{
    public class EmployeeLoginManager : GenericManager<Employee, DtoEmployee>, IEmployeeLoginService
    {
        public readonly IEmployeeLoginRepository employeeRepository;
        private IConfiguration configuration;
        public EmployeeLoginManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            employeeRepository = service.GetService<IEmployeeLoginRepository>();
            this.configuration = configuration;
            
        }

        public IResponse<DtoEmployeeToken> Login(DtoLoginE login)
        {
            var user = employeeRepository.Login(ObjectMapper.Mapper.Map<Employee>(login));

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginEmployee>(user);

                var token =new TokenEmployee(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoEmployeeToken()
                {
                    DtoLoginEmployee = dtoUser,
                    AccessToken = token
                };

                return new Response<DtoEmployeeToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Kullanıcı kodu veya parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }

        }
    }
}
