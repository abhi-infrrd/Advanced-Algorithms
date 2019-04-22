﻿using Advanced.Algorithms.DataStructures.Graph;
using Advanced.Algorithms.DataStructures.Graph.AdjacencyList;
using System.Collections.Generic;

namespace Advanced.Algorithms.Graph
{
    /// <summary>
    /// Find Toplogical order of a graph using Depth First Search.
    /// </summary>
    public class DepthFirstTopSort<T>
    {
        /// <summary>
        /// Returns the vertices in Topologically Sorted Order.
        /// </summary>
        public List<T> GetTopSort(IDiGraph<T> graph)
        {
            var pathStack = new Stack<T>();
            var visited = new HashSet<T>();

            //we need a loop so that we can reach all vertices
            foreach(var vertex in graph)
            {
                if(!visited.Contains(vertex.Value))
                {
                    dfs(vertex, visited, pathStack);
                }
                
            }

            //now just pop the stack to result
            var result = new List<T>();
            while(pathStack.Count > 0)
            {
                result.Add(pathStack.Pop());
            }

            return result;
        }

        /// <summary>
        /// Do a depth first search.
        /// </summary>
        private void dfs(IDiGraphVertex<T> vertex, 
            HashSet<T> visited, Stack<T> pathStack)
        {
            visited.Add(vertex.Value);

            foreach(var edge in vertex.OutEdges)
            {
                if(!visited.Contains(edge.Value))
                {
                    dfs(edge.Target, visited, pathStack);
                }
            }

            //add vertex to stack after all edges are visited
            pathStack.Push(vertex.Value);
        }
    }
}
