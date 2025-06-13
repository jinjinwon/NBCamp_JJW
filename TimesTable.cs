namespace NB_Camp_Project_12
{
    internal class TimesTable
    {
        static void Main(string[] args)
        {
            TimesTable_Horizontal();
            TimesTable_Vertical();
        }

        public static void TimesTable_Horizontal()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                           가로 구구단                                                             |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (j != 9)
                        Console.Write($"{i} x {j} = {i * j}     ");
                    else
                        Console.WriteLine($"{i} x {j} = {i * j}     ");
                }
            }
        }

        public static void TimesTable_Vertical()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                           세로 구구단                                                             |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 2; j <= 9; j++)
                {
                    if (j != 9)
                        Console.Write($"{j} x {i} = {j * i}     ");
                    else
                        Console.WriteLine($"{j} x {i} = {j * i}     ");
                }
            }
        }
    }
}
