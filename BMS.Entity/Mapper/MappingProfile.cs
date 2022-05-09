using AutoMapper;
using BMS.Entity.Dto;
using BMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DtoDepartment>().ReverseMap();
            CreateMap<Employee, DtoEmployee>().ReverseMap();
            CreateMap<Manager, DtoManager>().ReverseMap();
            CreateMap<Message, DtoMessage>().ReverseMap();
            CreateMap<Work, DtoWork>().ReverseMap();
            CreateMap<Manager, DtoLoginManager>();
            CreateMap<DtoLogin, Manager>();
            CreateMap<Employee, DtoLoginEmployee>();
            CreateMap<DtoLoginE, Employee>();
        }
    }
}
