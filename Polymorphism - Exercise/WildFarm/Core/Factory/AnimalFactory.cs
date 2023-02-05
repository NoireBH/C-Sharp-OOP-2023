using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Factory.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core.Factory
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] inputInfo)
        {
            string type = inputInfo[0];
            string name = inputInfo[1];
            double weight = double.Parse(inputInfo[2]);
            string fourthInput = inputInfo[3];

            IAnimal animal = null;

            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(fourthInput));
            }

            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(fourthInput));
            }

            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, fourthInput);
            }

            else if (type == "Cat")
            {
                animal = new Cat(name, weight, fourthInput, inputInfo[4]);
            }

            else if (type == "Dog")
            {
                animal = new Dog(name, weight, fourthInput);
            }

            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, fourthInput, inputInfo[4]);
            }
            
            return animal;
        }
    }
}
