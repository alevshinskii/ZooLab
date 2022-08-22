using ZooLab.Animals;
using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Animals.Reptiles;
using ZooLab.Employees;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Test.Enclosures;

namespace ZooLab.Test
{
    public class ZooTest
    {
        private ZooTestFixture zooTestFixture = new();
        private EnclosureTestFixture enclosureTestFixture = new();

        [Fact]
        public void ShouldBeAbleToCreateZoo()
        {
            Zoo zoo = zooTestFixture.GetZoo();
        }

        [Fact]
        public void ShouldBeAbleToAddEnclosureInZoo()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.AddEnclosure(zooTestFixture.GetEnclosure(zoo));
        }

        [Fact]
        public void ShouldBeAbleToHireZookeeperInZoo()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.HireEmployee(zooTestFixture.GetZooKeeper());
        }

        [Fact]
        public void ShouldBeAbleToHireVeterinarianInZoo()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.HireEmployee(zooTestFixture.GetVeterinarian());
        }

        [Fact]
        public void ShouldBeAbleToHireVeterinarianInZooWithAnimals()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.AddEnclosure(zooTestFixture.GetEnclosureWithAnimals(zoo));
            zoo.HireEmployee(zooTestFixture.GetVeterinarianWithExperience());
        }

        [Fact]
        public void ShouldNotBeAbleToHireVeterinarianWithoutExperienceInZooWithAnimals()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.AddEnclosure(zooTestFixture.GetEnclosureWithAnimals(zoo));
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(zooTestFixture.GetVeterinarian()));
        }

        [Fact]
        public void ShouldBeAbleToHireZooKeeperInZooWithAnimals()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.AddEnclosure(zooTestFixture.GetEnclosureWithAnimals(zoo));
            zoo.HireEmployee(zooTestFixture.GetZooKeeperWithExperience());
        }

        [Fact]
        public void ShouldNotBeAbleToHireZooKeeperWithoutExperienceInZooWithAnimals()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.AddEnclosure(zooTestFixture.GetEnclosureWithAnimals(zoo));

            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(zooTestFixture.GetZooKeeper()));
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalInZoo()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            zoo.AddEnclosure(zooTestFixture.GetEnclosure(zoo));
            Bison bison = new();
            Enclosure enclosure = zoo.FindAvailableEnclosure(bison);
            enclosure.AddAnimal(bison);
        }

        [Fact]
        public void ShouldNotBeAbleToFindAvailableEnclosureInZooWithoutEnclosures()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            Bison bison = new();

            Assert.Throws<NoAvailableEnclosureException>(() => zoo.FindAvailableEnclosure(bison));
        }

        [Fact]
        public void ShouldBeAbleToFeedAllAnimals()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            var enclosure = zooTestFixture.GetEnclosure(zoo);
            zoo.AddEnclosure(enclosure);
            zoo.HireEmployee(zooTestFixture.GetZooKeeperWithExperience());
            zoo.HireEmployee(zooTestFixture.GetVeterinarianWithExperience());
            enclosure.AddAnimal(new Parrot());
            enclosure.AddAnimal(new Elephant());
            enclosure.AddAnimal(new Turtle());

            zoo.FeedAnimals();
        }


        [Fact]
        public void ShouldBeAbleToHealAllAnimals()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            var enclosure = zooTestFixture.GetEnclosure(zoo);
            zoo.AddEnclosure(enclosure);
            zoo.HireEmployee(zooTestFixture.GetZooKeeperWithExperience());
            zoo.HireEmployee(zooTestFixture.GetVeterinarianWithExperience());
            enclosure.AddAnimal(new Parrot(isSick:true));
            enclosure.AddAnimal(new Elephant(isSick:true));
            enclosure.AddAnimal(new Turtle(isSick:true));

            zoo.HealAnimals();

            var animals = zooTestFixture.GetAllAnimalsFromZoo(zoo);
            foreach (var animal in animals)
            {
                Assert.False(animal.IsSick);
            }
        }

        [Fact]
        public void ShouldBeAbleToFindAvailableEnclosure()
        {
            Zoo zoo = zooTestFixture.GetZoo();
            var smallEnclosure = enclosureTestFixture.GetCustomEnclosure(1000);
            var largeEnclosure = enclosureTestFixture.GetCustomEnclosure(4000);
            zoo.AddEnclosure(smallEnclosure);
            zoo.AddEnclosure(largeEnclosure);
            zoo.HireEmployee(zooTestFixture.GetZooKeeperWithExperience());
            zoo.HireEmployee(zooTestFixture.GetVeterinarianWithExperience());
            Bison bison = new Bison();

            for (int i = 0; i < 5; i++)
            {
                zoo.FindAvailableEnclosure(bison).AddAnimal(bison);
            }

            Assert.Equal(5,zooTestFixture.GetAllAnimalsFromZoo(zoo).Count);
        }
    }

    public class ZooTestFixture
    {
        internal Zoo GetZoo()
        {
            return new Zoo("Location");
        }

        internal List<Animal> GetAnimalsList()
        {
            return new List<Animal> { new Bison(), new Elephant(),new Parrot(),new Turtle() };
        }

        internal List<ZooLab.Animals.Animals> GetAnimalsTypesList()
        {
            return new List<ZooLab.Animals.Animals> { ZooLab.Animals.Animals.Bison, ZooLab.Animals.Animals.Elephant,ZooLab.Animals.Animals.Parrot,ZooLab.Animals.Animals.Turtle };
        }

        internal Enclosure GetEnclosure(Zoo zoo)
        {
            return new Enclosure("New enclosure", zoo, 9999);
        }

        internal Enclosure GetEnclosureWithAnimals(Zoo zoo)
        {
            var animals = GetAnimalsList();
            return new Enclosure("New enclosure", animals, zoo, 10);
        }

        internal ZooKeeper GetZooKeeper()
        {
            return new ZooKeeper("FirstName", "LastName");
        }
        internal Veterinarian GetVeterinarian()
        {
            return new Veterinarian("FirstName", "LastName");
        }

        internal Veterinarian GetVeterinarianWithExperience()
        {
            return new Veterinarian("FirstName", "LastName", GetAnimalsTypesList());
        }

        internal ZooKeeper GetZooKeeperWithExperience()
        {
            return new ZooKeeper("FirstName", "LastName", GetAnimalsTypesList());
        }

        internal List<Animal> GetAllAnimalsFromZoo(Zoo zoo)
        {
            var list = new List<Animal>();
            foreach (var zooEnclosure in zoo.Enclosures)
            {
                foreach (var zooEnclosureAnimal in zooEnclosure.Animals)
                {
                    list.Add(zooEnclosureAnimal);
                }
            }
            return list;
        }


    }
}

