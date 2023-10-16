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