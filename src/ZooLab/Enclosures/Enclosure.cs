﻿using ZooLab.Animals;
using ZooLab.Exceptions;

namespace ZooLab.Enclosures
{
    public class Enclosure
    {
        public string Name { get; set; }

        public List<Animal> Animals { get; set; }

        public Zoo ParentZoo { get; set; }

        public int SquareFeet { get; set; }

        public Enclosure(string name, List<Animal> animals, Zoo parentZoo, int squareFeet)
        {
            Name = name;
            Animals = animals;
            ParentZoo = parentZoo;
            SquareFeet = squareFeet;
        }

        public Enclosure(string name, Zoo parentZoo, int squareFeet)
        {
            Name = name;
            Animals = new List<Animal>();
            ParentZoo = parentZoo;
            SquareFeet = squareFeet;
        }

        public void AddAnimal(Animal animal)
        {
            if (animal.RequiredSpaceSqFt > EnclosureFixture.GetAvailableSquareFeet(this))
                throw new NoAvailableSpaceException();
            if (!EnclosureFixture.IsAllAnimalsFriendly(this, animal))
                throw new NotFriendlyAnimalException();

            Animals.Add(animal);
        }
    }

    public static class EnclosureFixture
    {
        public static int GetAvailableSquareFeet(Enclosure enclosure)
        {
            int availableSquareFeet = enclosure.SquareFeet;
            foreach (var animal in enclosure.Animals)
            {
                availableSquareFeet -= animal.RequiredSpaceSqFt;
            }

            return availableSquareFeet;
        }

        public static bool IsAllAnimalsFriendly(Enclosure enclosure, Animal animalWithoutEnclosure)
        {
            foreach (var animal in enclosure.Animals)
            {
                if (!animalWithoutEnclosure.isFriendlyWithAnimal(animal))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
