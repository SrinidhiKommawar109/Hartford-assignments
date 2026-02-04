using OOPS_2;
using System.Collections;

namespace OOPS_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int> { 15, 32, 63, 14, 5 };
            //Console.WriteLine("List of Integeres");
            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            //Console.WriteLine("After Sort");
            //numbers.Sort();
            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            Emp e1 = new Emp { EmpName = "John", EmpId = 101, EmpDept = "IT", EmpSalary = 50000 };
            List<Emp> elist = new List<Emp> {
                e1,
                new Emp { EmpName = "Jane", EmpId = 102, EmpDept = "HR", EmpSalary = 45000 },
                new Emp { EmpName = "Mike", EmpId = 103, EmpDept = "Finance", EmpSalary = 45000 },
                new Emp { EmpName = "Sara", EmpId = 104, EmpDept = "IT", EmpSalary = 80000 },
                new Emp { EmpName = "Tom", EmpId = 105, EmpDept = "Marketing", EmpSalary = 67000 }
            };

            Console.WriteLine("List of Employees");
            foreach (Emp emp in elist)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("After Sort on Salary");
            elist.Sort();

            foreach (Emp emp in elist)
            {
                Console.WriteLine(emp);
            }

            //Console.WriteLine("After Sort on Emp Dept");
            //elist.Sort(new DeptwiseComparer());
            Console.WriteLine("After Sort on EmpSal and dept");
            elist.Sort(new SalaryThenDeptwiseComparer());
            foreach (Emp emp in elist)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
