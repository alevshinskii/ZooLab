using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Reptiles
{
    public class Turtle:Reptile
    {
        public override List<Animals> FriendlyAnimals =>
            new() { Animals.Turtle, Animals.Parrot, Animals.Elephant, Animals.Bison };
        public override List<Food> FavouriteFood => new() { new Vegetable() };
        public override List<Medicine> NeededMedicine => new();
        public override int RequiredSpaceSqFt => 5;
        public override Animals Type => Animals.Turtle;

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
