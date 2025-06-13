namespace NB_Camp_Project_10
{
    internal class Factorial_
    {
        public static bool bExit = false;

        static void Main(string[] args)
        {
            while (bExit == false)
            {
                Console.WriteLine("숫자를 입력해주세요.");
                string input = Console.ReadLine();

                if (ulong.TryParse(input, out ulong result))
                {
                    Console.WriteLine($"{Factorial(result)}");
                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
        }

        // int로는 다 안됨 ㅇㅇ.. long으로
        public static ulong Factorial(ulong inputValue)
        {
            if (inputValue == 0 || inputValue == 1)
                return 1;

            return inputValue * Factorial(inputValue - 1);
        }
    }
}
