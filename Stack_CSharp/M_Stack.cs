using System;
using System.Collections;
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
    class M_Stack<T> : ICloneable, IEnumerable
    {
        // Properties
        private T[] values;
        private int Stack_size { get; set; }
        private int Stack_capacity { get; set; }
        // Constructors
        public M_Stack()
        {
            Stack_capacity = 4;
            Stack_size = 0;
            values = new T[Stack_capacity];
        }
        public M_Stack(params T[] Ts)
        {
            values = new T[Ts.Length];
            for (int i = 0; i < Ts.Length; i++)
                values[i] = Ts[i];
            Stack_size = Ts.Length;
            Stack_capacity = Ts.Length;
        }
        public M_Stack(M_Stack<T> other)
        {
            Stack_capacity = other.Stack_capacity;
            Stack_size = other.Stack_size;
            values = new T[Stack_capacity];
            for (int i = 0; i < Stack_size; i++)
                values[i] = other.values[i];

        }
        public M_Stack(List<T> other)
        {
            values = new T[other.Count];
            Stack_size = 0;
            Stack_capacity = 4;
            foreach (T i in other) Push(i);
        }
        // Methods
        public void Push(T val)
        {
            if (Stack_size == Stack_capacity)
            {
                Stack_capacity *= 2;
                T[] new_values = new T[Stack_capacity];
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
            M_Stack<T> new_stack = new M_Stack<T>();
            new_stack.Stack_capacity = this.Stack_capacity;
            new_stack.values = new T[Stack_capacity];
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
        public T Peek()
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
            if (s < 0) throw new ArgumentOutOfRangeException("Reset(int s)", "Stack size should be non-negative.");
            if (s > Stack_capacity) throw new ArgumentOutOfRangeException("Reset(int s)", "Argument of Reset(int i) should be less than Stack capacity");
            Stack_size = s;
        }
        public bool Empty()
        {
            return Stack_size == 0;
        }
        public T this[int i] 
        {
            get 
            {
                if (i < 0 || i >= Stack_size)
                    throw new ArgumentOutOfRangeException("Out of range.", String.Format("Index {0} is not in the range of Stack.", i));
                return values[i]; 
            }
        }
        public override string ToString()
        {
            string s = "[";
            int i = 0;
            for (; i < Stack_size - 1; i++)
                s += String.Format(values[i].ToString() + ", ");
            s += String.Format(values[i].ToString() + "]");
            return s;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (T x in values)
                yield return x;
        }
        public M_Stack<T> FindAll(Predicate<T> predicate)
        {
            M_Stack<T> new_stack = new M_Stack<T>();
            foreach (T x in values)
            {
                if (predicate(x))
                {
                    new_stack.Push(x);
                }
            }
            return new_stack;
        }
        public T Find(Predicate<T> predicate)
        {
            foreach (T x in values)
                if (predicate(x))
                    return x;
            return default(T);
        }
    }
}

