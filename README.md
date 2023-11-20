# .NET
.NET은 Microsoft의 개발 플랫폼이며, 크로스 플랫폼 애플리케이션을 개발하기 위한 도구 및 런타임을 제공한다.

<br>

## 1.  ASP.NET
**.NET**은 플랫폼이고 과거 .NET Framework가 웹 응용 프로그램을 개발하는 플랫폼이었다. 이때 사용하는 기술 스택을 ASP.NET이라고 했다.
그러나 .NET Core가 등장하면서 크로스 플랫폼 및 경량화를 위한 접근 방식이 도입되었고 .NET Core 위에서 동작하는 웹 프레임워크로 ASP.NET Core라는 기술 스택이 등장했다.
최근에는 .NET5 이후로는 .NET Framework와 .NET Core가 통합되어 ASP.NET Core라는 말은 사라지고 ASP.NET라는 기술 스택으로 부르게 되었다..

    dotnet --list-sdks              // 설치된 .NET SDK 목록 확인
    dotnet new webapi -f net7.0     // webapi 프로젝트 .NET7.0으로 만들기
######
    webapi-project
      ├── Controllers               // HTTP 엔드포인트로 노출되는 공용 메서드가 있는 클래스 포함
      ├── Program.cs                // 애플리케이션의 관리되는 진입점을 포함하는 서비스와 앱의 HTTP 요청 파이프라인 구성
      ├── Properties
      ├── WeatherForecast.cs
      ├── appsettings.Development.json
      ├── appsettings.json          // 애플리케이션 설정 정보 포
      ├── obj
      └── webapi-project.csproj     // 프로젝트 구성에 대한 메타 데이터 포함


    

### 1-1. .NET 7 vs C# 7.0 
.NET은 개발 플랫폼이고 C#은 프로그래밍 언어이다. 따라서 개발 플랫폼의 버전이 있고 프로그래밍 언어의 버전이 있을 뿐이지 둘이 반드시 일치할 필요는 없다. 

<br>

## 2. NuGet, 패키지 관리자
NuGet은 .NET 플랫폼 전용 패키지 관리자이다. NuGet을 사용하면 .NET 애플리케이션에서 라이브러리, 패키지 및 종속성을 쉽게 설치, 업데이트 및 관리할 수 있다.

### 2-1. 패키지 의존성 설정 (.csproj 파일 안에서)
.csproj은 C# 프로젝트 파일의 확장자이다. 이 파일은 XML 형식으로 프로젝트의 정보, 종속성, 빌드 설정, 대상 프레임 워크 버전 등을 설정한다.

    // 패키지 참조
    <ItemGroup>
      <PackageReference Include="PackageName" Version="1.0.0" />
    </ItemGroup>

#### .csproj 파일에 의존성 설정

    // 파일 추가: 프로젝트에 포함할 파일을 지정하는 데 사용(소스 코드 파일, 리소스 파일, 콘텐츠 파일 등)
    <ItemGroup>
        <Compile Include="File1.cs" />
        <Compile Include="Image.png" />
    </ItemGroup>

    // 프로젝트 참조: 다른 프로젝트를 참조하는 경우에 사용
    <ItemGroup>
        <ProjectReference Include="Path\AnotherProject.csproj" />
    </ItemGroup>정

### 2-2. 패키지 설치 (NuGet CLI)
    // .csproj 파일 안에서 선언했다면 따로 설치할 필요는 없다.
    % dotnet add pacakge {PackageName}

### 2-3. 패키지 사용 (.cs 코드 안에서)
    using {PacakgeName};

<br>

## 3. 빌드 과정

    % dotnet build

### 3-1. MSIL
커맨드 창에 dotnet build를 입력하면 가장먼저 MSIL이 프로젝트 소스 코드를 컴파일한다. MSIL은 중간 언어로 .NET 환경에서 실행될 수 있는 언어이다.

### 3-2. NuGet
그런 다음 의존성을 해결한다. 이때 NuGet을 활용해서 프로젝트가 필요로하는 외부 패키지나 라이브러리를 가져와서 해결한다.

### 3-3. MSBuild
마지막으로 MSBuild가 컴파일된 코드와 의존성이 해결된 패키지를 사용하여 빌드한다. 빌드 출력물은 'bin' 또는 'obj' 디렉터리에 저장된다.

<br>
<br>

## 4. etc

### 4-1. 의존성 주입(Dependency Injection, DI)
의존성 주입은 객체 지향 프로그래밍에서 객체 간의 의존성을 외부에서 주입하는 디자인 패턴이다. 이 패턴은 코드를 느슨하게 결합하고 재사용성을 높이며 테스트 용이성을 개선하는데 도움이 된다.
#### 핵심 개념
- 의존성: 한 클래스가 다른 클래스에 의존할 때, 이를 의존성이라고 한다.
- 의존성 주입: 클래스가 직접 의존하는 객체를 생성하지 않고 외부에서 주입받는 것을 말한다.

#### .NET Core에서 의존성 주입 예시
    // 서비스 컨테이너 구성
    var serviceProvider = new ServiceCollection()
    .AddSingleton<IEngine, GasolineEngine>()
    .AddSingleton<Car>()
    .BuildServiceProvider();
    
    // 서비스 가져오기
    var car = serviceProvider.GetRequiredService<Car>();
    
    // 사용
    car.Start();

###  4-2. .Service

    var myService = host.Services.GetService(typeof(MyServiceType));

.Service는 ASP.NET Core에서 제공하는 프레임워크의 일부이다. ASP.NET Core에서 Host 또는 WebHost를 생성하면, IServiceProvider 인터페이스를 구현한 서비스 컨테이너가 생성된다. 이 서비스 컨테이너는 애플리케이션 전체에서 사용 가능한 서비스를 관리하고 제공한다.

.Services는 이 서비스 컨테이너에서 서비스를 검색하는 데 사용되는 속성이다. 주로 의존성 주입(Dependency Injection)을 통해 서비스를 사용할 때 쓰인다.

위 코드는 MyServiceType이라는 서비스를 서비스 컨테이너에서 가져오는 코드이다. 이때 host는 일반적으로 IHost 또는 IWebHost인터페이스를 구현한 개체일 것이다.

### 4-3. IPEndPoint 클래스
IPEndPoint 클래스는 네트워크 엔드 포인트의 IP 주소와 포트 번호를 나타내는 클래스이다. 주로 네트워크 통신에서 특정 서버 또는 클라이언트의 위치를 나타내기 위해 사용된다.
- IP 주소 지정: 'IPEndPoint'는 IPv4 또는 IPv6 주소를 지정할 수 있다. IP 주소는 네트워크에서 특정 장치를 식별하는 데 사용된다.
- Port 지정: 포트는 특정 프로세스 또는 서비스를 식별하는데 사용된다. 서버는 특정 포트에서 대기하며, 클라이언트는 해당 포트로 연결하여 통신을 시작한다.
######
    // IPv4 주소와 포트 12345로 설정
    IPEndPoint endPointIPv4 = new IPEndPoint(IPAddress.Parse("192.168.1.1"), 12345);
    
    // IPv6 주소와 포트 8080으로 설정
    IPEndPoint endPointIPv6 = new IPEndPoint(IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334"), 8080);



## 5. .NET 용어
[Document](https://learn.microsoft.com/ko-kr/dotnet/standard/glossary)

### Configuration(구성)
소프트웨어 응용 프로그램의 동작 및 설정을 제어하는 데 사용되는 데이터와 옵션을 나타낸다. 이러한 설정은 응용 프로그램의 동작을 변경하거나 조절하기 위해 사용자 또는 시스템 관리자에 의해 구성될  수있으며, 설정 파일, 환경 변수, 데이터베이스 레코드 또는 다른 소스에서 가져올 수 있다.

Configuration의 목적
- **동적 설정 변경**  
  코드를 직접 수정하지 않고 설정 값을 조절할 수 있게 해준다.
- **보안 및 접근성**  
  암호, API key, 데이터베이스 연결 문자열과 같은 민감한 정보를 설정 파일에 저장하고 접근 권한을 제어하여 보안을 강화할 수 있다.
- **다중 환경 지원**  
  동일한 코드베이스를 여러 환경(개발, 테스트, 생산)에서 실행할 때 다른 구성 파일을 사용하여 각 환경에 맞는 설정을 구성할 수 있다.
- **배포 가능성 및 이식성**  
  응용 프로그램을 다른 환경으로 쉽게 배포하기위해 설정을 외부 파일로 분리하고, 필요한 설정 값을 동적으로 로드하는 것이 좋다.
- **유지 및 관리**  
 
일반적으로 .NET 애플리케이션에서는 IConfiguration인터페이스를 사용하여 구성 값을 로드하고 응용 프로그램에서 사용한다. 이를 통해 JSON, XML, 환경변수, 명령줄 매개변수 또는 기타 소스에서 설정을 로드할 수 있다. 구성은 응용 프로그램의 동작을 커스터마이징하고 관리하는데 중요한 역할을 한다.

### Bootstrap
.NET 애플리케이션에서는 Bootstrap이라는 용어가 의존성 주입 컨테이너를 설정하거나 애플리케이션을 시작하는 초기 구성을 의미하기도 한다. 예를 들면 ASP.NET Core에서는 Startup.cs 파일에서 서비스의 구성이나 애플리케이션의 구동과 관련된 초기 설정을 하는 부분이 Bootstrap이라고 불린다.