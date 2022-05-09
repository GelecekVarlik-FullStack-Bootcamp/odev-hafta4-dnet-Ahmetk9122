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
    public class ManagerLoginManager : GenericManager<Manager, DtoManager>, IManagerLoginService
    {
        public readonly IManagerLoginRepository managerRepository;
        private IConfiguration configuration;

        public ManagerLoginManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            managerRepository = service.GetService<IManagerLoginRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoManagerToken> Login(DtoLogin login)
        {
            var user = managerRepository.Login(ObjectMapper.Mapper.Map<Manager>(login));

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginManager>(user);

                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoManagerToken()
                {
                    DtoLoginManager = dtoUser,
                    AccessToken = token
                };

                return new Response<DtoManagerToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoManagerToken>
                {
                    Message = "Kullanıcı kodu veya parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }

        }
    }
}
