namespace NB_Camp_Project_13
{
    internal class MaxMin
    {
        public static int[] numbers = { 10, 20, 30, 40, 50};

        static void Main(string[] args)
        {
            Grid();
            FindValue();
        }

        public static void Grid()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("최대값 최소값 찾기");

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("현재 내 배열");
            int iCount = 1;
            foreach(var pair in numbers)
            {
                Console.WriteLine($"{iCount} : {pair}");
                iCount++;
            }
        }

        public static void FindValue()
        {
            int MaxNumber = numbers.Max();
            int MinNumber = numbers.Min();

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"최대값 {MaxNumber}         최소값 {MinNumber}");

            // For문으로 찾기
            int iMaxSavedNumber = int.MinValue;
            int iMinSavedNumber = int.MaxValue;

            for(int i = 0; i < numbers.Length; i++)
            {
                if (iMaxSavedNumber < numbers[i])
                    iMaxSavedNumber = numbers[i];

                if(iMinSavedNumber > numbers[i])
                    iMinSavedNumber = numbers[i];
            }

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"For문 : 최대값 {MaxNumber}         최소값 {MinNumber}");
        }
    }
}
