using Grafy_mag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_mag.Services
{
    public class MutationNodeSwap
    {
        public static Cycle Mutation(Cycle source, double mutationProbability)
        {
            int cycleLength = source.Nodes.Length;

            if (cycleLength < 2)
                return source;

            if (RandomHelper.NextDouble() > mutationProbability)
                return source;

            int pos1 = RandomHelper.NextInt(0, cycleLength - 1);
            int pos2;
            do
            {
                pos2 = RandomHelper.NextInt(0, cycleLength - 1);
            } while (pos2 == pos1);

            int tmp = source.Nodes[pos1];
            source.Nodes[pos1] = source.Nodes[pos2];
            source.Nodes[pos2] = tmp;

            if (pos1 == 0 || pos2 == 0)
            {
                source.Nodes[cycleLength - 1] = source.Nodes[0];
            }
            if (pos1 == cycleLength - 1 || pos2 == cycleLength - 1)
            {
                source.Nodes[0] = source.Nodes[cycleLength - 1];
            }

            return source;
        }
    }
}
