using ZooLab.Animals.Birds;

namespace ZooLab.Test.Animals.Birds;

public class BirdTest
{
    [Fact]
    public void ShouldBeAbleToCreateParrot()
    {
        Parrot parrot = new Parrot();
    }
    [Fact]
    public void ShouldBeAbleToCreatePenguin()
    {
        Penguin penguin = new Penguin();
    }
}