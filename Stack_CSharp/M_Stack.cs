using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace Stack_CSharp
{
    class M_Stack : ICloneable
    {
        // Properties
        private int[] values;
        private int Stack_size { get; set; }
        private int Stack_capacity { get; set; }
        // Constructors
        public M_Stack()
        {
            Stack_capacity = 4;
            Stack_size = 0;
            values = new int[Stack_capacity];
        }
        public M_Stack(M_Stack other)
        {
            Stack_capacity = other.Stack_capacity;
            Stack_size = other.Stack_size;
            values = new int[Stack_capacity];
            for (int i = 0; i < Stack_size; i++)
                values[i] = other.values[i];

        }
        public M_Stack(List<int> other)
        {
            values = new int[4];
            Stack_size = 0;
            Stack_capacity = 4;
            foreach (int i in other) Push(i);
        }
        // Methods
        public void Push(int val)
        {
            if (Stack_size == Stack_capacity)
            {
                Stack_capacity *= 2;
                int[] new_values = new int[Stack_capacity];
                for (int i = 0; i < Stack_size; i++)
                    new_values[i] = values[i];
                values = new_values;
            }
            values[Stack_size] = val;
            Stack_size++;
        }
        public object Clone()
        {
            Console.WriteLine("Cloned");
            M_Stack new_stack = new M_Stack();
            new_stack.Stack_capacity = this.Stack_capacity;
            new_stack.values = new int[Stack_capacity];
            new_stack.Stack_size = this.Stack_size;
            for (int i = 0; i < Stack_size; i++)
                new_stack.values[i] = this.values[i];

            return new_stack;
        }
        public void Print()
        {
            Console.Write("[");
            int i;
            for (i = 0; i < Stack_size - 1; i++)
            {
                Console.Write("{0}, ", values[i]);
            }
            Console.Write(values[i]);
            Console.Write("]");
        }
        public int Size() { return Stack_size; }
        public int Peek()
        {
            if (Stack_size == 0) throw new ArgumentOutOfRangeException("Out of Range.", "Stack is empty.");
            return values[Stack_size - 1];
        }
        public void Pop()
        {
            if (Stack_size == 0) throw new ArgumentOutOfRangeException("Out of Range.", "Stack is empty.");
            Stack_size--;
        }
        public void Clear() { Stack_size = 0; }
        public void Reset(int s)
        {
            if (s < 0) throw new ArgumentOutOfRangeException("Negative input size of Stack.", "Stack size should be non-negative.");
            Stack_size = s;
        }
        public bool Empty()
        {
            return Stack_size == 0;
        }
        
    }
    
}

