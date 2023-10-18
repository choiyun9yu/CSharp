# C#
[C# Study](https://www.csharpstudy.com/)

## 1. Basic Grammar

### 1-1. C# program source code example
      namespace Intro_Ex1
      {
          class Program   
              {
                  static void Main(string[] args)
                      {
                          System.Console.WriteLine("Hello Wrold!");
                          
                          // 한 줄 코멘트
  
                          /*
                              두 줄 이상의 코멘트
                              두 줄 이상의 코멘트
                          */
                      }
              }
      }

- namespace는 scope와 비슷한 역할을 하며, 다른 namespace에 있는 변수를 사용하려면 using으로 삽입해야 한다.
- 모든 C# 프로그램은 Main() 이라는 시작 메서드를 가져야한다.  
- Main메소드는 임의의 클래스 안에 존재하며 프로그램 상ㅇ에 단 1개만 존재해야 한다.
- Main메소드는 static으로 선언되며, 메소드 인자는 string[] 문자열 이다.
- System.Console은 .NET Framework 클래스이며, WriteLine은 화면에 데이터를 출력하는 메서드이다.

### 1-2. data type
- C#을 포함한 모든 .NET 프로그래밍 언어는 .NET의 Common Type System에 정의된 데이터 타입을 사용한다.
- 사용자는 C# 데이터 타입과 .NET 데이터 타입 모두 표현이 가능하지만, 컴파일러는 C# 데이터 타입을 .NET 데이터 타입으로 변경한다.

| .NET 데이터 타입      | C# 데이터 타입 | 설명                              |
|------------------|-----------|---------------------------------|
| System.Boolean   | bool      | True or False                   |
| System.Byte      | byte      | 8bit unsigned integer (부호 없는)   |
| System.SByte     | sbyte     | 8bit signed integer (부호 있는)     |
| System.Int16     | short     | 16bit signed integer            |
| System.Int32     | int       | 32bit signed integer            |
| System.Int64     | long      | 64bit signed integer            |
| System.UInt16    | ushort    | 16bit unsigned integer          |
| System.UInt32    | unint     | 32bit unsigned integer          |
| System.UInt64    | ulong     | 64bit unsigned integer          |
| System.Single    | float     | 32bit single precision 부동소숫점 숫자 |
| System.Double    | double    | 64bit double precision 부동소숫점 숫자 |
| System.Decimal   | decimal   | 128bit Decimal (정확한 숫자 저장에 사용)  |
| System.Char      | char      | 16bit 유니코드 문자 (' ')             |
| System.String    | string    | 유니코드 문자열 (" ")                  |
| System.DateTime  |           | 날짜와 시간                          |
| System.Object    | object    | 모든 타입의 기본 클래스로 모든 유형을 포함할 수 있음  |

#### 디폴트 리터럴 타입
- 리터럴(literal) 데이터: 변수에 넣지 않은 데이터 그 자체를 의미, (변수 대입 시 등호 오른쪽)
- C#에서 별도의 접미어(Suffix)가 없는 경우 int, double, char, string, bool 타입으로 값 할당
######
      123     // int
      12.3    // double
      "A"     // string
      'a'     // char
      true    // bool
#### Suffix
      1024L   // long
      1024U   // uint
      1024UL  // ulong
      10.24F  // float
      10.24D  // double
      10.24M  // decimal

#### 예제
      // Bool
      bool b = true;
      
      // Numeric
      short sh = -32768;   
      int i = 2147483647;  
      long l = 1234L;      // L suffix
      float f = 123.45F;   // F suffix
      double d1 = 123.45;
      double d2 = 123.45D; // D suffix
      decimal d = 123.45M; // M suffix
      
      // Char/String
      char c = 'A';
      string s = "Hello";
      
      // DateTime  2011-10-30 12:35
      DateTime dt = new DateTime(2011, 10, 30, 12, 35, 0);
  
      // 해당 데이터 타입의 최대값과 최소값
      int i = int.MaxValue;
      float f = float.Minvalue;

#### NULL
- 어떤 변수가 메모리 상에 어떤 데이터도 가지고 있지 않다는 의미로 null을 사용한다.
- 모든 타입이 null을 가질 수 있는 것은 아니다. Reference 타입은 null을 가질 수 있고, Value 타입은 가질 수 없다.

#### Nullable Type
- 기본적으로 정수나 날짜와 같은 Value Type은 null을 가질 수 없다. 
- 그러나 C# 2.0에서 부터 이러한 타입들도 null을 가질 수 있게 하였는데, 이를 Nullable Type이라 한다.
- C#에서 물음표(?)를 데이터 타입명 뒤에 붙이면 Nullable Type이 된다.

### 1-3. 변수와 상수

#### 변수
- 지역 변수: 메서드 안에서 해당 메서드의 로컬 변수로 선언된 변수이다.
  해당 메서드 내에서망 사용되고, 메서드 호출이 끝나면 소멸한다.
- 전역 변수(필드): 클래스 안에서 선언되어 클래스 내의 멤버들이 사용하는 변수이다.  
  클래스의 객체가 살아있는 한 존속하며 다른 메서드들에서 필드 참조할 수 있다.
- 정적 필드: static으로 선언된 필드, 클래스 Type 처음 런타임에 의해 로드될 때 해당 Type 객체에 생성되어 프로그램이 종료될 때 까지 유지된다.
######
      using System;
      
      namespace ConsoleApplication1
      {
      class CSVar
      {
      //필드 (클래스 내에서 공통적으로 사용되는 전역 변수)
      int globalVar;
      const int MAX = 1024;
      
              public void Method1()
              {
                  // 로컬변수
                  int localVar;
      
                  // 아래 할당이 없으면 에러 발생
                  localVar = 100;
      
                  Console.WriteLine(globalVar);
                  Console.WriteLine(localVar);
              }
          }
      
          class Program
          {
              // 모든 프로그램에는 Main()이 있어야 함.
              static void Main(string[] args)
              {
                  // 테스트
                  CSVar obj = new CSVar();
                  obj.Method1();
              }
          }
      }

#### 상수
- C#에서 상수는 C# 변수 앞에 const를 붙여 정의한다.
- 상수와 변수의 차이점은 변수는 값을 변경할 수 있지만, 상수는 초기에 정한 값을 변경할 수 없다.
- C# const 대신 readonly 키워드를 사용하여 읽기전요 필드를 만들 수 있다.(개념적으로 상수와 비슷)
- const는 컴파일 시 상수값이 결정되고, readonly는 런타임 시 그 값이 결정된다.
######
      using System;
      
      namespace ConsoleApplication1
      {
      class CSVar
      {
      // 상수
      const int MAX_VALUE = 1024;
      
              // readonly 필드 
              readonly int Max;
              public CSVar() 
              {
                 Max = 1;
              }
              
              //...
          }
      }

### 1-4. 배열(Array)
- 배열: 동일한 데이터 타입 요소들로 구성된 데이터 집합으로서, 인덱스를 통해 개별 요소에 접근할 수 있다.
- C#은 최대 32차 배열까지 가질 수 있다. 
- 2차원 이상의 다차원 배열은 각 차원별 요소 크기가 고정된 'Rectangular 배열'과 각 차원별 크기가 서로 다른 '가변 배열'로 나눌 수 있다.  
- **주의!** 배열의 선언은 대괄호([ ])를 사용하지만, 요소를 정의할 땐 중괄호({ })를 사용한다.
#### Rectangular 배열 예제
      // 1차 배열
      string[] players = new string[10];
      string[] Regions = { "서울", "경기", "부산" };
      System.Console.WriteLine(players[0]);
      System.Console.WriteLine(Regions[0]);
    
      // 2차 배열 선언 및 초기화
      string[,] Depts = {{"김과장", "경리부"},{"이과장", "총무부"}};
      System.Console.WriteLine(Depts[1,1]);
      
      // 3차 배열 선언(선언만 한 경우에 0으로 초기화X)   
      string[,,] Cubes;
- 다차원 배열에서 각 차원 배열의 요소 크기가 동일한 'Rectangular 배열'은 [ , ]와 같이 표현한다.
- 배열에 접근할 때에도 마찬가지이다. 

#### 가변 배열 예제
    //Jagged Array (가변 배열)
    //1차 배열 크기(3)는 명시해야
    int[][] A = new int[3][];
    
    //각 1차 배열 요소당 서로 다른 크기의 배열 할당 가능
    A[0] = new int[2];
    A[1] = new int[3] { 1, 2, 3 };
    A[2] = new int[4] { 1, 2, 3, 4 };
    
    A[0][0] = 1;
    A[0][1] = 2
- 각 차원별 배열 요소 크기가 가변적인 가변 배열의 경우[ ][ ]처럼 각 차원마다 별도의 대괄로를 사용한다.
- 첫번째 차원의 크기는 컴파일 타임에 확정되어야하고, 그 이상 차원은 런타임시 동적으로 서로 다른 크기의 배열로 지정할 수 있다.
- 가변 배열은 고정된 크기를 사용하면 메모리 낭비가 심한 경우 사용한다.

#### 배열의 사용
- 모든 배열은 .NET Framework의 System.Array에서 파생되기 때문에 System.Array의 메서드, 프로퍼티를 사용할 수 있다.
- C#에서 배열 전체를 전달하기 위해서는 보내는 쪽에서는 배열명을 사용하고, 받는 쪽에서는 동일한 배열 타입의 배열을 받아들이면 된다. 
- 배열은 레퍼런스(Referuence)타입이기 때문에, 배열을 다른 객체나 메서드에 전달할 때, 직접 모든 배열 데이터를 복사하지 않고, 배열 전체를 가리키는 참조 값만을 전달한다.  
######
        static void Main(string[] args)
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

### 1-5. 문자열
- string은 쌍따옴표(" ")로 표현하고, char는 따옴표(' ')로 표현한다.
- C#에서 문자열은 Immutable Type 이다. 즉, 한 번 문자열이 설정되면 다시 변경할 수 없다.  
  (s = "apple"; 이라고 선언하고 s = "apply";로 바꾸면 새로운 string객체를 생성하여 s에 할당)
######
        static public void ex03_string1()
        {
            string s1 = "C#";
            string s2 = "Programing";
      
            char c1 = 'A';
            char c2 = 'B';
              
            //문자열 결합
            string s3 = s1 + " " + s2;
            Console.WriteLine("string: {0}", s3);
      
            // 문자열 슬라이싱
            string s3substring = s3.Substring(1, 5);
            Console.WriteLine("Substring: {0}", s3substring);
        }

- 문자열은 문자의 집합체이다. 문자열 안에 있는 각 문자에 엑세스 하고 싶으면 인덱스를 사용한다. 
- 문자배열(char array)을 문자열(string)으로 변환하기 위해서는 new string을 사용한다.
- 하나의 문자는 상응하는 ASCII 코드 값을 가진다. 하나의 문자는 숫자 값으로 표현되므로 문자에 숫자를 더하거나 빼면 다른 문자로 표현 가능하다.
######
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
#### C# StringBuilder 클래스
- String은 Immutable Type 이기 때문에, 문자열 갱신을 많이 하는 프로그램에는 적합하지 않다.
- 반면 Mutable Type인 StringBuilder 클래스는 문자열 갱신이 많은 곳에 적합하다.  
- 이는 이 클래스가 별도 메모리를 생성, 소멸하지 않고 일정한 버퍼를 갖고 문자열 갱신을 효율적으로 처리하기 때문이다.
- 특히 루프 안에서 계속 문자열을 추가 변경하는 코드에서는 string 대신 StringBuilder를 사용해야 한다.

