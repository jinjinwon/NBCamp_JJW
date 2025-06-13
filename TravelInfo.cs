using Microsoft.VisualBasic;
using System.Text;

namespace NB_Camp_Project_6
{
    internal class TravelInfo
    {
        public static Dictionary<int,Tuple<string,string>> dic_Travel = new Dictionary<int, Tuple<string, string>>();
        public static StringBuilder questions = new StringBuilder();
        public static bool bExit = false;

        static void Main(string[] args)
        {
            // 여행지 로드
            LoadTravel();

            while (bExit == false)
            {
                // 질문 그리기
                Grid();

                // 사용자 입력
                string input = Console.ReadLine();
                int inputValue = 0;

                if (int.TryParse(input, out inputValue))
                {
                    Console.WriteLine(GetDescription(inputValue));
                }
                else
                {
                    Console.WriteLine("숫자가 아닙니다.");
                }
            }
        }

        public static void Grid()
        {
            int iNumber = 1;
            questions.Clear();

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("어디로 여행을 가고 싶나요?");
            foreach (var pair in dic_Travel.Values)
            {
                questions.Append($"{iNumber}.{pair.Item1} ");
                iNumber++;
            }

            Console.WriteLine(questions);
        }

        public static string GetDescription(int key)
        {
            if (dic_Travel.ContainsKey(key) == true)
            {
                return dic_Travel[key].Item2;
            }
            else
                return "1~4의 숫자를 입력해주세요.";
        }

        public static void LoadTravel()
        {
            dic_Travel.Add(1, new Tuple<string,string>("제주도","제주도는 한국의 섬으로 비교적 방문이 쉽고 다양한 놀거리/먹거리가 준비되어 있습니다."));
            dic_Travel.Add(2, new Tuple<string, string>("코타키나발루", "코타키나발루는 말레이시아 사바주의 주도로, 말레이시아 동부 보르네오섬 최대의 도시입니다."));
            dic_Travel.Add(3, new Tuple<string, string>("싱가포르", "싱가포르는 동남아시아, 말레이 반도의 끝에 위치한 섬나라이자 항구 도시로 이루어진 도시 국가입니다."));
            dic_Travel.Add(4, new Tuple<string, string>("태국", "태국은 중국문화, 말레이문화, 불교문화, 힌두문화, 이슬람 문화가 혼재되어 있습니다. 불교적인 모습을 많이 띄지만, 문화 자체는 색다르고 스펙트럼이 넓은 형태를 띄고 있어요."));
        }
    }
}
