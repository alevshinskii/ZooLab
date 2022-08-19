
namespace ZooLab.Animals.Mammals
{
    public class Bison:Mammal
    {
        public override string[] FavouriteFood { get; }
        public override int RequiredSpaceSqFt { get; }
        public override bool isFriendlyWithAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
