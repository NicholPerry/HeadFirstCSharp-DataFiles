using System;
using System.Collections.Generic;
using Accounts;
using Animals;
using BirthingRooms;
using BoothItems;
using MoneyCollectors;
using People;
using Reproducers;
using VendingMachines;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent a zoo.
    /// </summary>
    public class Zoo
    {
        /// <summary>
        /// A list of all animals currently residing within the zoo.
        /// </summary>
        private List<Animal> animals;

        /// <summary>
        /// A list of all cages in the zoo.
        /// </summary>
        private List<Cage> cages;

        /// <summary>
        /// The zoo's vending machine which allows guests to buy snacks for animals.
        /// </summary>
        private VendingMachine animalSnackMachine;

        /// <summary>
        /// The zoo's room for birthing animals.
        /// </summary>
        private BirthingRoom b168;

        /// <summary>
        /// The maximum number of guests the zoo can accommodate at a given time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// A list of all guests currently visiting the zoo.
        /// </summary>
        private List<Guest> guests;

        /// <summary>
        /// The zoo's ladies' restroom.
        /// </summary>
        private Restroom ladiesRoom;

        /// <summary>
        /// The zoo's men's restroom.
        /// </summary>
        private Restroom mensRoom;

        /// <summary>
        /// The name of the zoo.
        /// </summary>
        private string name;

        /// <summary>
        /// The zoo's information booth.
        /// </summary>
        private GivingBooth informationBooth;

        /// <summary>
        /// The zoo's ticket booth.
        /// </summary>
        private MoneyCollectingBooth ticketBooth;

        /// <summary>
        /// Initializes a new instance of the Zoo class.
        /// </summary>
        /// <param name="name"> The name of the zoo.</param>
        /// <param name="capacity"> The maximum number of guests the zoo can accommodate at a given time.</param>
        /// <param name="restroomCapacity"> The capacity of the zoo's restrooms.</param>
        /// <param name="animalFoodPrice"> The price of a pound of food from the zoo's animal snack machine.</param>
        /// <param name="ticketPrice"> The price of an admission ticket to the zoo.</param>
        /// <param name="waterBottlePrice"> The price of a water bottle.</param>
        /// <param name="boothMoneyBalance"> The initial money balance of the zoo's ticket booth.</param>
        /// <param name="attendant"> The zoo's ticket booth attendant.</param>
        /// <param name="vet"> The zoo's birthing room vet.</param>
        public Zoo(string name, int capacity, int restroomCapacity, decimal animalFoodPrice, decimal ticketPrice, decimal waterBottlePrice, decimal boothMoneyBalance, Employee attendant, Employee vet)
        {
            this.animals = new List<Animal>();
            this.animalSnackMachine = new VendingMachine(animalFoodPrice, new Account());
            this.b168 = new BirthingRoom(vet);
            this.cages = new List<Cage>();

            foreach (AnimalType t in Enum.GetValues(typeof(AnimalType)))
            {
                this.cages.Add(new Cage(400, 800, Animal.ConvertAnimalTypeToType(t)));
            }

            this.capacity = capacity;
            this.guests = new List<Guest>();
            this.ladiesRoom = new Restroom(restroomCapacity, Gender.Female);
            this.mensRoom = new Restroom(restroomCapacity, Gender.Male);
            this.name = name;
            this.ticketBooth = new MoneyCollectingBooth(attendant, ticketPrice, waterBottlePrice, new MoneyBox());
            this.informationBooth = new GivingBooth(attendant);
            this.ticketBooth.AddMoney(boothMoneyBalance);
        }

        /// <summary>
        /// Gets the zoo's animal snack machine.
        /// </summary>
        public VendingMachine AnimalSnackMachine
        {
            get
            {
                return this.animalSnackMachine;
            }
        }

        /// <summary>
        /// Gets the average weight of all animals in the zoo.
        /// </summary>
        public double AverageAnimalWeight
        {
            get
            {
                return this.TotalAnimalWeight / this.animals.Count;
            }
        }

        /// <summary>
        /// Gets or sets the temperature of the zoo's birthing room.
        /// </summary>
        public double BirthingRoomTemperature
        {
            get
            {
                return this.b168.Temperature;
            }

            set
            {
                this.b168.Temperature = value;
            }
        }

        /// <summary>
        /// Gets the total weight of all animals in the zoo.
        /// </summary>
        public double TotalAnimalWeight
        {
            get
            {
                // Define accumulator variable.
                double totalWeight = 0;

                // Loop through the list of animals.
                foreach (Animal a in this.animals)
                {
                    // Add current animal's weight to the total.
                    totalWeight += a.Weight;
                }

                return totalWeight;
            }
        }

        /// <summary>
        /// Gets the list of animals.
        /// </summary>
        public IEnumerable<Animal> Animals
        {
            get
            {
                return this.animals;
            }
        }

        /// <summary>
        /// Gets the list of guests.
        /// </summary>
        public IEnumerable<Guest> Guests
        {
            get
            {
                return this.guests;
            }
        }

        /// <summary>
        /// Creates a new zoo.
        /// </summary>
        /// <returns> Returns the zoo.</returns>
        public static Zoo NewZoo()
        {
            // Create an instance of the Zoo class.
            Zoo zoo = new Zoo("Como Zoo", 1000, 4, 0.75m, 15.00m, 3.00m, 3640.25m, new Employee("Sam", 42), new Employee("Flora", 98));

            Dingo animal = new Dingo("Drake", 1, 17, Gender.Male);
            zoo.AddAnimal(animal);
            animal = new Dingo("Dax", 0, 2, Gender.Male);
            zoo.AddAnimal(animal);

            Chimpanzee chimp = new Chimpanzee("Chester", 6, 40, Gender.Male);
            zoo.AddAnimal(chimp);
            chimp = new Chimpanzee("Charlie", 0, 4, Gender.Male);
            zoo.AddAnimal(chimp);

            Ostrich ostrich = new Ostrich("Octavia", 0, 3, Gender.Female);
            zoo.AddAnimal(ostrich);

            Platypus platypus = new Platypus("Perry", 3, 5, Gender.Male);
            zoo.AddAnimal(platypus);

            Shark shark = new Shark("Bruce", 5, 1500, Gender.Male);
            zoo.AddAnimal(shark);

            // Add money to the animal snack machine.
            zoo.AnimalSnackMachine.AddMoney(42.75m);

            return zoo;
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            this.animals.Add(animal);
            Cage cage = this.FindCage(animal.GetType());
            cage.Add(animal);
        }

        /// <summary>
        /// Adds a guest to the zoo.
        /// </summary>
        /// <param name="guest"> The guest to add.</param>
        /// <param name="ticket"> The ticket to add. </param>
        public void AddGuest(Guest guest, Ticket ticket)
        {
            if (ticket != null && ticket.IsRedeemed == false)
            {
                ticket.Redeem();
                this.guests.Add(guest);
            }
            else
            {
                throw new System.NullReferenceException("The guest couldn't be admitted because they did not have a ticket.");
            }
        }

        /// <summary>
        /// Aids a reproducer in giving birth.
        /// </summary>
        /// <param name="reproducer">The reproducer that is to give birth.</param>
        public void BirthAnimal(IReproducer reproducer)
        {
            // Birth animal.
            IReproducer baby = this.b168.BirthAnimal(reproducer);

            // If the baby is an animal...
            if (baby is Animal)
            {
                // Add the baby to the zoo's list of animals.
                this.AddAnimal(baby as Animal);
            }
        }

        /// <summary>
        /// Finds the animal in the list.
        /// </summary>
        /// <param name="name"> The animals name. </param>
        /// <returns> Returns the animal. </returns>
        public Animal FindAnimal(string name)
        {
            Animal animal = null;

            // Loop through the list of guests.
            foreach (Animal a in this.animals)
            {
                // If the current guest matches...
                if (a.Name == name)
                {
                    // Store the current guest in the variable
                    animal = a;

                    // Break out of the loop
                    break;
                }
            }

            return animal;
        }

        /// <summary>
        /// Finds an animal based on type.
        /// </summary>
        /// <param name="type">The type of the animal to find.</param>
        /// <returns>The first matching animal.</returns>
        public Animal FindAnimal(Type type)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type)
                {
                    // Set the current animal to the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds an animal based on type and pregnancy status.
        /// </summary>
        /// <param name="type">The type of the animal to find.</param>
        /// <param name="isPregnant">The pregnancy status of the animal to find.</param>
        /// <returns>The first matching animal.</returns>
        public Animal FindAnimal(Type type, bool isPregnant)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type && a.IsPregnant == isPregnant)
                {
                    // Store the current animal in the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds a guest based on name.
        /// </summary>
        /// <param name="name">The name of the guest to find.</param>
        /// <returns>The first matching guest.</returns>
        public Guest FindGuest(string name)
        {
            // Define a variable to hold matching guest.
            Guest guest = null;

            // Loop through the list of guests.
            foreach (Guest g in this.guests)
            {
                // If the current guest matches...
                if (g.Name == name)
                {
                    // Store the current guest in the variable
                    guest = g;

                    // Break out of the loop
                    break;
                }
            }

            // Return the matching guest.
            return guest;
        }

        /// <summary>
        /// Sell the guest a ticket.
        /// </summary>
        /// <param name="guest"> The guest buying a ticket. </param>
        /// <returns> Returns the ticket. </returns>
        public Ticket SellTicket(Guest guest)
        {
            // Define variable to hold ticket.
            Ticket ticket = guest.VisitTicketBooth(this.ticketBooth);
            guest.VisitInformationBooth(this.informationBooth);

            return ticket;
        }

        /// <summary>
        /// Removes an animal from the zoo.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void RemoveAnimal(Animal animal)
        {
            foreach (Guest g in this.guests)
            {
                // If the guest's adopted animal matches the animal being removed.
                if (g.AdoptedAnimal == animal)
                {
                    // Set the adopted animal to null and remove the guest from the cage.
                    Cage findCage = this.FindCage(g.AdoptedAnimal.GetType());
                    findCage.Remove(g);

                    g.AdoptedAnimal = null;
                }
            }

            this.animals.Remove(animal);
            Cage cage = this.FindCage(animal.GetType());
            cage.Remove(animal);
        }

        /// <summary>
        /// Removes a guest from the zoo.
        /// </summary>
        /// <param name="guest">The guest to remove.</param>
        public void RemoveGuest(Guest guest)
        {
            if (guest.AdoptedAnimal != null)
            {
                Cage cage = this.FindCage(guest.AdoptedAnimal.GetType());
                cage.Remove(guest);
            }

            this.guests.Remove(guest);
        }

        /// <summary>
        /// Creates a list of animals, loops through all animals and adds them to the list.
        /// </summary>
        /// <param name="type"> Type of animal to evaluate.</param>
        /// <returns> Returns the list of animals.</returns>
        public IEnumerable<Animal> GetAnimals(Type type)
        {
            List<Animal> animalList = new List<Animal>();

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type)
                {
                    // Set the current animal to the variable.
                    animalList.Add(a);
                }
            }

            return animalList;
        }

        /// <summary>
        /// Finds the cage of the animal.
        /// </summary>
        /// <param name="animalType"> The type of cage to find. </param>
        /// <returns>Returns the cage.</returns>
        public Cage FindCage(Type animalType)
        {
            Cage value = null;
            foreach (Cage c in this.cages)
            {
                if (c.AnimalType == animalType)
                {
                    value = c;
                    break;
                }
            }

            return value;
        }
    }
}