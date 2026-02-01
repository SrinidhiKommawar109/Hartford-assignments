using System;

namespace Day_1;

class Arthimetic_operators
{
    public static void Basic(int a, int b)
    {
        Int32 sum = a + b;
        int diff = a - b;
        int mul = a * b;
        int div = a / b;

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Difference: " + diff);
        Console.WriteLine("Multiplication: " + mul);
        Console.WriteLine("Division: " + div);
    }
}

class Conditions
{
    public static void Min_Max(int[] arr)
    {
        int max = arr[0], min = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max) max = arr[i];
            if (arr[i] < min) min = arr[i];
        }

        Console.WriteLine("Maximum Element: " + max);
        Console.WriteLine("Minimum Element: " + min);
    }
}

class Prime
{
    public static void prime_composite(int number)
    {
        bool isprime = true;

        if (number <= 1)
        {
            isprime = false;
        }

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                isprime = false;
                break;
            }
        }

        if (isprime)
        {
            Console.WriteLine(number + " is a Prime number");
        }
        else
        {
            Console.WriteLine(number + " is not a Prime number");
        }
    }
}
class Sum_Array
{
    public static void Array_sum()
    {
        Console.Write("Enter the number of elements: ");
        int n = int.Parse(Console.ReadLine()!);

        int[] arr = new int[n];
        int sum = 0;

        Console.WriteLine("Enter the array elements:");

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine()!);
            sum += arr[i];
        }

        Console.WriteLine("Sum of array elements: " + sum);
    }
}

class Factorial
{
    public static void Factorial_number(int number)
    {
        int fact = 1;
        for(int i = 1; i <= number; i++)
        {
            fact = fact * i;
        }
        Console.WriteLine("Factorial of a number is"+ fact);
    }
}
class Program
{
    static void Main()
    {
        Arthimetic_operators.Basic(5, 3);
        Conditions.Min_Max(new int[] { 1, 2, 3, 4, 5 });
        Prime.prime_composite(17);
        Sum_Array.Array_sum();
        Factorial.Factorial_number(5);
    }
}
