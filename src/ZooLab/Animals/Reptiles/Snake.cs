using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Reptiles
{
    public class Snake:Reptile
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Snake };
        public override List<Food> FavouriteFood => new() { new Meat() };
        public override List<Medicine> NeededMedicine => new();
        public override int RequiredSpaceSqFt => 2;
        public override Animals Type => Animals.Snake;

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
