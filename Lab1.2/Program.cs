namespace Lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //int[] array = {4, 5, 6, 3, 2, 4, 7, 0};
            //int[] array = {0, 0, 0, 0, 0, 0, 0, 0};
            int[] array = Processing.Generate();

            Console.WriteLine("Current table:"); 
            Console.WriteLine(Processing.Visualize(array));

            Algorithms search = new();

            Console.WriteLine("Algorithm: IDS"); 
            int[]? result = search.IDS(array);

            //Console.WriteLine("Algorithm: A*"); int[]? result2 = search.AStar(array); 

            if (result != null)
            {
                Console.WriteLine("Iterations: " + search.Iterations);
                Console.WriteLine("States: " + search.States);
                Console.WriteLine("States in memory: " + search.MemoryStates);
                Console.WriteLine("Time: " + search.Time.ElapsedMilliseconds + " mS");
                Console.WriteLine();

                Console.WriteLine("Result table:");
                Console.WriteLine(Processing.Visualize(result));
            }
            else
            {
                Console.WriteLine("Cannot find solution!");
            }

            Algorithms search2 = new();

            Console.WriteLine("Algorithm: A*"); int[]? result2 = search2.AStar(array);

            if (result2 != null)
            {
                Console.WriteLine("Iterations: " + search2.Iterations);
                Console.WriteLine("States: " + search2.States);
                Console.WriteLine("States in memory: " + search2.MemoryStates);
                Console.WriteLine("Time: " + search2.Time.ElapsedMilliseconds + " mS");
                Console.WriteLine();

                Console.WriteLine("Result table:");
                Console.WriteLine(Processing.Visualize(result2));
            }
            else
            {
                Console.WriteLine("Cannot find solution!");
            }
        }
    }
}