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
    public class WorkController : ApiBaseController<IWorkService, Work, DtoWork>
    {
        public readonly IWorkService workService;

        public WorkController(IWorkService workService) : base(workService)
        {
            this.workService = workService;
        }
        /* [HttpGet("GetDepartmentWork")] //abc.com/api/customer/GetTotalReport
         public IResponse<DtoWork> GetDepartmentWork(DtoWork work)
         {
             try
             {
                 return workService.GetDepartmentWork(work);
             }
             catch (Exception ex)
             {
                 return new Response<DtoWork>
                 {
                     StatusCode = StatusCodes.Status500InternalServerError,
                     Message = $"Error:{ex.Message}",
                     Data = null
                 };
             }
         }*/
        [HttpGet("FindDepartmetWork")]
        public IResponse<List<DtoWork>> FindDepartmetWork(int departmentid)
        {
            try
            {
                return workService.FindDepartmetWork(departmentid);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoWork>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        [HttpGet("UnassignedWorks")]
        public IResponse<List<DtoWork>> UnassignedWorks(int departmentid, int WorkOwner)
        {
            try
            {
                return workService.UnassignedWorks(departmentid , WorkOwner);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoWork>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
