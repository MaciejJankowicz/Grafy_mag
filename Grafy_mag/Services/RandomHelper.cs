using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_mag.Services
{
    public static class RandomHelper
    {
        private static Random rd = new Random();

        static public int NextBitValue(double p = 0.5)
        {
            return rd.NextDouble() <= p ? 1 : 0;
        }
        static public double NextDouble()
        {
            return rd.NextDouble();
        }

        static public int NextInt(int start, int stop)
        {
            return rd.Next(start, stop + 1);
        }
    }
}
