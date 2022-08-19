using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Birds
{
    public class Parrot : Bird
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Parrot, Animals.Bison, Animals.Elephant, Animals.Turtle };
        public override List<Food> FavouriteFood => new() { new Grass(), new Vegetable() };
        public override int RequiredSpaceSqFt => 5;
        public override Animals Type => Animals.Parrot;
        public override List<Medicine> NeededMedicine => new();

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
