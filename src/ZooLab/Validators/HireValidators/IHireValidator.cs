using ZooLab.Employees;

namespace ZooLab.Validators.HireValidators;

public interface IHireValidator
{
    public List<string> ValidateEmployee(IEmployee employee);
}