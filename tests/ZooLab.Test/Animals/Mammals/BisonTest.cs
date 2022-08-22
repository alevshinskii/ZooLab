using ZooLab.Animals.Mammals;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Test.Enclosures;

namespace ZooLab.Test.Animals.Mammals;

public class BisonTest
{
    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreateBison()
    {
        Bison bison = new Bison();
    }

    [Fact]
    public void ShouldBeFriendlyWithBisonType()
    {
        Bison bison = new Bison();

        Assert.Contains(bison.Type, bison.FriendlyAnimals);
        Assert.True(bison.IsFriendlyWithAnimal(bison));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    public void ShouldBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Bison bison = new Bison();

        Assert.Contains(animalType, bison.FriendlyAnimals);
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    [InlineData(ZooLab.Animals.Animals.Lion)]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    public void ShouldNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Bison bison = new Bison();

        Assert.DoesNotContain(animalType, bison.FriendlyAnimals);
    }

    [Fact]
    public void ShouldFitEnclosure()
    {
        Bison bison = new Bison();

        Enclosure enclosure = enclosureTestFixture.GetSmallEnclosure(squareFeet: 1000);

        enclosure.AddAnimal(bison);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(bison));
    }
}