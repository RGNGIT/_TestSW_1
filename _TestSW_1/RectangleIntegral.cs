using System;
using System.Collections.Generic;

namespace _TestSW_1
{
    internal class RectangleIntegral
    {

        public class Answer 
        {
            public List<double> x = new List<double>();
            public List<double> y = new List<double>();
            public double result;
        };

        private Answer answer = new Answer();

        public double f(double x) => (Math.Pow(x, 2) - 0.36) / (x - 2);

        private double RectIntegral(double a, double b, int n)
        {
            double x, h;
            double sum = 0.0;
            double fx;
            h = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                x = a + i * h;
                fx = f(x);
                sum += fx;
            }
            return sum * h;
        }

        void AddPoints(int n, double res)
        {
            answer.x.Add(n);
            answer.y.Add(res);
        }

        public Answer Calculate(double a, double b, int n, double eps)
        {
            double Res = RectIntegral(a, b, n);
            double PrevRes;
            AddPoints(n, Res);
            do
            {
                PrevRes = Res;
                n *= 2;
                Res = RectIntegral(a, b, n);
                AddPoints(n, Res);

            } while (Math.Abs(Res - PrevRes) > eps);
            answer.result = Res;
            return answer;
        }
    }
}
