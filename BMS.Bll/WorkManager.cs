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
    public class WorkManager : GenericManager<Work, DtoWork>, IWorkService
    {

        public readonly IWorkRepository workRepository;
        public WorkManager(IServiceProvider service) : base(service)
        {
            workRepository = service.GetService<IWorkRepository>();
        }

        public IResponse<List<DtoWork>> FindDepartmetWork(int departmentid)
        {
            try
            {
                var list = workRepository.FindDepartmetWork(departmentid);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoWork>(x)).ToList();

                //var entity = ObjectMapper.Mapper.Map<Work, DtoWork>(workRepository.FindDepartmetWork(departmentid));

                return new Response<List<DtoWork>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<List<DtoWork>> UnassignedWorks(int departmentid, int WorkOwner)
        {
            try
            {
                var list = workRepository.UnassignedWorks(departmentid , WorkOwner);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoWork>(x)).ToList();

                //var entity = ObjectMapper.Mapper.Map<Work, DtoWork>(workRepository.FindDepartmetWork(departmentid));

                return new Response<List<DtoWork>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        /*  public IResponse<DtoWork> GetDepartmentWork(DtoWork work)
          {
              var works = workRepository.GetDepartmentWork(ObjectMapper.Mapper.Map<Work>(work));
              try
              {
                  var worke = workRepository.GetDepartmentWork(works);

                  var workDto = ObjectMapper.Mapper.Map<DtoLoginManager>(works);

                  return new Response<DtoWork>
                  {
                      StatusCode = StatusCodes.Status200OK,
                      Message = "Success",
                      Data = work
                  };
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
    }
}
