namespace ZooLab.Animals.Reptiles
{
    public class Turtle:Reptile
    {
        public override string[] FavouriteFood { get; }
        public override int RequiredSpaceSqFt { get; }
        public override bool isFriendlyWithAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
