using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Test.Enclosures;

namespace ZooLab.Test.Animals.Mammals;

public class LionTest
{

    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreateLion()
    {
        Lion lion = new Lion();
    }

    [Fact]
    public void ShouldBeFriendlyWithLionType()
    {
        Lion lion = new Lion();

        Assert.Contains(lion.Type, lion.FriendlyAnimals);
        Assert.True(lion.IsFriendlyWithAnimal(lion));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    public void ShouldNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Lion lion = new Lion();

        Assert.DoesNotContain(animalType, lion.FriendlyAnimals);
    }

    [Fact]
    public void ShouldFitEnclosure()
    {
        Lion lion = new Lion();

        Enclosure enclosure = enclosureTestFixture.GetSmallEnclosure(squareFeet: 1000);

        enclosure.AddAnimal(lion);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(lion));
    }
}