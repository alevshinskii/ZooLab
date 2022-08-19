
using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Mammals
{
    public class Bison : Mammal
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Elephant, Animals.Bison };
        public override List<Food> FavouriteFood => new() { new Grass() };
        public override List<Medicine> NeededMedicine => new();
        public override int RequiredSpaceSqFt => 1000;
        public override Animals Type => Animals.Bison;

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
