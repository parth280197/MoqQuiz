using System;

namespace MoqQuiz
{
  public class BusinessLogic
  {
    IDataAccess dta;
    public BusinessLogic(IDataAccess dta)
    {
      this.dta = dta;
    }
    public string GetTopThreeEmployee()
    {
      var topThreeEmployee = dta.GetTopThreeEmployee();
      string result = "1." + topThreeEmployee[0].Name + ":" + topThreeEmployee[0].Salary + " " +
                      "2." + topThreeEmployee[1].Name + ":" + topThreeEmployee[1].Salary + " " +
                      "3." + topThreeEmployee[2].Name + ":" + topThreeEmployee[2].Salary;
      return result;
    }
    public double CalculateAnnualBonus(int id)
    {
      var employee = dta.GetEmployee(id);
      var joiningDate = Convert.ToDateTime(employee.HiringDate);
      var yearsSpent = Convert.ToDouble(DateTime.Now.Year - joiningDate.Year - 1);
      var bonus = employee.Salary * (yearsSpent / 100);
      return Convert.ToDouble(bonus);
    }
  }
}
