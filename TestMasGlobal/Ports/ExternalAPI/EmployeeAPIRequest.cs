using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestMasGlobal.Domains.Actions.GetEmployees;
using TestMasGlobal.Domains.Models;

namespace TestMasGlobal.Ports.ExternalAPI
{
    public class EmployeeAPIRequest : IGetAllEmployees, IGetEmployeeById
    {
        private readonly WebHelper Helper;
        public EmployeeAPIRequest()
        {
            Helper = new WebHelper();
        }

        public async Task<List<Employee>> GetAll()
        {
            string response = await Helper.Getter(APIConfig.URL_API);
            return JsonConvert.DeserializeObject<List<Employee>>(response, new JsonSerializerSettings() {
                 ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });
        }

        public async Task<Employee> GetById(int id)
        {
            string response = await Helper.Getter(APIConfig.URL_API);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(response, new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });
            return employees.FirstOrDefault(x => x.Id == id);
        }
    }
   
    public static class APIConfig
    {
        public static string URL_API = "http://masglobaltestapi.azurewebsites.net/api/Employees";
    }
}