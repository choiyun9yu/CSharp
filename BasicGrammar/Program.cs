using System;
using System.Text;    
    
class Program   
{
    static void Main(string[] args)
    {
        // ex01_hellowrold();
        // ex02_array1();
        // ex02_array2();
        // ex02_array3();
        // ex03_string1();
        // ex03_string2();
        ex03_string3();
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

    static public void ex03_string1()
    {
        string s1 = "C#";
        string s2 = "Programing";

        char c1 = 'A';
        char c2 = 'B';
        
        // 문자열 결합
        string s3 = s1 + " " + s2;
        Console.WriteLine("string: {0}", s3);   // {0} 첫번째 인수로 전달된 값이 들어갈 위치
        
        string name = "John";
        int age = 30;
        string formattedString = string.Format("My name is {0} and I am {1} years old.", name, age);    // {1}은 두번째 인수로 전달된 값이 들어갈 위치

        // 문자열 슬라이싱
        string s3substring = s3.Substring(1, 5);
        Console.WriteLine("Substring: {0}", s3substring);
    }

    static public void ex03_string2()
    {
        string s = "C# Studies";
        
        // 문자열을 배열인덱스로 한문자 엑세스
        for (int i = 0; i < s.Length; i++)
        {
            Console.WriteLine("{0}: {1}", i, s[i]);
        }
        
        // 문자열을 문자배열로 변환
        string str = "Hello";
        char[] charArray = str.ToCharArray();
        Console.WriteLine(charArray);
        
        // 문자배열을 문자열로 변환
        char[] charArray2 = { 'A', 'B', 'C', 'D' };
        s = new string(charArray2);
        Console.WriteLine(s);
        
        // 문자 연산
        char c1 = 'A';
        char c2 = (char)(c1 + 3);
        Console.WriteLine(c2);  // D 출력
    }

    static void ex03_string3()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= 26; i++)
        {
            sb.Append(i.ToString());
            sb.Append(System.Environment.NewLine);
        }

        string s = sb.ToString();

        Console.WriteLine(s);
    }
}