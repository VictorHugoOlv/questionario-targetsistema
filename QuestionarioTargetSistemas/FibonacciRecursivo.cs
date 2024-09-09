using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestionarioTargetSistemas
{
    public class FibonacciRecursivo
    {
        public bool Operacao(int n, int a = 0, int b = 1)
        {
            Console.Write($"{a} ");

            return n >= 0 && (a == n || (a <= n && Operacao(n, b, a + b)));
        }

    }
}
