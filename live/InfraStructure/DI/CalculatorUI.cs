using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public class CalculatorUI
    {
        private readonly ICalculator _calc;

        public CalculatorUI(ICalculator calc)
        {
            _calc = calc;
        }

        public void Run()
        {
            System.Console.WriteLine("Geef getal A");
            int.TryParse(Console.ReadLine(), out int a);

             System.Console.WriteLine("Geef getal B");
            int.TryParse(Console.ReadLine(), out int b);

            int result = _calc.Add(a, b);
            System.Console.WriteLine($"Whooohoo!!! {result}");

        }
    }
}