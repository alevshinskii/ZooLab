using ZooLab.Animals.Mammals;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Test.Enclosures;

namespace ZooLab.Test.Animals.Mammals;

public class ElephantTest
{
    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreateElephant()
    {
        Elephant elephant = new Elephant();
    }

    [Fact]
    public void ShouldBeFriendlyWithElephantType()
    {
        Elephant elephant = new Elephant();

        Assert.Contains(elephant.Type, elephant.FriendlyAnimals);
        Assert.True(elephant.IsFriendlyWithAnimal(elephant));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    public void ShouldBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Elephant elephant = new Elephant();

        Assert.Contains(animalType, elephant.FriendlyAnimals);
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    [InlineData(ZooLab.Animals.Animals.Lion)]
    public void ShouldNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Elephant elephant = new Elephant();

        Assert.DoesNotContain(animalType, elephant.FriendlyAnimals);
    }

    [Fact]
    public void ShouldFitEnclosure()
    {
        Elephant elephant = new Elephant();

        Enclosure enclosure = enclosureTestFixture.GetSmallEnclosure(squareFeet: 1000);

        enclosure.AddAnimal(elephant);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(elephant));
    }
}