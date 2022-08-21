using ZooLab.Animals.Reptiles;

namespace ZooLab.Test.Animals.Reptiles;

public class Reptiles
{
    [Fact]
    public void ShouldBeAbleToCreateSnake()
    {
        Snake snake = new Snake();
    }
    [Fact]
    public void ShouldBeAbleToCreateTurtle()
    {
        Turtle turtle = new Turtle();
    }
}