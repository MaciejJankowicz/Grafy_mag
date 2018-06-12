using Grafy_mag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_mag.Services
{
    public class CrossOver
    {
        public static List<Cycle> CrossCycles(List<Cycle> pairingCycles)
        {
            int cyclesCount = pairingCycles.Count;
            List<Cycle> toReturn = new List<Cycle>();
            if ((pairingCycles.Count % 2) != 0)
            {
                toReturn.Add(pairingCycles[pairingCycles.Count - 1]);
                cyclesCount--;
            }

            for (int i = 0; i < cyclesCount; i += 2)
            {
               toReturn.AddRange( CrossPair(pairingCycles[i], pairingCycles[i + 1]) );                
            }

            return toReturn;
        }

        public static List<Cycle> CrossPair(Cycle one, Cycle two)
        {
            for (int i = 0; i < one.Nodes.Length; i++)
            {

            }
            return null;
        }
    }
}
