using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Stack_CSharp
{
    class MyClass
    {
        private int x;
    }
    class Program
    {
        static void Main(string[] args)
        {
            OperatorTest();
            Console.ReadLine();
        }
        static void PredicateTest2()
        {
            M_Stack<string> strings = new M_Stack<string>("miras", "didar");
            string x = strings.Find(s => s == "x");
            List<string> strs = new List<string>() { "nuras", "adel" };
            string st = strs.Find(z => z == "x");
            Console.WriteLine(st);
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
        static void OperatorTest()
        {
            M_Stack<int> a = new M_Stack<int>(12, 45);
            M_Stack<int> b = new M_Stack<int>(44, 78, 99);
            M_Stack<int> c = a + b;
            Console.WriteLine(c);
            c.Push(7);
            Console.WriteLine(c);
            Console.WriteLine(c.Size());
        }
    }
}
