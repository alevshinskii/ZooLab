namespace ZooLab.Animals.Birds
{
    public class Parrot : Bird
    {
        private readonly List<string> FriendlyAnimals = new List<string> { "Parrot", "Bison" };

        public override string[] FavouriteFood { get; } = { "Grass", "Vegetables" };
        public override int RequiredSpaceSqFt { get; } = 5;
        public override bool isFriendlyWithAnimal(Animal animal)
        {

            throw new NotImplementedException();
        }
    }
}
