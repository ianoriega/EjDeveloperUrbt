using NetExam.Abstractions;
using NetExam.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> asd = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            foreach (var item in asd)
            {
                Console.WriteLine(item);
            }

            asd.Clear();

            foreach (var item in asd)
            {
                Console.WriteLine(item);
            }
        }
    }
}
