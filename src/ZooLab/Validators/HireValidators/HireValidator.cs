using ZooLab.Employees;

namespace ZooLab.Validators.HireValidators;

public abstract class HireValidator
{
    public abstract List<string> ValidateEmployee(IEmployee employee);
}