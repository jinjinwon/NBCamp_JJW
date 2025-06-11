namespace NB_Camp_Project_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iTen = 10;
            string name = "Jinwon";
            string year = "2025";

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("숫자의 사칙 연산");
            OperationsQueset(iTen);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("문자의 계산");
            StringQuest(name,year);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("논리 연산");
            LogicQuest(iTen);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }

        // 숫자의 사칙 연산
        public static void OperationsQueset(int number)
        {
            Console.WriteLine($"+ : {number + 7} \n - : {number - 3} \n * : {number * 2} \n * : {number * 1.5f} \n / : {number / 3} \n % : {number % 4}");
        }

        // 문자의 계산
        public static void StringQuest(string name, string year)
        {
            Console.WriteLine($"안녕하세요. 제 이름은 \"{name}\" 입니다. \n 올해는 \'{year}\' 입니다.");
        }

        // 논리 연산
        public static void LogicQuest(int number)
        {
            bool result_1 = number == 10 ? true : false;
            bool result_2 = number != 11 ? true : false;
            bool result_3 = number < 20 ? true : false;
            bool result_4 = number > 5 ? true : false;

            Console.WriteLine($" {number} == 10 : {result_1} \n {number} != 11 : {result_2} \n {number} < 20 : {result_3} \n {number} > 5 : {result_4}");
        }
    }
}
