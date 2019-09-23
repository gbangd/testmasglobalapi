using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMasGlobal.Domains.Exceptions
{
    public class EmployeeValidationException : Exception
    {
        public EmployeeValidationException(string message):base(string.Format("The following exceptions were found: {0}", message)) { }
    }

    public static class EmployeeValidationExceptionMessages
    {
        public static string NULL_NAME = "Name cannot be null. ";
        public static string NULL_CONTRACT = "Contract Type Name cannot be null. ";
        public static string NULL_ROLE_DESC = "Role description cannot be null. ";
        public static string NULL_ROLE_NAME = "Role name cannot be null. ";
        public static string NULL_ID = "Id cannot be null. ";
        public static string NULL_ROLE_ID = "Role Id name cannot be null. ";
        public static string NULL_HOURLY_SALARY = "Hourly Salary name cannot be null. ";
        public static string NULL_MONTHLY_SALARY = "Monthly Salary name cannot be null. ";
    }
}