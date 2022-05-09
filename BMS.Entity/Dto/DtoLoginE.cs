using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Dto
{
    public class DtoLoginE :DtoBase
    {
        [Required]
        [StringLength(maximumLength: 200)]
        [DataType(DataType.EmailAddress)]
        public string EmployeeMail { get; set; }
        [Required]
        [StringLength(maximumLength: 40)]
        [DataType(DataType.Password)]
        public string EmployeePass { get; set; }
    }
}
