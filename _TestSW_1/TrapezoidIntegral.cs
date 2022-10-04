using System;
using System.Collections.Generic;

namespace _TestSW_1
{
    internal class TrapezoidIntegral
    {

        public class Answer 
        {
            public List<double> x = new List<double>();
            public List<double> y = new List<double>();
            public double result;
        };

        private Answer answer = new Answer();

        public double f(double x) => x / (Math.Pow(x, 2) - 3 * x + 2);

        private double TrapIntegral(double a, double b, int n, double eps)
        {
            double res1, res2;
            do
            {
                double h = (b - a) / n;
                double x = a;
                double res = 0;
                while (x + h <= b)
                {
                    res += h * (f(x) + f(x + h)) / 2;
                    x += h;
                    answer.x.Add(x);
                    answer.y.Add(res);
                }
                res2 = res;
                n += 1;
                res1 = res;
            } while (Math.Abs(res2 - res1) > eps);
            return res1;
        }

        public Answer Calculate(double a, double b, int n, double eps)
        {
            double Res = TrapIntegral(a, b, n, eps);
            answer.result = Res;
            return answer;
        }
    }
}
