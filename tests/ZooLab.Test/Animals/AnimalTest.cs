using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Enclosures;

namespace ZooLab.Test.Animals;

public class AnimalTest
{
    ZooTestFixture zooTestFixture = new ZooTestFixture();

    [Fact]
    public void ShouldAnimalsHaveUniqueIds()
    {
        Lion lion = new Lion();
        Parrot parrot = new Parrot();
        Assert.NotEqual(lion.Id, parrot.Id);
    }

    [Fact]
    public void ShouldAnimalsHaveRequiredSquareFeet()
    {
        Lion lion = new Lion();
        Assert.NotEqual(0, lion.RequiredSpaceSqFt);
    }

    [Fact]
    public void ShouldAnimalsHaveFeedTime()
    {
        Parrot parrot = new Parrot();

        Zoo zoo = zooTestFixture.GetZoo();
        Enclosure enclosure = zooTestFixture.GetEnclosure(zoo);
        zoo.AddEnclosure(enclosure);
        enclosure.AddAnimal(parrot);
        zoo.HireEmployee(zooTestFixture.GetZooKeeperWithExperience());

        zoo.FeedAnimals();

        Assert.NotEmpty(parrot.FeedTimes);
        Assert.Equal(parrot.FeedTimes[0].FeedBy, zoo.Employees[0]);
    }

    [Fact]
    public void ShouldNotBeAbleToFeedAnimalsMoreThan2TimesIn1Day()
    {
        Parrot parrot = new Parrot();

        Zoo zoo = zooTestFixture.GetZoo();
        Enclosure enclosure = zooTestFixture.GetEnclosure(zoo);
        zoo.AddEnclosure(enclosure);
        enclosure.AddAnimal(parrot);
        zoo.HireEmployee(zooTestFixture.GetZooKeeperWithExperience());

        zoo.FeedAnimals();
        zoo.FeedAnimals();
        zoo.FeedAnimals();

        Assert.Equal(2, parrot.FeedTimes.Count);
    }
}