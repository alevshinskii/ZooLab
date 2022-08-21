using ZooLab.Animals.Birds;
using ZooLab.Employees;
using ZooLab.Exceptions;

namespace ZooLab.Test.Employees;

public class VeterinarianTest
{
    private ZooTestFixture zooTestFixture = new ZooTestFixture();
    [Fact]
    public void ShouldBeAbleToCreateVeterinarian()
    {
        Veterinarian veterinarian = new Veterinarian("", "");
    }

    [Fact]
    public void ShouldVeterinarianBeAbleToHealAnimal()
    {
        Veterinarian veterinarian = zooTestFixture.GetVeterinarianWithExperience();
        Parrot parrot = new Parrot(isSick: true);

        veterinarian.HealAnimal(parrot);

        Assert.False(parrot.IsSick);
    }

    [Fact]
    public void ShouldVeterinarianNotBeAbleToHealAnimalWithoutExperience()
    {
        Veterinarian veterinarian = zooTestFixture.GetVeterinarian();
        Parrot parrot = new Parrot(isSick: true);

        Assert.Throws<NoNeededExperienceException>(()=>veterinarian.HealAnimal(parrot));
    }
}