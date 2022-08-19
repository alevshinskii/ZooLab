
using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals
{
    public abstract class Animal
    {
        public int ID { get; }

        public bool IsSick { get; }

        public List<int> FeedSchedule { get; private set; } = new List<int>();

        public List<FeedTime> FeedTimes { get; }

        public abstract List<Animals> FriendlyAnimals { get; }

        public abstract List<Food> FavouriteFood { get; }

        public abstract List<Medicine> NeededMedicine { get; }

        public abstract int RequiredSpaceSqFt { get; }

        public abstract bool IsFriendlyWithAnimal(Animal animal);

        public abstract Animals Type { get; }


        public void Feed(Food food)
        {

        }

        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule = hours;
        }

        public void Heal(Medicine medicine)
        {

        }
    }
}


