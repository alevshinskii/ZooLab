
using ZooLab.Animals;
using ZooLab.Animals.Medicines;

namespace ZooLab.Employees;

public class Veterinarian:IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    
    public List<Animal> AnimalExperiences { get; private set; }

    public Veterinarian(string firstName,string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = new List<Animal>();
    }

    public Veterinarian(string firstName,string lastName, List<Animal> animalExperiences)
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
    public bool HealAnimal(Animal animal)
    {
        if (animal.IsSick && animal.NeededMedicine.Count > 0)
        {
            animal.IsSick = false;
            animal.NeededMedicine.Clear();
            return true;
        }
        return false;
    }
}