using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PractiseThreading
{
    internal class Program
    {
        struct ObjectArray
        {
            object[] array;
            public void SetArray(object[] array)
            {
                this.array = array;
            }
            public void InitArray(int count)
            {
                this.array = new object[count];
            }
        }
        public static void Thread(object array)
        {
            ObjectArray arr = (ObjectArray)array;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(arr.ToString());
            }

        }
        static void Main(string[] args)
        {
            ObjectArray objectArray= new ObjectArray();
            objectArray.InitArray(10);
            Thread th = new Thread(new ParameterizedThreadStart(Thread));
            th.IsBackground = true;
            th.Start(objectArray);
        }
    }
}
