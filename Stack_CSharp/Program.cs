using System;
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
            Test();
            Console.ReadLine();
        }
        static void Test()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i += 10)
            {
                numbers.Add(i);
            }
            M_Stack stack = new M_Stack(numbers);
            Console.WriteLine(stack[3]);
            // Console.WriteLine(stack); This funtion should work as M_Stack.Print() function
        }
    }
}
