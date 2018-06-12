using Grafy_mag.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_mag.Models
{
    public struct Cycle
    {
        public int[] Nodes { get; set; }

        public int GetCost(int[][] perms)
        {
            return Nodes != null ? Helper.CountCost(perms, Nodes) : Int32.MaxValue;
        }

        public string GetCyclesString()
        {
            string ToReturn = "";
            for (int i = 0; i < Nodes.Count(); i++)
            {
                ToReturn += Nodes[i].ToString() + "-";
            }
            if (ToReturn.Last() == '-')
            {
                ToReturn = ToReturn.Remove(ToReturn.Length - 1);
            }
            return ToReturn;
        }
    }

    public class Population
    {
        public List<Cycle> Cycles { get; set; } = new List<Cycle>();
        public int NodeCount { get; set; }

        public Population(int count, int nodeCount)
        {
            NodeCount = nodeCount;
            for (int i = 0; i < count; i++)
            {
                Cycles.Add(new Cycle { Nodes = Helper.GetRandomCycle(NodeCount) });
            }
        }

        public Cycle GetBest(int[][] perms)
        {
            Cycle best = new Cycle();
            foreach (Cycle cycle in Cycles)
            {
                if (cycle.GetCost(perms) < best.GetCost(perms))
                {
                    best = cycle;
                }
            }
            return best;
        }

        public List<List<Cycle>> Split(int parts)
        {
            List<List<Cycle>> toReturn = new List<List<Cycle>>(parts);
            if (Cycles.Count < parts)
            {
                return null;
            }

            for (int i = 0; i < parts; i++)
            {
                toReturn.Add(new List<Cycle>());
            }

            int k = 0;
            foreach (var cycle in Cycles)
            {
                toReturn[k].Add(cycle);

                if (++k >= parts)
                {
                    k = 0;
                }
            }
            return toReturn;
        }

    }
}
