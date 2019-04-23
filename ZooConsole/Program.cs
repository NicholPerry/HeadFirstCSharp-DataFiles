using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals;
using BirthingRooms;
using People;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The class representing the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Console application for zoo.
        /// </summary>
        /// <param name="args"> Arguments for the application. </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Como Zoo!");
            Console.Title = "Object-Oriented Programming 2: Zoo";

            bool exit = false;
            Zoo zoo = Zoo.NewZoo();

            while (!exit)
            {
                Console.Write("] ");

                string command = Console.ReadLine();
                string[] commandWords = command.Split();

                switch (commandWords[0].ToLower().Trim())
                {
                    case "exit":
                        exit = true;

                        break;

                    case "restart":
                        zoo = Zoo.NewZoo();
                        zoo.BirthingRoomTemperature = 77.0;
                        Console.WriteLine("A new Como Zoo has been created.");

                        break;

                    case "help":
                        Console.WriteLine("Known Commands:");
                        Console.WriteLine("HELP: Shows a list of known commands.");
                        Console.WriteLine("EXIT: Exits the application.");
                        Console.WriteLine("RESTART: Creates a new zoo.");
                        Console.WriteLine("TEMP: Sets the birthing room temperature");
                        Console.WriteLine("SHOW ANIMAL [animal name]: Displays information for specified animal.");
                        Console.WriteLine("SHOW GUEST [guest name]: Displays information for specified guest.");
                        Console.WriteLine("ADD ANIMAL [animal name]: Add a specified animal to the zoo.");
                        Console.WriteLine("ADD GUEST [guest name]: Add a specified animal to the zoo.");
                        Console.WriteLine("REMOVE ANIMAL [animal name]: Removes a specified animal from the zoo.");

                        break;

                    case "temp":
                        try
                        {
                            ConsoleHelper.SetTemperature(zoo, commandWords[1]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A parameter must be entered in order for the temperature command to work.");
                        }

                        break;

                    case "show":
                        try
                        {
                            ConsoleHelper.ProcessShowCommand(zoo, commandWords[1], commandWords[2]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A name must be entered in order to find an [animal or a guest.]");
                        }

                        break;

                    case "add":

                        try
                        {
                            ConsoleHelper.ProcessAddCommand(zoo, commandWords[1]);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A type must be entered in order to add an animal or a guest.");
                        }

                        break;

                    case "remove":

                        try
                        {
                            ConsoleHelper.ProcessRemoveCommand(zoo, commandWords[1], commandWords[2]);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A type must be entered in order to remove an animal or guest.");
                        }

                        break;

                    default:
                        Console.WriteLine("The command " + command + " does not exist, please try again.");
                        break;
                }
            }
        }
    }
}
