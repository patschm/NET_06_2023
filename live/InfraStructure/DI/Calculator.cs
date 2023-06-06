using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{


    public class Calculator : ICalculator
    {
        private int counter = 0;
        public Calculator()
        {
            System.Console.WriteLine(++counter);
        }

        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
    }
}