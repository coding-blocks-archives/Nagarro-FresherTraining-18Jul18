using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        Dictionary<String, List<String>> adjList;
        int numVertices;

        public Graph(int numVertices)
        {
            this.numVertices = numVertices;
            adjList = new Dictionary<string, List<string>>();
        }

        public void AddEdge(string src, string dest)
        {
            if (adjList.ContainsKey(src) == false)
            {
                adjList.Add(src, new List<string>());
            }

            if (adjList.ContainsKey(dest) == false)
            {
                adjList.Add(dest, new List<string>());
            }

            adjList[src].Add(dest);
            adjList[dest].Add(src);
        }

        public void dfs(string src)
        {
            HashSet<String> visited = new HashSet<String>();
            dfs(src, visited);
        }

        private void dfs(string src, HashSet<string> visited)
        {
            visited.Add(src);
            Console.Write(src + "---");

            var curList = adjList[src];
            for(int iNbr = 0; iNbr < curList.Count; ++iNbr)
            {
                string curNbr = curList[iNbr];
                if (visited.Contains(curNbr) == false)
                {
                    dfs(curNbr, visited);
                }
            }
        }

        public void PrintGraph()
        {
            Console.WriteLine("----Graph Begins Here---\n");
            for (int iVtx = 0; iVtx < adjList.Count; ++iVtx)
            {
                var curElement = adjList.ElementAt(iVtx);
                Console.Write(curElement.Key + "\t:");

                for (int iNbr = 0; iNbr < curElement.Value.Count; ++iNbr)
                {
                    Console.Write(curElement.Value.ElementAt(iNbr) + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("----Graph Ends Here---\n");
        }

    }

    class GraphUsage
    {
        public static void main()
        {
            // TODO : Try to find C# equivalent
            // freopen("in.txt", "r", Console);

            int numVertices = int.Parse(Console.ReadLine());
            int numEdges = int.Parse(Console.ReadLine());
            Graph g = new Graph(numVertices);

            for(int curEdge = 0; curEdge < numEdges; ++curEdge)
            {
                string edge = Console.ReadLine();
                string[] srcDest = edge.Split(' ');
                g.AddEdge(srcDest[0], srcDest[1]);
            }

            g.PrintGraph()
            g.dfs("Switzerland");
        }
    }
}
