using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TestMasGlobal.Controllers.DTOs;
using TestMasGlobal.Controllers.Helpers;
using TestMasGlobal.Domains.UseCases;

namespace TestMasGlobal.Controllers
{
    [RoutePrefix("employee")]
    [EnableCors("*","*","*")]
    public class EmployeeController : ApiController
    {
        private readonly IListEmployee ListEmployee;
        public EmployeeController(IListEmployee listEmployee)
        {
            ListEmployee = listEmployee;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> Get()
        {
            var domainEmployees = await ListEmployee.GetAll();
            return EmployeeToEmployeeDTO.Map(domainEmployees);
        }

        [HttpGet]
        public async Task<EmployeeDTO> GetId(int id)
        {
            var domainEmployee = await ListEmployee.GetById(id);
            return EmployeeToEmployeeDTO.Map(domainEmployee);
        }

    }
}
