using BMS.Bll.Extensions;
using BMS.Dal.Abstract;
using BMS.Dal.Concrete.EntityFramework.Repository;
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
    public class EmployeeManager : GenericManager<Employee, DtoEmployee>, IEmployeeService
    {
        public readonly IEmployeeRepository employeeRepository;
        public readonly IUnitofWork unitofWork;
        public EmployeeManager(IServiceProvider service) : base(service)
        {
            employeeRepository = service.GetService<IEmployeeRepository>();
            unitofWork = service.GetService<IUnitofWork>();
        }
        public Response AddEmployee(DtoEmployee employee)
        {
            var result = new Response();
            if (employeeRepository.IsExist(employee.EmployeeMail))
            {
                result.StatusCode = 400;
                result.Message = "Bu e-posta adresi ile daha önce zaten kaydolunmuş.";
            }

            try
            {
                string userPass = RandomExtension.GenerateRandomKey();
                employee.EmployeePass = userPass.ToHashString();
                Add(employee);
                Save();
                MailExtension.SendMail(
                    "BMS - Hoşgeldiniz!",
                    @$"
                        Sayın {employee.EmployeeName}
                        <br>BMS Kaydınız gerçekleştirilmiştir.<br>
                        Kullanıcı bilgileriniz aşağıdaki gibidir.<br
                        <strong><hr>
                        E-Posta: {employee.EmployeeMail}<br> 
                        Şifre: {userPass}<br > </strong><hr>
                        <br> Lütfen şifrenizi HBMS personeli dahil ikinci kişilerle paylaşmayınız!.
                    ",
                     employee.EmployeeMail
                    );
                result.StatusCode = 200;
                result.Message = "Kullanıcı başarılı bir şekilde eklemiş ve şifresi gönderilmiştir.";
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Message = ex.Message;
            }
            return result;
        }

        public IResponse<DtoEmployee> UpdatePassword(DtoEmployeePassword item, bool saveChanges = true)
        {
            var employee = employeeRepository.GetQueryable().FirstOrDefault(t => t.EmployeeMail.ToLower() == item.EmployeeMail.ToLower());
            if(employee != null && employee.EmployeePass == item.EmployeeOldPassword.ToHashString())
            {
                employee.EmployeePass = item.EmployeeNewPassword.ToHashString();
                employeeRepository.Update(employee);
                unitofWork.SaveChanges();
                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status200OK,

                    Data = ObjectMapper.Mapper.Map<DtoEmployee>(employee)
                };

            }

            return new Response<DtoEmployee>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Kullanıcı bulunamadı veya şifreniz yanlış.",
                Data = null
            };

        }
    }
}
