using System.Diagnostics;

namespace Lab1_2
{
    public class Algorithms
    {
        private int _iterations = 0; 

        private int _states = 0; 

        private int _memoryStates = 0;

        public int Iterations => _iterations; 
        public int States => _states;
        public int MemoryStates => _memoryStates;

        public Stopwatch Time = new();

        /// <summary>
        /// Algorythm IDS
        /// </summary>
        /// <param name="array"> start positions </param>
        /// <returns> solution positionds </returns>
        public int[]? IDS(int[] array)
        {
            //Console.WriteLine($"IDS");
            int[]? result = null;
            int limit = 0;

            Time = new Stopwatch();
            Time.Start();

            while (result == null)
            {
                limit++;
                result = DLS(array, limit);
            }

            Time.Stop();
            return result;
        }
        /// <summary>
        /// DLS called by IDS in for loop
        /// </summary>
        /// <param name="array"> start positions </param>
        /// <param name="limit"> current limit </param>
        /// <returns> solution or null if limit reached </returns>
        public int[]? DLS(int[] array, int limit)
        {
            Node initState = new(array);
            return RecursiveDLS(initState, limit);
        }

        /// <summary>
        /// RecursiveDLS called by DLS
        /// </summary>
        /// <param name="node"> node to work with </param>
        /// <param name="limit"> current limit </param>
        /// <returns> solution or null if limit reached </returns>
        public int[]? RecursiveDLS(Node node, int limit)
        {
            //Console.WriteLine($"RecursiveDLS limit: {limit}");
            //Console.WriteLine($"Curdepth: {node.Depth}");
            _iterations++;
            if (node.Depth == limit - 1)
            {
                if (node.Difficulty == 0)
                {
                    Console.WriteLine($"Result Depth: {node.Depth}");
                    return node.Data;
                }
            }
            else if(node.Depth == limit)
            {
                return null;
            } 
            else
            {
                _states++;
                node.GetStates();
                List<Node> successors = node.Children;
                int[]? result;
                _memoryStates = node.Children.Count + 1;
                foreach (Node successor in successors)
                {
                    _iterations++;
                    result = RecursiveDLS(successor, limit);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Algorythm A*
        /// </summary>
        /// <param name="array"> start positions </param>
        /// <returns> solution positions </returns>
        public int[]? AStar(int[] array)
        {
            Time = new Stopwatch();
            Time.Start();

            Node node = new(array);
            var open = new PriorityQueue<Node, int>();
            open.Enqueue(node, node.F1);
            var closed = new List<Node>();
            do
            {
                _iterations++;
                _states++;
                Node currentNode = open.Dequeue();
                closed.Add(currentNode);
                //Console.WriteLine($"Curdepth: {currentNode.Depth}");
                if (currentNode.Difficulty == 0)
                {
                    Time.Stop();
                    //_memoryStates = closed.Count + open.Count;
                    _memoryStates = open.Count;
                    Console.WriteLine($"Result Depth: {currentNode.Depth}");
                    return currentNode.Data;
                }
                currentNode.GetStates();
                List<Node> children = currentNode.Children;
                foreach (Node child in children)
                {
                    _iterations++;
                    if (!Processing.IsInClosed(child, closed))
                    {
                        open.Enqueue(child, child.F1);
                    }
                }
            } while (open.Count != 0);
            Time.Stop();
            return null;
        }
    }
}
