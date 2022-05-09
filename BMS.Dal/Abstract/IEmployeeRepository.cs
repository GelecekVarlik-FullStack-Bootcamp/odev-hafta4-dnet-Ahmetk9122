﻿using BMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Abstract
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        bool IsExist(string email,string passwordHash = null);

        
    }
}
