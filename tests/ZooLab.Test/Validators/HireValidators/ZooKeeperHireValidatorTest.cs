﻿using ZooLab.Employees;
using ZooLab.Validators.HireValidators;

namespace ZooLab.Test.Validators.HireValidators;

public class ZooKeeperHireValidatorTest
{
    private ZooTestFixture zooTestFixture = new();

    [Fact]
    public void ShouldBeAbleToHireUsingZooKeeperHireValidator()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        zoo.HireEmployee(zooTestFixture.GetVeterinarian());
    }

    class UndefinedEmployee : IEmployee
    {
        public string FirstName { get; set; } = "FirstName";
        public string LastName { get; set; } = "LastName";
    }

    [Fact]
    public void ShouldBeAbleToValidateZooKeeper()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        HireValidatorProvider hireValidatorProvider = new(zoo);
        UndefinedEmployee undefinedEmployee = new UndefinedEmployee();
        IHireValidator zooKeeperHireValidator =
            hireValidatorProvider.GetHireValidator(zooTestFixture.GetZooKeeper());

        Assert.Empty(zooKeeperHireValidator.ValidateEmployee(zooTestFixture.GetZooKeeper()));
    }

    [Fact]
    public void ShouldNotBeAbleToValidateUndefinedEmployeeUsingZooKeeperHireValidator()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        HireValidatorProvider hireValidatorProvider = new(zoo);
        UndefinedEmployee undefinedEmployee = new UndefinedEmployee();
        IHireValidator zooKeeperHireValidator =
            hireValidatorProvider.GetHireValidator(zooTestFixture.GetZooKeeper());

        Assert.Throws<ArgumentException>(() => zooKeeperHireValidator.ValidateEmployee(undefinedEmployee));
    }
}