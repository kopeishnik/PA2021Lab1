namespace Lab1_2
{
    public static class Processing
    {
        public static int[] Generate()
        {
            Random random = new(); 
            int[] array = new int[8];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(8);
                // array[i] = i;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Swap(ref array[i], ref array[random.Next(0, 8)]);
            }
            return array;
        }
        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
        public static string Visualize(int[] array)
        {
            string result = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // result += Data[i] == j ? "♛ " : (i + j) % 2 == 0 ? "▓▓" : "░░";
                    result += array[i] == j ? "1 " : "0 ";
                }
                result += " \n";
            }
            return result;
        }
        public static bool IsInClosed(Node child, List<Node> closed)
        {
            foreach (var node in closed)
            {
                if (AreBoarsEqual(child, node))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool AreBoarsEqual(Node n1, Node n2)
        {
            int[] arr1 = n1.Data, arr2 = n2.Data;
            for (int i = 0; i < 8; i++) 
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }
    }
}