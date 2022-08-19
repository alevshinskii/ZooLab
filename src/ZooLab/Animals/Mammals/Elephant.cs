using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Mammals
{
    public class Elephant:Mammal
    {
        public override List<Animals> FriendlyAnimals =>
            new() { Animals.Elephant, Animals.Bison, Animals.Parrot, Animals.Turtle };

        public override List<Food> FavouriteFood => new() {new Grass()};
        public override List<Medicine> NeededMedicine => new ();

        public override int RequiredSpaceSqFt => 1000;

        public override Animals Type => Animals.Elephant;

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
