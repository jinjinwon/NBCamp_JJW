using System.Text;

namespace NB_Camp_Project_3
{
    internal class Program
    {
        private static readonly string ErrorMessage = "문자열 입니다.";
        private static StringBuilder NoticeMessage;

        static void Main(string[] args)
        {
            Console.WriteLine($"숫자나 문자 중 입력해주세요.");

            string input = Console.ReadLine();
            Console.WriteLine($"입력한 값은 {input} 입니다.");

            NoticeMessage = new StringBuilder();
            InputQuest(input);
        }

        public static void InputQuest(string inputWord)
        {
            if (BooleanCheck(inputWord))
                Console.WriteLine(NoticeMessage);
            else if (integerCheck(inputWord))
                Console.WriteLine(NoticeMessage);
            else
                Console.WriteLine(NoticeMessage);
        }

        // Bool값인지 체크
        public static bool BooleanCheck(string inputWord)
        {
            if (bool.TryParse(inputWord, out bool result))
            {
                NoticeMessage.Append("불리언 입니다.");
                return true;
            }
            else
            {
                // 어차피 여기에서 ErrorMessage 추가 할 필요 없이 Inteager에서 Format 오류가 발생하면 추가함
                return false;
            }
        }
        
        // 숫자인지 체크
        public static bool integerCheck(string inputWord)
        {
            try
            {
                int value = Convert.ToInt32(inputWord);
                NoticeMessage.Append("숫자 입니다.");

                // 100 보다 큰지 작은지
                if (value >= 100) NoticeMessage.Append($"\n{value}은(는) 100과 같거나 큰 수 입니다.");
                else NoticeMessage.Append($"\n{value}은(는) 100보다 작은 수 입니다.");

                // 짝수인지 홀수인지
                if(value % 2 == 0) NoticeMessage.Append($"\n{value}은(는) 짝수입니다.");
                else NoticeMessage.Append($"\n{value}은(는) 홀수입니다.");

                return true;
            }
            catch (FormatException)
            {
                NoticeMessage.Append(ErrorMessage);
                return false;
            }
            catch (OverflowException)
            {
                NoticeMessage.Append($"int 범위를 벗어났습니다.(–2,147,483,648 ~ 2,147,483,647) {inputWord}");
                return true;
            }
        }
    }
}
