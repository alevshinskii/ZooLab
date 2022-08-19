namespace ZooLab.Animals.Birds
{
    public class Penguin:Bird
    {
        public override string[] FavouriteFood { get; }
        public override int RequiredSpaceSqFt { get; }
        public override bool isFriendlyWithAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
