using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMasGlobal.Domains.Models;

namespace TestMasGlobal.Domains.Actions.GetEmployees
{
    public interface IGetAllEmployees
    {
        Task<List<Employee>> GetAll();
    }
}
