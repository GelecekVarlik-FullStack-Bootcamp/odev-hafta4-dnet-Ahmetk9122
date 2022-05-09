using BMS.Entity.Base;
using BMS.Entity.Dto;
using BMS.Entity.IBase;
using BMS.Entity.Models;
using BMS.Interface;
using BMS.WebApi.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BMS.WebApi.Controllers
{
    public class MessageController : ApiBaseController<IMessageService, Message, DtoMessage>
    {
        private readonly IMessageService messageRepository;

        public MessageController(IMessageService messageRepository,IEmployeeService employeeService) : base(messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        [HttpGet("WorkCorrespondence")]
        public IResponse<List<DtoMessage>> WorkCorrespondence(int Manager, int Employee)
        {
            try
            {
                return messageRepository.WorkCorrespondence(Manager, Employee);
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
