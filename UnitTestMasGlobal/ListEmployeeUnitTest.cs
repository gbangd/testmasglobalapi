using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestMasGlobal.Domains.Actions.GetEmployees;
using TestMasGlobal.Domains.Models;
using TestMasGlobal.Domains.UseCases;

namespace UnitTestMasGlobal
{
    [TestClass]
    public class ListEmployeeUnitTest
    {
        [TestMethod]
        public async Task TestGetAll()
        {
            var fakeGetAll = new Mock<IGetAllEmployees>(MockBehavior.Strict);
            var fakeGetById = new Mock<IGetEmployeeById>(MockBehavior.Strict);

            var testEmployees = new List<Employee>()
            {
                new Employee(1,"NameTest1",ContractTypeName.HOURLY,1,"RoleTest1","RoleDescTest1",1500,2500),
                new Employee(1,"NameTest2",ContractTypeName.MONTHLY,1,"RoleTest2","RoleDescTest2",1400,3200),
                new Employee(1,"NameTest3",ContractTypeName.HOURLY,1,"RoleTest3","RoleDescTest3",5500,2800),
                new Employee(1,"NameTest4",ContractTypeName.MONTHLY,1,"RoleTest4","RoleDescTest4",5500,2800),
            };


            fakeGetAll.Setup(f => f.GetAll()).Returns(async () =>
            {
                return await Task.FromResult(((Func<List<Employee>>)(() =>
                {
                    return testEmployees;
                }))());
            });

            var listEmployeeTest = new ListEmployee(fakeGetById.Object, fakeGetAll.Object);
            var resultEmployeeTest = await listEmployeeTest.GetAll();

            var expectedEmployees = new List<Tuple<Employee,double>>()
            {
                new Tuple<Employee, double>(new Employee(1,"NameTest1",ContractTypeName.HOURLY,1,"RoleTest1","RoleDescTest1",1500,2500), 2160000),
                new Tuple<Employee, double>(new Employee(1,"NameTest2",ContractTypeName.MONTHLY,1,"RoleTest2","RoleDescTest2",1400,3200),38400),
                new Tuple<Employee,double>(new Employee(1,"NameTest3",ContractTypeName.HOURLY,1,"RoleTest3","RoleDescTest3",5500,2800),7920000),
                new Tuple<Employee,double>(new Employee(1,"NameTest4",ContractTypeName.MONTHLY,1,"RoleTest4","RoleDescTest4",5500,2800),33600)
            };

            //Tests
            fakeGetAll.Verify(v => v.GetAll(), Times.Once); //Has been runned?
            CollectionAssert.AreEqual(expectedEmployees, resultEmployeeTest, new TupleEmployeeComparer()); //Did it run well?
        }
    }

    public class TupleEmployeeComparer : Comparer<Tuple<Employee,double>>
    {
        public override int Compare(Tuple<Employee,double> x, Tuple<Employee, double> y)
        {
            return x.Item1.Name.Equals(y.Item1.Name) && x.Item2 == y.Item2 ? 0 : -1;
        }
    }
}
