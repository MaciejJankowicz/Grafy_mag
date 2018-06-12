using Grafy_mag.Models;
using Grafy_mag.Services;
using GraphX.Controls;
using GraphX.Controls.Models;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms.OverlapRemoval;
using GraphX.PCL.Logic.Models;
using QuickGraph;
using SimpleGraph.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;

namespace Grafy_mag
{
    public partial class Form1 : Form
    {
        public const int penalty = 1000;
        public const int functions = 3;

        private ZoomControl _zoomctrl;
        private GraphAreaGeneric _gArea;
        private int layer = 0;
        Random R = new Random();
        bool hideOtherEdges = false;
        public List<string[]>[] InputPermutations { get; private set; } = new List<string[]>[functions];
        public List<int>[] LackingEdges { get; private set; }
        public List<DataVertex> Vertices { get; private set; }

        public Form1()
        {
            InitializeComponent();
            InitData();

            Load += Form1_Load;
        }

        void InitData()
        {
            for (int i = 0; i < functions; i++)
            {
                InputPermutations[i] = new List<string[]>();
                using (var reader = new StreamReader(@"..\..\permutacje"+(i+1)+".csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        InputPermutations[i].Add(values);
                    }
                }
            }                           
        }

        void Form1_Load(object sender, EventArgs e)
        {
            wpfHost.Child = GenerateWpfVisuals();
            _gArea.GenerateGraph(true);
            _gArea.SetVerticesDrag(true, true);
            _zoomctrl.ZoomToFill();
        }

        private UIElement GenerateWpfVisuals()
        {
            _zoomctrl = new ZoomControl();
            ZoomControl.SetViewFinderVisibility(_zoomctrl, Visibility.Hidden);
            var logic = new GXLogicCore<DataVertex, DataEdge, BidirectionalGraph<DataVertex, DataEdge>>();
            _gArea = new GraphAreaGeneric
            {
                 //EnableWinFormsHostingMode = false,
                LogicCore = logic,
                EdgeLabelFactory = new DefaultEdgelabelFactory()
            }; 
            _gArea.ShowAllEdgesLabels(true);
            _gArea.SetEdgesDashStyle(EdgeDashStyle.Solid);
            _gArea.ShowAllEdgesArrows(false);

            logic.Graph = GenerateGraph();           
            logic.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.LinLog;
            logic.DefaultLayoutAlgorithmParams = logic.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.LinLog);
            //((LinLogLayoutParameters)logic.DefaultLayoutAlgorithmParams). = 100;
            logic.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
            logic.DefaultOverlapRemovalAlgorithmParams = logic.AlgorithmFactory.CreateOverlapRemovalParameters(OverlapRemovalAlgorithmTypeEnum.FSA);
            ((OverlapRemovalParameters)logic.DefaultOverlapRemovalAlgorithmParams).HorizontalGap = 50;
            ((OverlapRemovalParameters)logic.DefaultOverlapRemovalAlgorithmParams).VerticalGap = 50;
            logic.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.None;
            logic.AsyncAlgorithmCompute = false;
            _zoomctrl.Content = _gArea;

            _gArea.RelayoutFinished += gArea_RelayoutFinished;


            var myResourceDictionary = new ResourceDictionary { Source = new Uri("Templates\\template.xaml", UriKind.Relative) };
            _zoomctrl.Resources.MergedDictionaries.Add(myResourceDictionary);

            return _zoomctrl;
        }

        void gArea_RelayoutFinished(object sender, EventArgs e)
        {
            _zoomctrl.ZoomToFill();
        }     

        private void Btn_generate_Click(object sender, EventArgs e)
        {
            _gArea.ClearLayout(true,true,false);
            _gArea.LogicCore.Graph.Clear();
            _gArea.LogicCore.Graph = GenerateGraph();
            _gArea.GenerateGraph(true);
            _gArea.SetVerticesDrag(true, true);
            _zoomctrl.ZoomToFill();
            //_gArea.RelayoutGraph();
        }        
        private GraphGeneric GenerateGraph()
        {
            Vertices = new List<DataVertex>();
            var dataGraph = new GraphGeneric();
            int nodeCount = InputPermutations[0].Count;
            double probability = Convert.ToDouble(txb_prob.Text, CultureInfo.InvariantCulture);

            LackingEdges = new List<int>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                LackingEdges[i] = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    if (R.NextDouble() >= probability)
                    {
                        LackingEdges[j].Add(i);
                    }
                }
            }

            int[][] permutationsMatrix = MakePermutationsMatrix(0);           
            for (int i = 0; i < nodeCount; i++)
            {
                var dataVertex = new DataVertex(i.ToString());
                Vertices.Add(dataVertex);
                dataGraph.AddVertex(dataVertex);
            }

            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (permutationsMatrix[i][j] >= penalty)
                    {
                        dataGraph.AddEdge(new DataEdge(Vertices[j], Vertices[i], permutationsMatrix[i][j]) {EdgeColor = Colors.Red} );
                    }
                    dataGraph.AddEdge(new DataEdge(Vertices[j], Vertices[i], permutationsMatrix[i][j]));
                }
            }

            return dataGraph;
        }
        int[][] MakePermutationsMatrix(int functionNum)
        {
            int nodeCount = InputPermutations[0].Count;
            int[][] permutationsMatrix = new int[nodeCount][];
            for (int i = 0; i < nodeCount; i++)
            {
                permutationsMatrix[i] = new int[i];
                for (int j = 0; j < i; j++)
                {
                    if (LackingEdges[j].Count > 0 && LackingEdges[j].Contains(i))
                    {
                        permutationsMatrix[i][j] = penalty;
                    }
                    else
                    {
                        permutationsMatrix[i][j] = Convert.ToInt32(InputPermutations[functionNum][i][j]);
                    }
                }
            }
            return permutationsMatrix;
        }

        private void Btn_reload_Click(object sender, EventArgs e)
        {
            _gArea.RelayoutGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideOtherEdges = !hideOtherEdges;
            int[] cycle = Helper.GetRandomCycle(Vertices.Count);
            DataEdge[] edges = new DataEdge[Vertices.Count];
            DataEdge edge;
            Tuple<int, int> nodes;

            if (hideOtherEdges)
            {
                for (int i = 0; i < Vertices.Count - 1; i++)
                {
                    nodes = Helper.OrderNodes(cycle[i], cycle[i + 1]);
                    _gArea.LogicCore.Graph.TryGetEdge(Vertices[nodes.Item1], Vertices[nodes.Item2], out edge);
                    edge.EdgeColor = Colors.Green;
                    edges[i] = edge;
                }
                nodes = Helper.OrderNodes(cycle[0], cycle[Vertices.Count - 1]);
                _gArea.LogicCore.Graph.TryGetEdge(Vertices[nodes.Item1], Vertices[nodes.Item2], out edge);
                edge.EdgeColor = Colors.Green;
                edges[Vertices.Count - 1] = edge;

                _gArea.GenerateAllEdges();
            }           

            foreach (var item in _gArea.EdgesList)
            {
                if (!edges.Contains(item.Key))
                {
                    item.Value.ShowLabel = !hideOtherEdges;
                    item.Key.IsVisible = !hideOtherEdges;
                    if (item.Key.EdgeColor != Colors.Red)
                    {
                        item.Key.EdgeColor = Colors.Blue;
                    }                    
                    if (hideOtherEdges)
                    {                       
                        item.Value.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        item.Value.Visibility = Visibility.Visible;
                    }                   
                }
            }

            //TestMut();
            //TestSplit();
            //TestTourney();
        }

        private void TestTourney()
        {
            var pop = new Population(121, Vertices.Count);
            var split = pop.Split(3);
            var t1 = Tourney.Eliminate(split[0], MakePermutationsMatrix(0));
            var t2 = Tourney.Eliminate(split[1], MakePermutationsMatrix(1));
            var t3 = Tourney.Eliminate(split[2], MakePermutationsMatrix(2));
        }

        private void TestSplit()
        {
            var pop = new Population(120, Vertices.Count);
            var split = pop.Split(3);
        }

        private void TestMut()
        {
            int[][] cycles = new int[100][];
            List<Tuple<int, int[]>> mutated = new List<Tuple<int, int[]>>();
            for (int i = 0; i < 100; i++)
            {
                cycles[i] = Helper.GetRandomCycle(Vertices.Count);
                var mut = MutationNodeSwap.Mutation(new Models.Cycle() { Nodes = (int[])(cycles[i].Clone()) }, 0.5);
                if (!mut.Nodes.IsSame(cycles[i]))
                {
                    mutated.Add(new Tuple<int, int[]>(i, mut.Nodes));
                }
            }
        }

        private void btn_next_weights_Click(object sender, EventArgs e)
        {
            layer++;
            if (layer > functions-1)
            {
                layer = 0;
            }
            lbl_weight_layer.Text = (layer +1).ToString();
            int[][] weights = MakePermutationsMatrix(layer);

            DataEdge edge;
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    _gArea.LogicCore.Graph.TryGetEdge(Vertices[j], Vertices[i], out edge);
                    edge.Weight = weights[i][j];
                }               
            }
            GenerateEdges();
        }

        private void GenerateEdges()
        {
            _gArea.GenerateAllEdges();

            foreach (var item in _gArea.EdgesList)
            {
                item.Value.ShowLabel = item.Key.IsVisible;
                if (!item.Key.IsVisible)
                {
                    item.Value.Visibility = Visibility.Hidden;
                }
                else
                {
                    item.Value.Visibility = Visibility.Visible;
                }
            }

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            double mutationProbability = Convert.ToDouble(txb_mut_prob.Text, CultureInfo.InvariantCulture);
            int popCount = Convert.ToInt32(txb_pop_size.Text, CultureInfo.InvariantCulture);
            int iterations = Convert.ToInt32(txb_iter_count.Text, CultureInfo.InvariantCulture);

            var pop = new Population(popCount, Vertices.Count);
            int[][][] matrices = new int[functions][][];
            for (int i = 0; i < functions; i++)
            {
                matrices[i] = MakePermutationsMatrix(i);
            }

            List<Cycle> pareto = new List<Cycle>();
            Cycle[] bestCycles = new Cycle[functions];
            List<ListViewItem>[] sums = new List<ListViewItem>[functions];
            for (int k = 0; k < functions; k++)
            {
                pareto.Add(pop.GetBest(matrices[k]));
                bestCycles[k] = pop.GetBest(matrices[k]);

                sums[k] = new List<ListViewItem>(iterations + 1);
                sums[k].Add(new ListViewItem());
                sums[k][0].Text = pop.Cycles.Sum(x => x.GetCost(matrices[k])).ToString();
            }

            for (int i = 1; i <= iterations; i++)
            {
                pop = GeneticIteration.Next(pop, functions, matrices, mutationProbability);
                pareto.UpdatePareto(pop, matrices);

                for (int k = 0; k < functions; k++)
                {
                    Cycle currentBest;
                    if ((currentBest = pop.GetBest(matrices[k])).GetCost(matrices[k]) < bestCycles[k].GetCost(matrices[k]))
                    {
                        bestCycles[k] = currentBest;
                    }

                    sums[k].Add(new ListViewItem());
                    sums[k][i].Text = pop.Cycles.Sum(x => x.GetCost(matrices[k])).ToString();
                }

                lbl_iter.Text =(i).ToString();

                lbl_best1_cycle.Text = bestCycles[0].GetCyclesString();
                lbl_best1_cost.Text = bestCycles[0].GetCost(matrices[0]).ToString();

                lbl_best2_cycle.Text = bestCycles[1].GetCyclesString();
                lbl_best2_cost.Text = bestCycles[1].GetCost(matrices[1]).ToString();

                lbl_best3_cycle.Text = bestCycles[2].GetCyclesString();
                lbl_best3_cost.Text = bestCycles[2].GetCost(matrices[2]).ToString();

                listView1.Items.Clear();
                listView1.Items.AddRange(sums[0].ToArray());
                listView2.Items.Clear();
                listView2.Items.AddRange(sums[1].ToArray());
                listView3.Items.Clear();
                listView3.Items.AddRange(sums[2].ToArray());
                this.Refresh();
            }

            List<ListViewCycle> paretoItems = new List<ListViewCycle>();
            foreach (var item in pareto)
            {
                paretoItems.Add(new ListViewCycle() { Cycle = item, Text = $"{item.GetCyclesString()} : {item.GetCost(matrices[0])};{item.GetCost(matrices[1])};{item.GetCost(matrices[2])}" });
            }
            listView4.Items.Clear();
            listView4.Items.AddRange(paretoItems.ToArray());
            Excel.WritePareto(pareto, matrices);       
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lsv = (ListView) sender;
            if (lsv.SelectedItems.Count <= 0)
            {
                SelectCycle(null);
                return;
            }
            var s = (ListViewCycle)(lsv.SelectedItems[0]);
            SelectCycle(s.Cycle);
        }
        void SelectCycle(Cycle? c)
        {
            hideOtherEdges = (c != null) ? true : false;
            int[] cycle = null;
            if (c != null)
            {
                cycle = ((Cycle)(c)).Nodes;
            }
            DataEdge[] edges = new DataEdge[Vertices.Count];
            DataEdge edge;
            Tuple<int, int> nodes;

            if (hideOtherEdges)
            {
                for (int i = 0; i < Vertices.Count - 1; i++)
                {
                    nodes = Helper.OrderNodes(cycle[i], cycle[i + 1]);
                    _gArea.LogicCore.Graph.TryGetEdge(Vertices[nodes.Item1], Vertices[nodes.Item2], out edge);
                    edge.EdgeColor = Colors.Green;
                    edges[i] = edge;
                }
                nodes = Helper.OrderNodes(cycle[0], cycle[Vertices.Count - 1]);
                _gArea.LogicCore.Graph.TryGetEdge(Vertices[nodes.Item1], Vertices[nodes.Item2], out edge);
                edge.EdgeColor = Colors.Green;
                edges[Vertices.Count - 1] = edge;

                _gArea.GenerateAllEdges();
            }

            foreach (var item in _gArea.EdgesList)
            {
                if (!edges.Contains(item.Key))
                {
                    item.Value.ShowLabel = !hideOtherEdges;
                    item.Key.IsVisible = !hideOtherEdges;
                    if (item.Key.EdgeColor != Colors.Red)
                    {
                        item.Key.EdgeColor = Colors.Blue;
                    }
                    if (hideOtherEdges)
                    {
                        item.Value.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        item.Value.Visibility = Visibility.Visible;
                    }
                }
            }

            if (!hideOtherEdges)
            {
                _gArea.GenerateAllEdges();
            }
            
        }

    }

    public class EdgeColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush((System.Windows.Media.Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public struct Edge
    {
        public int NodeFirst { get; set; }
        public int NodeSecond { get; set; }
        public int Weight { get; set; }

        public Edge(int nodeFirst, int nodeSecond, int weight)
        {
            if (nodeSecond < nodeFirst)
            {
                int t = nodeFirst;
                nodeFirst = nodeSecond;
                nodeSecond = t;
            }

            this.NodeFirst = nodeFirst;
            this.NodeSecond = nodeSecond;
            this.Weight = weight;
        }
    }

}
