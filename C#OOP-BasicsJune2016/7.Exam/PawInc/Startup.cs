using PawInc.Models.Centers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PawInc
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            PawCenters centers = null;
            Animals animal = null;

            List<Adoption> adoptCenter = new List<Adoption>();
            List<Cleansing> cleasingCenter = new List<Cleansing>();
            List<Animals> allAnimals = new List<Animals>();
            List<Castration> castrationCenter = new List<Castration>();

            while (input != "Paw Paw Pawah")
            {
                string[] commandLines = input.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string FirstOrDefaultCommand = commandLines[0];

                try
                {
                    string name = string.Empty;
                    try
                    {
                        name = commandLines[1];
                    }
                    catch (Exception)
                    {
                        //// because of statistics castration
                    }
                    

                    switch (FirstOrDefaultCommand)
                    {
                        case "RegisterCleansingCenter":
                            centers = new Cleansing(name);
                            cleasingCenter.Add((Cleansing)centers);
                            break;
                        case "RegisterAdoptionCenter":
                            centers = new Adoption(name);
                            adoptCenter.Add((Adoption)centers);
                            break;
                        case "RegisterCat":
                            int catAge = int.Parse(commandLines[2]);
                            int intelligenceCoefficient = int.Parse(commandLines[3]);
                            string nameOfCenter = commandLines[4];
                            animal = new Cat(name, catAge, nameOfCenter, intelligenceCoefficient);
                            adoptCenter.Where(x => x.Name == nameOfCenter).ToList().ForEach(x => x.AddAnimal(animal));
                            break;
                        case "RegisterDog":
                            int dogAge = int.Parse(commandLines[2]);
                            int amountOfCommands = int.Parse(commandLines[3]);
                            string nameOfCenter2 = commandLines[4];
                            animal = new Dog(name, dogAge, nameOfCenter2, amountOfCommands);
                            adoptCenter.Where(x => x.Name == nameOfCenter2).ToList().ForEach(x => x.AddAnimal(animal));
                            break;
                        case "SendForCleansing":
                            string adoptName = commandLines[1];
                            string cleasingName = commandLines[2];

                            var currentCenter = adoptCenter.FirstOrDefault(x => x.Name == adoptName).UncleanedAnimals;
                            cleasingCenter.FirstOrDefault(c => c.Name == cleasingName).AddUncleanedAnimal(currentCenter);
                            adoptCenter.FirstOrDefault(x => x.Name == adoptName).UncleanedAnimals.Clear();
                            break;
                        case "Cleanse":
                            string cleasinName = commandLines[1];
                            cleasingCenter.FirstOrDefault(c => c.Name == cleasinName).CleanAnimals();
                            var currentCleasingCenter = cleasingCenter.FirstOrDefault(c => c.Name == cleasinName).CleanedAnimals;
                            foreach (var center in adoptCenter)
                            {
                                foreach (var cleanedAnimal in currentCleasingCenter)
                                {
                                    if (center.Name == cleanedAnimal.AdoptionCenterName)
                                    {
                                        center.SaveCleanedAnimals(cleanedAnimal);
                                    }
                                }
                            }

                            break;
                        case "Adopt":
                            string centerName = commandLines[1];
                            adoptCenter.FirstOrDefault(x => x.Name == centerName).AdpotAnimal();
                            break;
                        case "RegisterCastrationCenter":
                            centers = new Castration(name);
                            castrationCenter.Add((Castration)centers);
                            break;
                        case "SendForCastration":
                            string adoptCenterName = commandLines[1];
                            string castratingCenterName = commandLines[2];

                            var savedAnimals = adoptCenter.FirstOrDefault(x => x.Name == adoptCenterName).UncleanedAnimals;

                            foreach (var center in castrationCenter)
                            {
                                foreach (var anim in savedAnimals)
                                {
                                    if (center.Name == castratingCenterName)
                                    {
                                        center.AddAnimalsToCastrate(anim);
                                    }
                                }
                            }

                            break;
                        case "Castrate":
                            string castrateCenterN = commandLines[1];
                            castrationCenter.FirstOrDefault(x => x.Name == castrateCenterN).CastrateAnimals();
                            var currentCastrated = castrationCenter.FirstOrDefault(x => x.Name == castrateCenterN).AlreadyCastrated;

                            foreach (var center in adoptCenter)
                            {
                                foreach (var cleanedAnimal in currentCastrated)
                                {
                                    if (center.Name == cleanedAnimal.AdoptionCenterName)
                                    {
                                        center.SaveCleanedAnimals(cleanedAnimal);
                                    }
                                }
                            }

                            break;
                        case "CastrationStatistics":
                            Console.WriteLine("Paw Inc. Regular Castration Statistics");
                            Console.WriteLine($"Castration Centers: {castrationCenter.Count}");
                            var statsAnimals = new SortedSet<string>();
                            foreach (var collection in castrationCenter)
                            {
                                foreach (var item in collection.AlreadyCastrated)
                                {
                                    statsAnimals.Add(item.Name);
                                }
                            }

                            Console.Write("Castrated Animals: ");
                            if (statsAnimals.Count < 1)
                            {
                                Console.WriteLine("None");
                            }
                            else
                            {
                                Console.WriteLine(string.Join(", ", statsAnimals));
                            }
                           
                            break;
                        default:
                            throw new ArgumentException("Invalid center");
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine(e.Message);
                    goto end;
                }

                end:
                input = Console.ReadLine();
            }

            Console.WriteLine("Paw Incorporative Regular Statistics");
            Console.WriteLine($"Adoption Centers: {adoptCenter.Count}");

            Console.WriteLine($"Cleansing Centers: {cleasingCenter.Count}");

            int countAdopted = 0;
            Console.Write("Adopted Animals: ");
            adoptCenter.ForEach(x => countAdopted += x.AdoptedAnimals.Count);
            if (countAdopted == 0)
            {
                Console.WriteLine("None");
            }           
            else
            {
                List<string> adoptedAnimalsNames = new List<string>();
                adoptCenter.ForEach(x => x.AdoptedAnimals.OrderBy(n => n.Name).ToList().ForEach(y => adoptedAnimalsNames.Add(y.Name)));
                Console.WriteLine(string.Join(", ", adoptedAnimalsNames));
            }       

            int countCleasing = 0;
            Console.Write("Cleansed Animals: ");
            cleasingCenter.ForEach(x => countCleasing += x.CleanedAnimals.Count);
            if (countCleasing == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                List<string> cleansedAnimalsNames = new List<string>();
                cleasingCenter.ForEach(x => x.CleanedAnimals.OrderBy(n => n.Name).ToList().ForEach(y => cleansedAnimalsNames.Add(y.Name)));
                Console.WriteLine(string.Join(", ", cleansedAnimalsNames));
            }

            Console.Write("Animals Awaiting Adoption: ");
            int awaitingAdoption = 0;
            adoptCenter.ForEach(x => awaitingAdoption += x.UncleanedAnimals.Count);
            Console.WriteLine(awaitingAdoption);

            Console.Write("Animals Awaiting Cleansing: ");
            int awaitingCleasing = 0;
            cleasingCenter.ForEach(x => awaitingCleasing += x.UncleanedAnimals.Count);
            Console.WriteLine(awaitingCleasing);
        }
    }
}
