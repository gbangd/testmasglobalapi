using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMasGlobal.Controllers.DTOs;
using TestMasGlobal.Domains.Models;

namespace TestMasGlobal.Controllers.Helpers
{
    public static class EmployeeToEmployeeDTO
    {
        public static List<EmployeeDTO> Map(List<Tuple<Employee,double>> employees)
        {
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            employees.ForEach(x =>
            {
                employeeDTOs.Add(new EmployeeDTO()
                {
                    Id = x.Item1.Id,
                    Name = x.Item1.Name,
                    ContractTypeName = x.Item1.ContractTypeName,
                    HourlySalary = x.Item1.HourlySalary,
                    MonthlySalary = x.Item1.MonthlySalary,
                    RoleDescription = x.Item1.RoleDescription,
                    RoleId = x.Item1.RoleId,
                    RoleName = x.Item1.RoleName,
                    AnnualSalary = x.Item2
                });
            });

            return employeeDTOs;
        }

        public static EmployeeDTO Map(Tuple<Employee, double> employee)
        {
            EmployeeDTO employeeDTOs = new EmployeeDTO();
            return new EmployeeDTO()
            {
                Id = employee.Item1.Id,
                Name = employee.Item1.Name,
                ContractTypeName = employee.Item1.ContractTypeName,
                HourlySalary = employee.Item1.HourlySalary,
                MonthlySalary = employee.Item1.MonthlySalary,
                RoleDescription = employee.Item1.RoleDescription,
                RoleId = employee.Item1.RoleId,
                RoleName = employee.Item1.RoleName,
                AnnualSalary = employee.Item2
            };

        }
    }
}