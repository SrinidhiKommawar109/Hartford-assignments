// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main(string[] args)
    {
       List<int> Numbers = new List<int>{10,21,13, 24, 45};
       var where = Numbers.Where(n => n > 25);
       var select = Numbers.Select(n => n);
       var first = Numbers.First();//first element
       var first_condition = Numbers.First(n => n > 15);
       var sorted = Numbers.OrderBy( n => n);
       var sorted_desc = Numbers.OrderByDescending( n => n);
       int count = Numbers.Count();
       int count_condition = Numbers.Count(n => n > 15);
       bool exists = Numbers.Any( n => n > 40);
       bool all = Numbers.All(n => n > 5);
       var data = Numbers.Take(5);
       var skip = Numbers.Skip(5);
       var data_skip = Numbers.Skip(5).Take(5);
       var list = Numbers.Where(n => n >10).ToList();
        foreach(var r in where)
        {
            Console.WriteLine(r);
        }
        Console.WriteLine("-----------------");
        foreach(var r in select)
        {
            Console.WriteLine(r);
        }
        Console.WriteLine("-----------------");
        Console.WriteLine(first);
        Console.WriteLine("-----------------");
        Console.WriteLine(first_condition);
        Console.WriteLine("-----------------");
         foreach(var r in sorted)
        {
            Console.WriteLine(r);
        }
        Console.WriteLine("-----------------");
         foreach(var r in sorted_desc)
        {
            Console.WriteLine(r);
        }
        Console.WriteLine("-----------------");
        Console.WriteLine(count);
        Console.WriteLine(count_condition);
        Console.WriteLine(exists);
        Console.WriteLine(all);
        Console.WriteLine("-----------------");
        foreach(var r in data)
        {
            Console.WriteLine(r);
        }
         foreach(var r in skip)
        {
            Console.WriteLine(r);
        }
         foreach(var r in data_skip)
        {
            Console.WriteLine(r);
        }
    
    }
}