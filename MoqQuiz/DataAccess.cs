using System;
using System.Collections.Generic;
using System.Linq;

namespace MoqQuiz
{
  public interface IDataAccess
  {
    double GetEmployeeSalary(int id);
    List<Employee> GetTopThreeEmployee();
    Employee GetEmployee(int id);
  }
  public class DataAccess : IDataAccess
  {
    CompanyEntities db = new CompanyEntities();
    public double GetEmployeeSalary(int id)
    {
      return Convert.ToDouble(db.Employees.Find(id).Salary);
    }

    public List<Employee> GetTopThreeEmployee()
    {
      return db.Employees.OrderByDescending(employee => employee.Salary).Take(3).ToList();
    }

    public Employee GetEmployee(int id)
    {
      return db.Employees.Find(id);
    }
  }
}
