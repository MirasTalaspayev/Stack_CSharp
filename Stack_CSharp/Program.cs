﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Stack_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PredicateTest();
            Console.ReadLine();
        }
        static void PredicateTest()
        {
            M_Stack<int> ints = new M_Stack<int>(1, 2, 3, 5);
            M_Stack<int> odds = ints.FindAll(x => x % 2 == 1);
            odds.Print();
        }
        static void Test()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i += 10)
            {
                numbers.Add(i);
            }
            M_Stack<int> stack = new M_Stack<int>(numbers);
            Console.WriteLine(stack[3]);
            Console.WriteLine(stack);
        }
        static void Test_String()
        {
            List<string> m = new List<string>() { "miras", "didar", "adel", "someone" };
            M_Stack<string> m_Stack = new M_Stack<string>(m);
            Console.WriteLine(m_Stack);
            foreach (string s in m) Console.WriteLine(s + ". Now foreach loop works!");
        }
    }
}
