using System;
using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

namespace InsuranceConsoleApp
{
    class Program
    {

        static PolicyService service = new PolicyService();

        static void Main(string[] args)
        {

            // policy data
            service.AddPolicy(new InsurancePolicy(1, "Ravi", "Health", 5000, 10));
            service.AddPolicy(new InsurancePolicy(2, "Sita", "Life", 8000, 15));
            int choice;

            do
            {
                Console.WriteLine("\n--- Insurance Management System ---");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddPolicy();
                        break;

                    case 2:
                        ViewPolicies();
                        break;

                    case 3:
                        SearchPolicy();
                        break;

                    case 4:
                        UpdatePolicy();
                        break;

                    case 5:
                        DeletePolicy();
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }

        static void AddPolicy()
        {
            Console.Write("Policy ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Policy Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Policy Type (Health/Life/Vehicle): ");
            string type = Console.ReadLine();

            Console.Write("Premium Amount: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("Policy Term (years): ");
            int term = int.Parse(Console.ReadLine());

            InsurancePolicy policy =
                new InsurancePolicy(id, name, type, premium, term);

            if (service.AddPolicy(policy))
                Console.WriteLine("Policy added successfully");
            else
                Console.WriteLine("Policy ID already exists");
        }

        static void ViewPolicies()
        {
            var policies = service.GetAllPolicies();

            if (policies.Count == 0)
            {
                Console.WriteLine("No policies found");
                return;
            }

            Console.WriteLine("\n--- Policy List ---");
            foreach (var p in policies)
            {
                Console.WriteLine(p);
            }
        }

        static void SearchPolicy()
        {
            Console.Write("Enter Policy ID: ");
            int id = int.Parse(Console.ReadLine());

            var policy = service.GetPolicyById(id);

            if (policy != null)
                Console.WriteLine(policy);
            else
                Console.WriteLine("Policy not found");
        }

        static void UpdatePolicy()
        {
            Console.Write("Enter Policy ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Premium Amount: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("Enter New Policy Term: ");
            int term = int.Parse(Console.ReadLine());

            if (service.UpdatePolicy(id, premium, term))
                Console.WriteLine("Policy updated successfully");
            else
                Console.WriteLine("Policy not found");
        }

        static void DeletePolicy()
        {
            Console.Write("Enter Policy ID: ");
            int id = int.Parse(Console.ReadLine());

            if (service.DeletePolicy(id))
                Console.WriteLine("Policy deleted successfully");
            else
                Console.WriteLine("Policy not found");
        }
    }
}
