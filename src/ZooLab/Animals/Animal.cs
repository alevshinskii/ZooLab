
using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals
{
    public abstract class Animal
    {
        public int ID { get; }

        public bool IsSick { get; }

        public List<int> FeedSchedule { get; private set; }

        public List<FeedTime> FeedTimes { get; }

        public abstract string[] FavouriteFood { get; }

        public abstract int RequiredSpaceSqFt { get; }

        public abstract bool isFriendlyWithAnimal(Animal animal);

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


