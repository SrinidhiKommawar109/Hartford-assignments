using System;
using System.Text.RegularExpressions;

namespace Requirment_3
{
    class Program
    {
        // Valid Registration Number Method 
        static bool ValidateRegistartionNo(string registrationNo)
        {
            try
            {
                // regular expression for pattern checking
                string pattern = @"^[A-Z]{2}\s\d{1,2}(\s[A-Z]{1,2})?\s\d{1,4}$";
                return Regex.IsMatch(registrationNo, pattern);
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //Takes the input from the console
                Console.WriteLine("Enter the Registration number");
                string regNo = Console.ReadLine();

                if (ValidateRegistartionNo(regNo))
                {
                    Console.WriteLine("Registration number is valid!");
                }
                else
                {
                    Console.WriteLine("Registration Number is InValid");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error occurred while validating registration number");
            }
        }
    }
} 