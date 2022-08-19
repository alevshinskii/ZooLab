using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Birds
{
    public class Penguin : Bird
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Penguin };
        public override List<Food> FavouriteFood => new() { new Vegetable()};
        public override List<Medicine> NeededMedicine { get; } = new();
        public override int RequiredSpaceSqFt => 10;
        public override Animals Type => Animals.Penguin;

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            if (FriendlyAnimals.Contains(animal.Type))
            {
                return true;
            }
            return false;
        }
    }
}
