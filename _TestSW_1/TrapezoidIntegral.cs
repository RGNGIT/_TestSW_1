using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TestSW_1
{
    internal class TrapezoidIntegral
    {
        const int NUMPOINT = 300;

        private double Integral(double[] f, double step)
        {
            double value = 0;
            for(int i = 0; i < NUMPOINT; i++)
            {
                value += f[i];
            }
            value *= step;
            return value;
        }

        void Calculate()
        {
            double[] f = new double[NUMPOINT];
            double step, t;
            step = Math.PI / NUMPOINT;
            t = 0.0;
            for(int i = 0; i < NUMPOINT; i++)
            {
                // f[i] = 
            }
        }
    }
}
