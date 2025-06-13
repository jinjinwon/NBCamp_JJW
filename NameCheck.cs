namespace NB_Camp_Project_7
{
    internal class NameCheck
    {
        public static bool bExit = false;

        static void Main(string[] args)
        {
            do
            {
                Grid();

                string input = Console.ReadLine();

                if (CheckWord(input) == true)
                {
                    bExit = true;
                    Console.WriteLine($"안녕하세요 ! 제 이름은 {input} 입니다.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"이름을 확인해주세요.");
                }
            }
            while (bExit == false);
        }

        public static void Grid()
        {
            Console.WriteLine("이름을 입력해주세요. (3 ~ 10글자)");
        }

        public static bool CheckWord(string name)
        {
            int length = name.Length;
            return length >= 3 && length <= 10;
        }
    }
}
