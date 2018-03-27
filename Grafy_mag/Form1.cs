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
            ZoomControl.SetViewFinderVisibility(_zoomctrl, Visibility.Visible);
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
