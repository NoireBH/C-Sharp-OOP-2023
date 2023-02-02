using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var citizensAndPets = new List<IBirthdate>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                string entityType = info[0];

                if (entityType == "Citizen")
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string birthDate = info[4];

                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    citizensAndPets.Add(citizen);
                }

                else if (entityType == "Robot")
                {
                    string model = info[1];
                    string id = info[2];
                    
                    Robot robot = new Robot(model, id);                  
                }

                else if (entityType == "Pet")
                {
                    string name = info[1];
                    string birthday = info[2];
                    Pet pet = new Pet(name, birthday);
                    citizensAndPets.Add(pet);
                }
                
            }

            string yearToSearch = Console.ReadLine();

            foreach (var entity in citizensAndPets)
            {
                entity.SearchForSameBirthday(yearToSearch);
            }

        }
    }
}
