using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestMasGlobal.Domains.Actions.GetEmployees;
using TestMasGlobal.Domains.Models;

namespace TestMasGlobal.Domains.UseCases
{
    public class ListEmployee : IListEmployee
    {
        private readonly IGetAllEmployees GetAllEmployees;
        private readonly IGetEmployeeById GetEmployeeById;

        public ListEmployee(IGetEmployeeById getEmployeeById, IGetAllEmployees getAllEmployees)
        {
            GetAllEmployees = getAllEmployees;
            GetEmployeeById = getEmployeeById;
        }

        public async Task<List<Tuple<Employee, double>>> GetAll()
        {
            var employees = await GetAllEmployees.GetAll();
            List<Tuple<Employee, double>> extendedEmployees = new List<Tuple<Employee, double>>();
            employees.ForEach(x =>
            {
                extendedEmployees.Add(new Tuple<Employee, double>(x,CalculateAnnualSalary(x))); 
            });
            return extendedEmployees;
        }

        public async Task<Tuple<Employee,double>> GetById(int id)
        {
            var employee = await GetEmployeeById.GetById(id);
            return new Tuple<Employee, double>(employee, CalculateAnnualSalary(employee));
        }


        private double CalculateAnnualSalary(Employee employee)
        {
            double annualSalary = 0;
            if (!string.IsNullOrWhiteSpace(employee.ContractTypeName))
            {
                if (employee.ContractTypeName.Trim().Equals(ContractTypeName.HOURLY))
                    annualSalary = 120 * employee.HourlySalary * 12;
                if (employee.ContractTypeName.Trim().Equals(ContractTypeName.MONTHLY))
                    annualSalary = employee.MonthlySalary * 12;
            }
            return annualSalary;
        }
    }

    public interface IListEmployee
    {
        Task<List<Tuple<Employee, double>>> GetAll();
        Task<Tuple<Employee, double>> GetById(int id);
    }

    public static class ContractTypeName
    {
        public static string HOURLY = "HourlySalaryEmployee";
        public static string MONTHLY = "MonthlySalaryEmployee";
    }
}