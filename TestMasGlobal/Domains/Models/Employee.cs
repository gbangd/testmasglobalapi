using System;
using TestMasGlobal.Domains.Exceptions;

namespace TestMasGlobal.Domains.Models
{
    public class Employee
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string ContractTypeName { get; protected set; }
        public int RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public string RoleDescription { get; protected set; }
        public double HourlySalary { get; protected set; }
        public double MonthlySalary { get; protected set; }

        public Employee(int? id, string name, string contractTypeName, int? roleId,
                           string roleName, string roleDesc, double? hourlySalary, double? monthlySalary)
        {
            try
            {
                if(!HasError(id, name, contractTypeName, roleId, roleName, hourlySalary, monthlySalary))
                {
                    Id = id.Value;
                    Name = name;
                    ContractTypeName = contractTypeName;
                    RoleId = roleId.Value;
                    RoleName = roleName;
                    RoleDescription = roleDesc;
                    HourlySalary = hourlySalary.Value;
                    MonthlySalary = monthlySalary.Value;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool HasError(int? id, string name, string contractTypeName, int? roleId,
                                string roleName, double? hourlySalary, double? monthlySalary)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(name))
                errorMessage = EmployeeValidationExceptionMessages.NULL_NAME;
            if (string.IsNullOrWhiteSpace(contractTypeName))
                errorMessage += EmployeeValidationExceptionMessages.NULL_CONTRACT;
            if (string.IsNullOrWhiteSpace(roleName))
                errorMessage += EmployeeValidationExceptionMessages.NULL_ROLE_NAME;
            if(!id.HasValue)
                errorMessage += EmployeeValidationExceptionMessages.NULL_ID;
            if (!roleId.HasValue)
                errorMessage += EmployeeValidationExceptionMessages.NULL_ROLE_ID;
            if (!hourlySalary.HasValue)
                errorMessage += EmployeeValidationExceptionMessages.NULL_HOURLY_SALARY;
            if (!monthlySalary.HasValue)
                errorMessage += EmployeeValidationExceptionMessages.NULL_MONTHLY_SALARY;

            if (string.IsNullOrWhiteSpace(errorMessage))
                return false;
            else
                throw new EmployeeValidationException(errorMessage);
        }

    }
}