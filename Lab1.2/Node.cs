namespace Lab1_2
{
    public class Node
    {
        public int[] Data { get; private set; }

        public List<Node> Children { get; private set; }

        public int Difficulty { get
            {
                return GetDifficulty(); 
            } 
        } // => GetDifficulty(); 

        public int Depth { get; private set; }

        public int F1 => Difficulty;

        public Node(int[] data)
        {
            Data = data;
            Children = new();
        }

        public Node(int[] data, int depth)
        {
            Data = data;
            Depth = depth;
            Children = new();
        }

        public int GetDifficulty()
        {
            int result = 0;
            for (int i = 0; i < 8; i++)
            {
                int localResult = 0;
                bool isHorizontal = false; 
                bool isMainDiagonal = false; 
                bool isSideDiagonal = false;
                for (int j = 0; j < 8; j++)
                {
                    if (i == j) continue;
                    if (!isHorizontal && Data[i] == Data[j])
                    {
                        isHorizontal = true;
                        localResult++;
                    }
                    if (!isMainDiagonal && j - i == Data[j] - Data[i])
                    {
                        isMainDiagonal = true;
                        localResult++;
                    }
                    if (!isSideDiagonal && i - j == Data[j] - Data[i])
                    {
                        isSideDiagonal = true;
                        localResult++;
                    }
                }
                if (localResult > 1) localResult -= 1;
                result += localResult;
            }
            return result;
        }

        public void GetStates()
        {
            Children = new List<Node>(); 

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Data[i] == j) continue;
                    int[] temp = new int[8]; 
                    Array.Copy(Data, temp, Data.Length); 
                    temp[i] = j;
                    Children.Add(new Node(temp, Depth + 1));
                }
            }
        }
        public override string ToString()
        {
            string result = "";
            if (Data == null) return "null";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // result += Data[i] == j ? "♛ " : (i + j) % 2 == 0 ? "▓▓" : "░░";
                    result += Data[i] == j ? "1 " : "0 ";
                }
                result += " \n";
            }
            return result;
        }
    }
}
