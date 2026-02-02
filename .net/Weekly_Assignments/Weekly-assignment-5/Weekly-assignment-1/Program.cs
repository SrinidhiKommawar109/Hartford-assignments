namespace Weekly_assignment_1
{
    using System;

    class FinalAssignment
    {
        static void Main()
        {
            Console.WriteLine("WEEK 5 - C# BASIC ASSIGNMENT");
            Console.WriteLine("1. Exercise-1");
            Console.WriteLine("2. Exercise-2");
            Console.WriteLine("3. Exercise-3");
            Console.WriteLine("4. Exercise-4");
            Console.WriteLine("5. Exercise-5");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            // ------------------ EXERCISE 1 ------------------
            if (choice == 1)
            {
                Console.Write("Enter number of matches: ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    int value = i * (i + 1) * (i + 2);
                    Console.Write(value + " ");
                }
            }

            // ------------------ EXERCISE 2 ------------------
            else if (choice == 2)
            {
                Console.Write("Enter xa: ");
                double xa = double.Parse(Console.ReadLine());
                Console.Write("Enter ya: ");
                double ya = double.Parse(Console.ReadLine());
                Console.Write("Enter ra: ");
                double ra = double.Parse(Console.ReadLine());

                Console.Write("Enter xb: ");
                double xb = double.Parse(Console.ReadLine());
                Console.Write("Enter yb: ");
                double yb = double.Parse(Console.ReadLine());
                Console.Write("Enter rb: ");
                double rb = double.Parse(Console.ReadLine());

                double distance = Math.Sqrt(Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2));

                if (distance + rb < ra)
                    Console.WriteLine("B is in A");
                else if (distance + ra < rb)
                    Console.WriteLine("A is in B");
                else if (distance < ra + rb)
                    Console.WriteLine("A and B intersect");
                else
                    Console.WriteLine("A and B do not intersect");
            }

            // ------------------ EXERCISE 3 ------------------
            else if (choice == 3)
            {
                try
                {
                    Console.Write("Enter Basic Salary: ");
                    double basic = double.Parse(Console.ReadLine());

                    if (basic <= 0)
                        throw new Exception("Invalid Salary");

                    double hra = 0.20 * basic;
                    double da = 0.10 * basic;
                    double pf = 0;

                    if (basic >= 15000)
                        pf = 0.12 * basic;

                    double netSalary = basic + hra + da - pf;

                    Console.WriteLine("Net Salary: " + netSalary);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            // ------------------ EXERCISE 4 ------------------
            else if (choice == 4)
            {
                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Connection Type: ");
                string type = Console.ReadLine();

                Console.Write("Previous Reading: ");
                int prev = int.Parse(Console.ReadLine());

                Console.Write("Current Reading: ");
                int curr = int.Parse(Console.ReadLine());

                int units = curr - prev;
                double bill = 0;
                int meterRent = 0;

                if (units <= 100)
                    bill = units * 1.5;
                else if (units <= 250)
                    bill = (100 * 1.5) + (units - 100) * 2.5;
                else if (units <= 550)
                    bill = (100 * 1.5) + (150 * 2.5) + (units - 250) * 4.5;
                else
                    bill = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + (units - 550) * 7.5;

                if (type == "Industrial")
                    meterRent = 2500;
                else if (type == "Business")
                    meterRent = 1500;
                else if (type == "Domestic")
                    meterRent = 1000;
                else
                    meterRent = 0;

                Console.WriteLine("ELECTRICITY BILL");
                Console.WriteLine("Customer ID : " + customerId);
                Console.WriteLine("Name        : " + name);
                Console.WriteLine("Units Used  : " + units);
                Console.WriteLine("Total Bill  : ₹" + (bill + meterRent));
            }

            // ------------------ EXERCISE 5 ------------------
            else if (choice == 5)
            {
                Console.Write("Enter weight: ");
                int weight = int.Parse(Console.ReadLine());

                if (weight < 0 || weight > 120)
                    Console.WriteLine("Invalid Input");
                else if (weight <= 48)
                    Console.WriteLine("light fly");
                else if (weight <= 51)
                    Console.WriteLine("fly");
                else if (weight <= 54)
                    Console.WriteLine("bantam");
                else if (weight <= 57)
                    Console.WriteLine("feather");
                else if (weight <= 60)
                    Console.WriteLine("light");
                else if (weight <= 64)
                    Console.WriteLine("light welter");
                else if (weight <= 69)
                    Console.WriteLine("welter");
                else if (weight <= 75)
                    Console.WriteLine("light middle");
                else if (weight <= 81)
                    Console.WriteLine("middle");
                else if (weight <= 91)
                    Console.WriteLine("light heavy");
                else
                    Console.WriteLine("heavy");
            }

            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
    }
}