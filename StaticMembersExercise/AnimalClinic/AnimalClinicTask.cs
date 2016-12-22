//Define two classes: Animal(name, breed) and AnimalClinic(static field patientId, static field healedAnimalsCount 
//and static field rehabilitedAnimalsCount). You will be given animal data(name and breed) and information whether
//the animal should be healed or rehabilitated.Keep track on the rehabilitated animals, on the healed animals and 
//overall patients.If the animal has been healed, you need to print on the console the following message:
//    Patient { patientID} [{name} ({breed})] has been healed!
//Otherwise print:
//Patient {patientID} [{name} ({breed})] has been rehabilitated!
//You will receive information about animals until you receive command “End”.
//After you receive command “End” print total healed animals and total rehabilitated animals in format:
//Total healed animals: {count}
//Total rehabilitated animals: {count}
//After that you will receive one of the following commands heal or rehabilitate and you must print all the names and breed 
//of the healed or rehabilitated animals in format {name} {breed} each animal on new line.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClinicTask
{

    class AnimalClinicTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Animal>> animals = new Dictionary<string, List<Animal>>();

            animals.Add("heal", new List<Animal>());
            animals.Add("rehabilitate", new List<Animal>());

            string inputAnimal = Console.ReadLine();

            while (!inputAnimal.Equals("End"))
            {
                string[] parameters = inputAnimal.Split(' ');
                string name = parameters[0];
                string breed = parameters[1];
                string command = parameters[2];

                if (command.Equals("heal"))
                {
                    animals["heal"].Add(new Animal(name, breed));
                    AnimalClinic.healed++;
                    AnimalClinic.id++;
                    Console.WriteLine($"Patient {AnimalClinic.id}: [{name} ({breed})] has been healed!");

                }
                else
                {
                    animals["rehabilitate"].Add(new Animal(name, breed));
                    AnimalClinic.rehabilitated++;
                    AnimalClinic.id++;
                    Console.WriteLine($"Patient {AnimalClinic.id}: [{name} ({breed})] has been rehabilitated!");

                }

                inputAnimal = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();
            Console.WriteLine($"Total healed animals: {AnimalClinic.healed}");
            Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.rehabilitated}");
            foreach (var kvp in animals.Where(x => x.Key.Equals(secondInput)))
            {
                foreach (var animal in kvp.Value)
                {
                    Console.WriteLine($"{animal.name} {animal.breed}");
                }
            }


        }
    }
    }

    public class Animal
    {
        public string name;
        public string breed;
        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Breed
        {
            get { return this.breed; }
            set { this.breed = value; }
        }
    }

    public class AnimalClinic
    {
        public static int healed;
        public static int rehabilitated;
        public static int id = 0;
    }
