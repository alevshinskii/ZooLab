
using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals
{
    public abstract class Animal
    {
        public int ID { get; }

        public bool IsSick { get; set; }

        public List<int> FeedSchedule { get; private set; } = new() { 9, 14, 19 };

        public List<FeedTime> FeedTimes { get; } = new();

        public virtual List<Animals> FriendlyAnimals { get; }

        public virtual List<Food> FavouriteFood { get; }

        public virtual List<Medicine> NeededMedicine { get; set; }

        public virtual int RequiredSpaceSqFt { get; }

        public virtual bool IsFriendlyWithAnimal(Animal animal)
        {
            if (FriendlyAnimals.Contains(animal.Type))
            {
                return true;
            }
            return false;
        }

        public abstract Animals Type { get; }

        public void Feed(Food food)
        {

        }

        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule = hours;
        }

        public virtual void Heal(Medicine medicine)
        {
            IsSick = false;
            NeededMedicine.Clear();
        }
    }
}


