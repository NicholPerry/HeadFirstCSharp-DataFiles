using System;
using Accounts;
using Animals;
using BirthingRooms;
using People;
using Reproducers;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The class which is used to represent a console helper.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Processes the add command in the console.
        /// </summary>
        /// <param name="zoo"> The zoo being used. </param>
        /// <param name="type"> The type of object being added.</param>
        public static void ProcessAddCommand(Zoo zoo, string type)
        {
            switch (type)
            {
                case "animal":

                    AddAnimal(zoo);

                    break;

                case "guest":

                    AddGuest(zoo);

                    break;

                default:

                    throw new System.ArgumentOutOfRangeException("Type", "This command only supports adding animals and guests.");
            }
        }

        /// <summary>
        /// Processes the remove command in the console.
        /// </summary>
        /// <param name="zoo"> The zoo being used. </param>
        /// <param name="type"> The type of object being removed. </param>
        /// <param name="name"> The name of the item being removed.</param>
        public static void ProcessRemoveCommand(Zoo zoo, string type, string name)
        {
            switch (type)
            {
                case "animal":

                    RemoveAnimal(zoo, ConsoleUtil.InitialUpper(name));

                    break;

                case "guest":
                    RemoveGuest(zoo, ConsoleUtil.InitialUpper(name));

                    break;

                default:

                    throw new System.ArgumentOutOfRangeException("Type", "This command only supports removing animals or guests.");
            }
        }

        /// <summary>
        /// Process the show command.
        /// </summary>
        /// <param name="zoo"> The name of the zoo.</param>
        /// <param name="type"> The type of command to show.</param>
        /// <param name="name"> The name of the type. </param>
        public static void ProcessShowCommand(Zoo zoo, string type, string name)
        {            
            {
                switch (type)
                {
                    case "animal":

                        try
                        {
                            ShowAnimal(zoo, ConsoleUtil.InitialUpper(name));
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Please enter a third parameter of the name of an animal.");
                        }                        

                        break;

                    case "cage":

                        ShowCage(zoo, ConsoleUtil.InitialUpper(name));
                        break;

                    case "guest":

                        ShowGuest(zoo, ConsoleUtil.InitialUpper(name));
                        break;

                    default:
                        Console.WriteLine("Unknown type: " + type + ". Only animals and guests can be shown");
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the temperature.
        /// </summary>
        /// <param name="zoo"> The name of the zoo.</param>
        /// <param name="temperature"> The temperature to set.</param>
        public static void SetTemperature(Zoo zoo, string temperature)
        {
            {
                try
                {
                    double temp = zoo.BirthingRoomTemperature;
                    double newTemp = double.Parse(temperature);

                    zoo.BirthingRoomTemperature = newTemp;

                    string result = $"Previous temperature: {temp} °F.";
                    Console.WriteLine(result);

                    string result2 = $"New temperature: {newTemp} °F.";
                    Console.WriteLine(result2);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("A number must be submitted as a parameter in order to change the temperature.");
                }
            }
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo being added to. </param>
        private static void AddAnimal(Zoo zoo)
        {
            bool success = false;
            AnimalType type = ConsoleUtil.ReadAnimalType();
            Animal animal = AnimalFactory.CreateAnimal(type, "Drake", 3, 35, Gender.Male);

            animal.Name = ConsoleUtil.ReadAlphabeticValue("Name");
            animal.Name = ConsoleUtil.InitialUpper(animal.Name);
            animal.Gender = ConsoleUtil.ReadGender();

            while (success == false)
            {
                try
                {
                    animal.Age = ConsoleUtil.ReadIntValue("Age");
                    success = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            success = false;

            while (success == false)
            {
                try
                {
                    animal.Weight = ConsoleUtil.ReadDoubleValue("Weight");
                    success = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            zoo.AddAnimal(animal);
            ShowAnimal(zoo, animal.Name);
        }

        /// <summary>
        /// Adds a guest to the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo being added to. </param>
        private static void AddGuest(Zoo zoo)
        {
            bool success = false;
            Guest guest = new Guest("Chloe", 25, 0, WalletColor.Indigo, Gender.Female, new Account());
            decimal walletBalance = 0.00m;
            decimal checkingAccount = 0.00m;

            guest.Name = ConsoleUtil.ReadAlphabeticValue("Name");
            guest.Name = ConsoleUtil.InitialUpper(guest.Name);
            guest.Gender = ConsoleUtil.ReadGender();

            while (success == false)
            {
                try
                {
                    guest.Age = ConsoleUtil.ReadIntValue("Age");
                    success = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            walletBalance = (decimal)ConsoleUtil.ReadDoubleValue("Wallet Money Balance");
            guest.Wallet.AddMoney(walletBalance);
            guest.Wallet.Color = ConsoleUtil.ReadWalletColor();
            checkingAccount = (decimal)ConsoleUtil.ReadDoubleValue("Checking Account Money Balance");
            guest.CheckingAccount.AddMoney(checkingAccount);
            zoo.AddGuest(guest, zoo.SellTicket(guest));
            ShowGuest(zoo, guest.Name);
        }

        /// <summary>
        /// Removes an animal from the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo being used. </param>
        /// <param name="name"> The name of the object being removed. </param>
        private static void RemoveAnimal(Zoo zoo, string name)
        {
            Animal result = zoo.FindAnimal(name);
            zoo.RemoveAnimal(result);

            if (result != null)
            {
                Console.WriteLine("The animal " + name + " was removed.");
            }
            else
            {
                Console.WriteLine("The animal " + name + " could not be found.");
            }
        }

        /// <summary>
        /// Removes a guest from the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo being changed. </param>
        /// <param name="name"> The name of the guest being removed.</param>
        private static void RemoveGuest(Zoo zoo, string name)
        {
            Guest result = zoo.FindGuest(name);
            zoo.RemoveGuest(result);

            if (result != null)
            {
                Console.WriteLine("The guest " + name + " was removed.");
            }
            else
            {
                Console.WriteLine("The guest " + name + " could not be found.");
            }
        }

        /// <summary>
        /// The show animal command.
        /// </summary>
        /// <param name="zoo"> The name of the zoo.</param>
        /// <param name="name"> The name of the animal.</param>
        private static void ShowAnimal(Zoo zoo, string name)
        {
            {
                Animal animal = zoo.FindAnimal(ConsoleUtil.InitialUpper(name));

                if (animal != null)
                {
                    string result = $"The following animal was found: {animal}";
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("The animal " + name + " could not be found.");
                }
            }
        }

        /// <summary>
        /// The method to show the animals cage.
        /// </summary>
        /// <param name="zoo"> The zoo for the animal. </param>
        /// <param name="animalName"> The animals name. </param>
        private static void ShowCage(Zoo zoo, string animalName)
        {
            Animal animal = zoo.FindAnimal(ConsoleUtil.InitialUpper(animalName));

            if (animal != null)
            {
                Cage cage = zoo.FindCage(animal.GetType());
                Console.WriteLine(cage.ToString());
            }
            else
            {
                Console.WriteLine("The animal " + animalName + " could not be found.");
            }
        }

        /// <summary>
        /// The show guest command.
        /// </summary>
        /// <param name="zoo"> The name of the zoo.</param>
        /// <param name="name"> The name of the guest.</param>
        private static void ShowGuest(Zoo zoo, string name)
        {
            {
                Guest guest = zoo.FindGuest(ConsoleUtil.InitialUpper(name));

                if (guest != null)
                {
                    string result = $"The following guest was found: {guest}";
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("The guest " + name + " could not be found.");
                }
            }
        }
    }
}
