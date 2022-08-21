
using ZooLab.Animals;
using ZooLab.Animals.Medicines;
using ZooLab.Exceptions;

namespace ZooLab.Employees;

public class Veterinarian:IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    
    public List<Animals.Animals> AnimalExperiences { get; private set; }

    public Veterinarian(string firstName,string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = new List<Animals.Animals>();
    }

    public Veterinarian(string firstName,string lastName, List<Animals.Animals> animalExperiences)
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
        return AnimalExperiences.Any(a=>a==animal.Type);
    }
    public bool HealAnimal(Animal animal)
    {
        if (animal.IsSick && animal.NeededMedicine.Count > 0)
        {
            if (HasAnimalExperience(animal))
            {
                animal.IsSick = false;
                animal.NeededMedicine.Clear();
                
                return true;
            }
            else
            {
                throw new NoNeededExperienceException();
            }
        }
        return false;
    }
}