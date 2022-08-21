using ZooLab.Animals;
using ZooLab.Exceptions;

namespace ZooLab.Employees;

public class ZooKeeper : IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Animals.Animals> AnimalExperiences { get; private set; }

    public ZooKeeper(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = new List<Animals.Animals>();
    }

    public ZooKeeper(string firstName, string lastName, List<Animals.Animals> animalExperiences)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = animalExperiences;
    }

    public void AddAnimalExperience(Animals.Animals animal)
    {
        AnimalExperiences.Add(animal);
    }

    public bool HasAnimalExperience(Animal animal)
    {
        return AnimalExperiences.Any(a => a == animal.Type);
    }

    public bool FeedAnimal(Animal animal)
    {
        if (animal.FavouriteFood.Count > 0 && animal.FeedTimes.Select(feedTime=> feedTime.Time.Day==DateTime.Now.Day).Count()<animal.FeedSchedule.Count)
        {
            if (AnimalExperiences.Contains(animal.Type))
            {
                animal.Feed(animal.FavouriteFood[0]);
                animal.FeedTimes.Add(new FeedTime(DateTime.Now, this));
            }
            else
            {
                throw new NoNeededExperienceException();
            }
            
            return true;
        }
        return false;
    }
}