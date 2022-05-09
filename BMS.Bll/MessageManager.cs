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
    public class MessageManager : GenericManager<Message, DtoMessage>, IMessageService
    {
        public readonly IMessageRepository messageRepository;
        public MessageManager(IServiceProvider service) : base(service)
        {
            messageRepository = service.GetService<IMessageRepository>();
        }

        public IResponse<List<DtoMessage>> WorkCorrespondence(int Manager, int Employee)
        {
            try
            {
                var list = messageRepository.WorkCorrespondence(Manager, Employee);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoMessage>(x)).ToList();

                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {

                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
