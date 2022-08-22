using ZooLab.Employees;

namespace ZooLab.Test.Validators.HireValidators;

public class HireValidatorProviderTest
{
    private ZooTestFixture zooTestFixture = new();

    [Fact]
    public void ShouldBeAbleToHireUsingHireValidatorProvider()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        zoo.HireEmployee(zooTestFixture.GetVeterinarian());
        zoo.HireEmployee(zooTestFixture.GetZooKeeper());
    }

    class UndefinedEmployee : IEmployee
    {
        public string FirstName { get; set; } = "FirstName";
        public string LastName { get; set; } = "LastName";
    }

    [Fact]
    public void ShouldNotBeAbleToHireUndefinedEmployee()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        UndefinedEmployee undefinedEmployee = new UndefinedEmployee();
        Assert.Throws<ArgumentException>(() => zoo.HireEmployee(undefinedEmployee));
    }
}