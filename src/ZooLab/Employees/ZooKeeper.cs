using ZooLab.Animals;
using ZooLab.Animals.Foods;

namespace ZooLab.Employees;

public class ZooKeeper:IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Animal> AnimalExperiences { get; private set; }

    public ZooKeeper(string firstName,string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = new List<Animal>();
    }

    public ZooKeeper(string firstName,string lastName, List<Animal> animalExperiences)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = animalExperiences;
    }

    public void AddAnimalExperience(Animal animal)
    {
        AnimalExperiences.Add(animal);
    }

    public bool HasAnimalExperience(Animal animal)
    {
        return AnimalExperiences.Any(a=>a.GetType()==animal.GetType());
    }

    public bool FeedAnimal(Animal animal)
    {
        if (animal.FavouriteFood.Count > 0)
            animal.Feed(animal.FavouriteFood[0]);
        else
            return false;
        animal.FeedTimes.Add(new FeedTime(DateTime.Now, this));
        return true;
    }
}