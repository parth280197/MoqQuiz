using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqQuiz;
using System.Collections.Generic;

namespace MoqUnitTest
{
  [TestClass]
  public class UnitTest1
  {
    Mock<IDataAccess> fakeEmployeeDataAccess;
    BusinessLogic bl;
    [TestInitialize]
    public void SetUp()
    {
      Employee fakeEmployee = new Employee() { Id = 1, HiringDate = new System.DateTime(2000, 1, 1), Name = "employee1", Salary = 3000 };

      List<Employee> fakeTopThreeEmployeeList = new List<Employee>()
      {
        new Employee() { Id = 2, HiringDate = new System.DateTime(2002, 1, 1), Name = "employee2", Salary = 4500 },
        new Employee() { Id = 1, HiringDate = new System.DateTime(2000, 1, 1), Name = "employee1", Salary = 2500 },
        new Employee() { Id = 3, HiringDate = new System.DateTime(2004, 1, 1), Name = "employee3", Salary = 1500 }
      };

      fakeEmployeeDataAccess = new Mock<IDataAccess>();
      fakeEmployeeDataAccess.Setup(m => m.GetEmployee(It.IsAny<int>())).Returns(fakeEmployee);
      fakeEmployeeDataAccess.Setup(m => m.GetTopThreeEmployee()).Returns(fakeTopThreeEmployeeList);
      bl = new BusinessLogic(fakeEmployeeDataAccess.Object);
    }
    [TestMethod]
    public void BonusCalculationTest()
    {
      var bonus = bl.CalculateAnnualBonus(1);
      Assert.AreEqual(bonus, 540);
    }
    [TestMethod]
    public void TopThreePaidEmployeeTest()
    {
      var result = bl.GetTopThreeEmployee();
      Assert.AreEqual(result, "1.employee2:4500 2.employee1:2500 3.employee3:1500");
    }
  }
}
