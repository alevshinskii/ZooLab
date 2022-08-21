using ZooLab.Animals.Mammals;

namespace ZooLab.Test.Animals.Mammals;

public class MammalTest
{
    
    [Fact]
    public void ShouldBeAbleToCreateLion()
    {
        Lion lion = new Lion();
    }
    [Fact]
    public void ShouldBeAbleToCreateBison()
    {
        Bison bison = new Bison();
    }
    [Fact]
    public void ShouldBeAbleToCreateElephant()
    {
        Elephant elephant = new Elephant();
    }
}