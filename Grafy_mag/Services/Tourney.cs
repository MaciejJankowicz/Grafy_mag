using Grafy_mag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_mag.Services
{
    public class Tourney
    {
        public static List<Cycle> Eliminate(List<Cycle> competingCycles, int[][] permutationsMatrix)
        {
            int competitorCount = competingCycles.Count;
            List<Cycle> toReturn = new List<Cycle>();
            if ( (competingCycles.Count % 2) != 0)
            {
                toReturn.Add(competingCycles[competingCycles.Count - 1]);
                competitorCount--;
            }

            for (int i = 0; i < competitorCount; i+=2)
            {
                int one = competingCycles[i].GetCost(permutationsMatrix);
                int two = competingCycles[i+1].GetCost(permutationsMatrix);
                toReturn.Add(one < two ? competingCycles[i] : competingCycles[i + 1]);
            }

            return toReturn;
        }
    }
}
