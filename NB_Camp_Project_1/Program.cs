namespace NB_Camp_Project_1
{
    internal class Program
    {
        private static int level = 0;
        private static int count = 0;

        private static float percentage = 0f;
        private static float speed = 0f;

        private static string nickname = "";
        private static string description = "";

        static void Main(string[] args)
        {
            // 숫자 -> 숫자 형변환
            int iTen = 10;
            float fTen = iTen;

            float fFive = 5.5f;
            int iFive = (int)fFive;

            // 숫자 -> 문자 형변환
            int n = 10;
            float f = 0.5f;

            nickname = Convert.ToString(n);
            description = Convert.ToString(f);

            // 문자 -> 숫자 형변환
            string strTen = "10";
            string strSix = "6.2";

            level = Convert.ToInt32(strTen);
            percentage = Convert.ToSingle(strSix);

            Console.WriteLine($"{fTen} / {iFive} / {nickname} / {description} / {level} / {percentage}");
        }
    }
}
