using ZooLab.Animals;
using ZooLab.Employees;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Validators.HireValidators;

namespace ZooLab
{
    public class Zoo
    {
        private HireValidatorProvider _hireValidatorProvider;

        public List<Enclosure> Enclosures { get; set; }
        public List<IEmployee> Employees { get; set; }
        public string Location { get; set; }

        public Zoo(string location)
        {
            Location = location;
            _hireValidatorProvider = new HireValidatorProvider(this);
            Enclosures = new List<Enclosure>();
            Employees = new List<IEmployee>();
        }

        public void AddEnclosure(Enclosure enclosure)
        {
            Enclosures.Add(enclosure);
        }

        public void HireEmployee(IEmployee employee)
        {
            if (_hireValidatorProvider.GetHireValidator(employee).ValidateEmployee(employee).Count==0)
            {
                Employees.Add(employee);
            }
            else
            {
                throw new NoNeededExperienceException();
            }
               
        }

        public Enclosure FindAvailableEnclosure(Animal animalWithoutEnclosure)
        {
            foreach (var enclosure in Enclosures)
            {
                int availableSquare = enclosure.SquareFeet;
                foreach (var animal in enclosure.Animals)
                {
                    if (animalWithoutEnclosure.IsFriendlyWithAnimal(animal))
                        availableSquare -= animal.RequiredSpaceSqFt;
                    else
                        availableSquare = -1;
                }

                if (availableSquare >= animalWithoutEnclosure.RequiredSpaceSqFt)
                {
                    return enclosure;
                }

            }

            throw new NoAvailableEnclosureException();
        }

        public void FeedAnimals()
        {
            var zooKeepers = getAllZooKeepers();
            if (zooKeepers.Count > 0)
            {
                int currentZookeeperIndex=0;
                foreach (var enclosure in Enclosures)
                {
                    foreach (var enclosureAnimal in enclosure.Animals)
                    {
                        zooKeepers[currentZookeeperIndex].FeedAnimal(enclosureAnimal);
                        currentZookeeperIndex++;
                        if (currentZookeeperIndex >= zooKeepers.Count)
                        {
                            currentZookeeperIndex = 0;
                        }
                    }
                }
            }
        }

        public void HealAnimals()
        {
            foreach (var enclosure in Enclosures)
            {
                foreach (var enclosureAnimal in enclosure.Animals)
                {
                    if(enclosureAnimal.IsSick && enclosureAnimal.NeededMedicine.Count>0)
                        enclosureAnimal.Heal(enclosureAnimal.NeededMedicine[0]);
                }
            }
        }

        private List<ZooKeeper> getAllZooKeepers()
        {
            var listOfZooKeepers = new List<ZooKeeper>();
            foreach (var employee in Employees)
            {
                if (employee is ZooKeeper zooKeeper)
                {
                    listOfZooKeepers.Add(zooKeeper);
                }
            }
            return listOfZooKeepers;
        }
    }
}