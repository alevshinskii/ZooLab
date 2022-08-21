using ZooLab.Animals;
using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Animals.Reptiles;
using ZooLab.Employees;
using ZooLab.Enclosures;
using ZooLab.Exceptions;

namespace ZooLab.Test
{
    public class ZooTest
    {
        private ZooTestFixture _fixture = new();

        [Fact]
        public void ShouldBeAbleToCreateZoo()
        {
            Zoo zoo = _fixture.GetZoo();
        }

        [Fact]
        public void ShouldBeAbleToAddEnclosureInZoo()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.AddEnclosure(_fixture.GetEnclosure(zoo));
        }

        [Fact]
        public void ShouldBeAbleToHireZookeeperInZoo()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.HireEmployee(_fixture.GetZooKeeper());
        }

        [Fact]
        public void ShouldBeAbleToHireVeterinarianInZoo()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.HireEmployee(_fixture.GetVeterinarian());
        }

        [Fact]
        public void ShouldBeAbleToHireVeterinarianInZooWithAnimals()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.AddEnclosure(_fixture.GetEnclosureWithAnimals(zoo));
            zoo.HireEmployee(_fixture.GetVeterinarianWithExperience());
        }

        [Fact]
        public void ShouldNotBeAbleToHireVeterinarianWithoutExperienceInZooWithAnimals()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.AddEnclosure(_fixture.GetEnclosureWithAnimals(zoo));
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(_fixture.GetVeterinarian()));
        }

        [Fact]
        public void ShouldBeAbleToHireZooKeeperInZooWithAnimals()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.AddEnclosure(_fixture.GetEnclosureWithAnimals(zoo));
            zoo.HireEmployee(_fixture.GetZooKeeperWithExperience());
        }

        [Fact]
        public void ShouldNotBeAbleToHireZooKeeperWithoutExperienceInZooWithAnimals()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.AddEnclosure(_fixture.GetEnclosureWithAnimals(zoo));

            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(_fixture.GetZooKeeper()));
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalInZoo()
        {
            Zoo zoo = _fixture.GetZoo();
            zoo.AddEnclosure(_fixture.GetEnclosure(zoo));
            Bison bison = new();
            Enclosure enclosure = zoo.FindAvailableEnclosure(bison);
            enclosure.AddAnimal(bison);
        }

        [Fact]
        public void ShouldNotBeAbleToFindAvailableEnclosureInZooWithoutEnclosures()
        {
            Zoo zoo = _fixture.GetZoo();
            Bison bison = new();

            Assert.Throws<NoAvailableEnclosureException>(() => zoo.FindAvailableEnclosure(bison));
        }

        [Fact]
        public void ShouldBeAbleToFeedAllAnimals()
        {
            Zoo zoo = _fixture.GetZoo();
            var enclosure = _fixture.GetEnclosure(zoo);
            zoo.AddEnclosure(enclosure);
            zoo.HireEmployee(_fixture.GetZooKeeperWithExperience());
            zoo.HireEmployee(_fixture.GetVeterinarianWithExperience());
            enclosure.AddAnimal(new Parrot());
            enclosure.AddAnimal(new Elephant());
            enclosure.AddAnimal(new Turtle());

            zoo.FeedAnimals();
        }


        [Fact]
        public void ShouldBeAbleToHealAllAnimals()
        {
            Zoo zoo = _fixture.GetZoo();
            var enclosure = _fixture.GetEnclosure(zoo);
            zoo.AddEnclosure(enclosure);
            zoo.HireEmployee(_fixture.GetZooKeeperWithExperience());
            zoo.HireEmployee(_fixture.GetVeterinarianWithExperience());
            enclosure.AddAnimal(new Parrot(isSick:true));
            enclosure.AddAnimal(new Elephant(isSick:true));
            enclosure.AddAnimal(new Turtle(isSick:true));

            zoo.HealAnimals();

            var animals = _fixture.GetAllAnimalsFromZoo(zoo);
            foreach (var animal in animals)
            {
                Assert.False(animal.IsSick);
            }
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

