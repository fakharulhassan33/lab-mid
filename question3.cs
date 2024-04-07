using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMid
{
    internal class PasswordGenerator
    {
        public static string GeneratePassword(string registrationNumber, string firstName, string lastName)
        {
            if (registrationNumber.Length < 2)
            {
                return null;
            }

            Random random = new Random();

            int positionOfNum1 = random.Next(0, 4);
            int positionOfNum2 = random.Next(0, 4);
            while (positionOfNum1 == positionOfNum2)
            {
                positionOfNum2 = random.Next(0, 5);
            }
            string password = "";

            string lastTwoDigits = registrationNumber.Substring(registrationNumber.Length - 2);

            int nums = random.Next(4, 8);
            for (int i = 1; i <= nums; i++)
            {
                if (i == positionOfNum1)
                {
                    password += lastTwoDigits[0];
                }
                else if (i == positionOfNum2)
                {
                    password += lastTwoDigits[1];
                }
                else if (i == 3)
                {
                    password += "1";
                }
                else if (i == 4)
                {
                    password += "2";
                }
                else
                {
                    password += random.Next(0, 10).ToString();
                }
            }

            string specialCharacters = "!@#$%^&*()_-+=<>?";
            int numberOfSpecialChars = random.Next(2, 5);
            for (int i = 1; i <= numberOfSpecialChars; i++)
            {
                password += specialCharacters[random.Next(0, specialCharacters.Length)];
            }

            int chars = random.Next(1, 4);
            password += firstName[0];
            for (int i = 1; i <= chars; i++)
            {
                password += Char.ToUpper((char)('a' + random.Next(26)));
            }
            password += lastName[0];

            if (password.Length > 16)
            {
                password = password.Substring(0, 16);
            }

            return ShufflePassword(password);
        }

        static string ShufflePassword(string input)
        {
            char[] characters = input.ToCharArray();
            Random random = new Random();

            for (int i = characters.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }

            return new string(characters);
        }

    public static void Main(string[] args)
    {
            string pass = GeneratePassword("sp21-bcs-005", "nope", "fari");
            Console.WriteLine(pass);
    }
    }
}
