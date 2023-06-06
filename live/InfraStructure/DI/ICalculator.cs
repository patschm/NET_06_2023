using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }
}