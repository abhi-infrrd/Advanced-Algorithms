﻿using Advanced.Algorithms.DataStructures.Graph;
using System.Collections.Generic;

namespace Advanced.Algorithms.Graph
{
    /// <summary>
    /// Bread First Search implementation.
    /// </summary>
    public class BreadthFirst<T>
    {
        /// <summary>
        /// Returns true if item exists.
        /// </summary>
        public bool Find(IGraph<T> graph, T vertex)
        {
            return bfs(graph.ReferenceVertex, new HashSet<T>(), vertex);
        }

        /// <summary>
        /// BFS implementation.
        /// </summary>
        private bool bfs(IGraphVertex<T> referenceVertex,
            HashSet<T> visited, T searchVertex)
        {
            var bfsQueue = new Queue<IGraphVertex<T>>();

            bfsQueue.Enqueue(referenceVertex);
            visited.Add(referenceVertex.Value);

            while (bfsQueue.Count > 0)
            {
                var current = bfsQueue.Dequeue();

                if (current.Value.Equals(searchVertex))
                {
                    return true;
                }

                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.Value))
                    {
                        continue;
                    }

                    visited.Add(edge.Value);
                    bfsQueue.Enqueue(edge.Target);
                }
            }

            return false;
        }
    }
}
