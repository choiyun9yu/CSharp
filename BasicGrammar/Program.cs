class Program   
{
    static void Main(string[] args)
    {
        // ex01_hellowrold();
        // ex02_array1();
        // ex02_array2();
        ex02_array3();
    }

    static public void ex01_helloworld()
    {
        System.Console.WriteLine("Hello Wrold!");
                    
        // 한 줄 코멘트

        /*
            두 줄 이상의 코멘트
            두 줄 이상의 코멘트
        */
    }

    static public void ex02_array1()
    {
        // 1차 배열
        string[] players = new string[10];
        string[] Regions = { "서울", "경기", "부산" };
        System.Console.WriteLine(players[0]);
        System.Console.WriteLine(Regions[0]);
        
        // 2차 배열 선언 및 초기화
        string[,] Depts = {{"김과장", "경리부"},{"이과장", "총무부"}};
        System.Console.WriteLine(Depts[1,1]);
        
        // 3차 배열 선언
        // string[,,] Cubes;
    }

    static public void ex02_array2()
    {
        int sum = 0;
        int[] scores = { 80, 78, 60, 90, 100 };
        
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }
        Console.WriteLine(sum); // 408        
    }

    static public void ex02_array3()
    {
        int[] scores = { 80, 78, 60, 90, 100 };
        int sum = CalculateSum(scores); // 배열 전달: 배열명 사용
        Console.WriteLine(sum);        
        
    }
    static int CalculateSum(int[] scoresArray) // 배열 받는 쪽
    {
        int sum = 0;
        for (int i = 0; i < scoresArray.Length; i++)
        {
            sum += scoresArray[i];
        }
        return sum;
    }
}