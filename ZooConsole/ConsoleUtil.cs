using System;
using System.Text;
using System.Text.RegularExpressions;
using Animals;
using People;
using Reproducers;

namespace ZooConsole
{
    /// <summary>
    /// The class which is used to represent a console utility.
    /// </summary>
    internal static class ConsoleUtil
    {
        /// <summary>
        /// Changes the result to uppercase.
        /// </summary>
        /// <param name="value"> Passes in the value.</param>
        /// <returns> Returns the result.</returns>
        public static string InitialUpper(string value)
        {
            string result = null;

            if (value != null && value.Length > 0)
            {
                result = char.ToUpper(value[0]) + value.Substring(1);
            }

            return result;
        }

        /// <summary>
        /// Reads the alphabetic value.
        /// </summary>
        /// <param name="prompt"> The prompt being read. </param>
        /// <returns> Returns the value. </returns>
        public static string ReadAlphabeticValue(string prompt)
        {
            string result = null;

            bool found = false;

            while (!found)
            {
                result = ConsoleUtil.ReadStringValue(prompt);

                if (Regex.IsMatch(result, @"^[a-zA-Z ]+$"))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must contain only letters or spaces.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads a double value.
        /// </summary>
        /// <param name="prompt"> The prompt being read. </param>
        /// <returns> Returns the value. </returns>
        public static double ReadDoubleValue(string prompt)
        {
            double result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (double.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be either a whole number or a decimal number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the gender.
        /// </summary>
        /// <returns> Returns the gender. </returns>
        public static Gender ReadGender()
        {
            Gender result = Gender.Female;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("Gender");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<Gender>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid gender. Possible genders: " + GetTypes(typeof(Gender)));
                }
            }

            return result;
        }

        /// <summary>
        /// Reads an integer value.
        /// </summary>
        /// <param name="prompt"> The prompt being read. </param>
        /// <returns> Returns the value. </returns>
        public static int ReadIntValue(string prompt)
        {
            int result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (int.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be a whole number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads a string value.
        /// </summary>
        /// <param name="prompt"> The prompt being read. </param>
        /// <returns> Returns the string. </returns>
        public static string ReadStringValue(string prompt)
        {
            string result = null;

            bool found = false;

            while (!found)
            {
                Console.Write(prompt + "] ");

                string stringValue = Console.ReadLine().ToLower().Trim();

                Console.WriteLine();

                if (stringValue != string.Empty)
                {
                    result = stringValue;
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must have a value.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the wallet color.
        /// </summary>
        /// <returns> Returns the value. </returns>
        public static WalletColor ReadWalletColor()
        {
            WalletColor result = WalletColor.Black;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("Wallet Color");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<WalletColor>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid wallet color. Possible wallet colors: " + GetTypes(typeof(WalletColor)));
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the type of animal.
        /// </summary>
        /// <returns> Returns the value. </returns>
        public static AnimalType ReadAnimalType()
        {
            AnimalType result = AnimalType.Shark;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("Animal Type");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<AnimalType>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid animal type. Possible animal types: " + GetTypes(typeof(AnimalType)));
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="type"> The type being used. </param>
        /// <returns> Returns the value. </returns>
        public static string GetTypes(Type type)
        {
            StringBuilder typeList = new StringBuilder();

            foreach (string at in Enum.GetNames(type))
            {
                typeList.Append(at + "|");
            }

            return "|" + typeList.ToString();
        }
    }
}
