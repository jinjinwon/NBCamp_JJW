namespace NB_Camp_Project_8
{
    internal class Loop
    {
        public static Dictionary<string,List<int>> list_Loop = new Dictionary<string,List<int>>();

        static void Main(string[] args)
        {
            // 초기화
            initialize();

            Loop_For();
            Loop_While();
            Loop_doWhile();

            Grid();
        }

        public static void Grid()
        {
            Console.WriteLine("--------------------------------------------------------------");

            #region Color Code
            // RED - FOR문
            Console.Write("|        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("For");
            Console.ResetColor();
            Console.Write("      |");
            // GREEN - WHILE문
            Console.Write("       ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("While");
            Console.ResetColor();
            Console.Write("        |");
            // BLUE - DO-WHILE문
            Console.Write("       ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("do-While");
            Console.ResetColor();
            Console.WriteLine("      |");
            #endregion

            #region Non Color Code
            // 기존
            //Console.WriteLine("|        For      |       While        |       do-While      |");
            #endregion

            Console.WriteLine("--------------------------------------------------------------");

            for(int i = 0; i < list_Loop["For"].Count; i++)
            {
                if(list_Loop["For"][i] < 10)
                {
                    #region Color Code
                    // Red
                    Console.Write("|       ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{list_Loop["For"][i]}");
                    Console.ResetColor();
                    Console.Write("         |");

                    // Green
                    Console.Write("       ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{list_Loop["While"][i]}");
                    Console.ResetColor();
                    Console.Write("            |");

                    // Blue
                    Console.Write("       ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{list_Loop["do-While"][i]}");
                    Console.ResetColor();
                    Console.WriteLine("             |");

                    #endregion

                    #region Non Color Code
                    // 기존
                    //Console.WriteLine($"|       {list_Loop["For"][i]}         |       {list_Loop["While"][i]}            |       {list_Loop["do-While"][i]}             |");
                    #endregion
                }
                else
                {
                    #region Color Code
                    // Red
                    Console.Write("|       ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{list_Loop["For"][i]}");
                    Console.ResetColor();
                    Console.Write("        |");

                    // Green
                    Console.Write("       ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{list_Loop["While"][i]}");
                    Console.ResetColor();
                    Console.Write("           |");

                    // Blue
                    Console.Write("       ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{list_Loop["do-While"][i]}");
                    Console.ResetColor();
                    Console.WriteLine("            |");
                    #endregion

                    #region Non Color Code
                    // 기존
                    //Console.WriteLine($"|       {list_Loop["For"][i]}        |       {list_Loop["While"][i]}           |       {list_Loop["do-While"][i]}            |");
                    #endregion
                }
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

        public static void initialize()
        {
            list_Loop.Add("For", new List<int>());
            list_Loop.Add("While", new List<int>());
            list_Loop.Add("do-While", new List<int>());
        }

        public static void Loop_For()
        {
            for(int i = 1; i <= 100; i++)
            {
                if (i % 2 == 1)
                    list_Loop["For"].Add(i);
            }
        }

        public static void Loop_While()
        {
            int iNumber = 1;
            while(iNumber <= 100)
            {
                if (iNumber % 2 == 1)
                    list_Loop["While"].Add(iNumber);

                iNumber++;
            }
        }

        public static void Loop_doWhile()
        {
            int iNumber = 1;
            do
            {
                if (iNumber % 2 == 1)
                    list_Loop["do-While"].Add(iNumber);

                iNumber++;
            }
            while (iNumber <= 100);
        }
    }
}
