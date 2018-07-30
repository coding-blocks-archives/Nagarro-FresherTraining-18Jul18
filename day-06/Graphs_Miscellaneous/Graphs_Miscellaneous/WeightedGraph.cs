using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_Miscellaneous
{
    class WeightedGraph<T>
    {
        public Dictionary<T, List<Tuple<T, T>>> adjList { get; private set; }
        public int numVertices { get; private set; }

        public WeightedGraph(int n)
        {
            numVertices = n;
            adjList = new Dictionary<T, List<Tuple<T, T>>>();
        }

        public void AddEdge(T src, T dest, T wt)
        {
            if (adjList.ContainsKey(src) == false)
            {
                adjList.Add(src, new List<Tuple<T, T>>());
            }

            if (adjList.ContainsKey(dest) == false)
            {
                adjList.Add(dest, new List<Tuple<T, T>>());
            }

            adjList[src].Add(new Tuple<T, T>(dest, wt));
            adjList[dest].Add(new Tuple<T, T>(src,wt));
        }
    }

    class GraphUser
    {

        class Edge : IComparable<Edge>
        {
            public int id;
            public int weight;
            public Edge(int id, int wt)
            {
                this.id = id;
                this.weight = wt;
            }

            // COMPARETO
            public /*override*/ int CompareTo(Edge e)
            {
                if (this.weight < e.weight) return -1;
                return 1;
            }
        }


        static int[] Dijkstra(WeightedGraph<int> g, int src)
        {

            PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
            int[] distFrmSrc = new int[g.numVertices];      // distFrmSrc[0]
            bool[] visited = new bool[g.numVertices];

            pq.Push(new Edge(src, 0));

            while (pq.Count() != 0)
            {
                Edge curEdge = pq.Top();
                pq.Pop();

                if (visited[curEdge.id] == true) { continue; }

                visited[curEdge.id] = true;
                distFrmSrc[curEdge.id] = curEdge.weight;

                // for all unvisited nbrs
                List<Tuple<int, int>> curNbrList = g.adjList[curEdge.id];
                for(int i = 0; i < curNbrList.Count; ++i)
                {
                    Tuple<int, int> curNbrWt = curNbrList[i];
                    int curNbr = curNbrWt.Item1;
                    int curWt = curNbrWt.Item2;

                    if (visited[curNbr] == false)
                    {
                        int wtFrmSrc = distFrmSrc[curEdge.id] + curWt;
                        pq.Push(new Edge(curNbr, wtFrmSrc));
                    }
                }
            }
            return distFrmSrc;
        }

        public static void main()
        {
            int numVertices, numEdges;
            numVertices = int.Parse(Console.ReadLine());
            numEdges = int.Parse(Console.ReadLine());
            WeightedGraph<int> g = new WeightedGraph<int>(numVertices);

            for (int curEdge = 0; curEdge < numEdges; ++curEdge)
            {
                int[] srcDest = new int[3];
                Program.InputArray(srcDest);
                g.AddEdge(srcDest[0], srcDest[1], srcDest[2]);
            }

            int src = int.Parse(Console.ReadLine());
            int[] minDist = Dijkstra(g, src);

            foreach(int cur in minDist)
            {
                Console.Write(cur + " ");
            }
        }
    }
}
