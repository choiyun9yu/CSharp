# .NET

## 1. .NET SDK
.NET SDK(Software Development Kit)은 .NET 어플리케이션을 개발, 빌드, 테스트 및 배포하는데 필요한 도구와 라이브러리의 모음이다. 주요 구성 요소는 다음과 같다.
- 컴파일러(C# 및 F#): C# 및 F# 언어를 사용하여 작성된 코드를 실행 파일로 변환하는 컴파일러가 포함되어 있다.
- 런타임(CLR, Common-Language Runtime): .NET 프로그램이 실행되는 가상 머신을 제공한다. CLR은 메모리 관리, 예외처리, 스레드 관리 등의 작업을 수행한다.
- 라이브러리 및 네임스페이스: .NET 어플리케이션에서 사용할 수 있는 다양한 라이브러리와 네임스페이스가 포함되어 있다. 
- 도구(dotnet 명령어): .NET CLI(Command Line Interface)를 통해 프로젝트를 생성, 빌드, 테스트, 실행하는 등의 작업을 수행할 수 있는 명령어 제공

### 1-1. .NET CLI
    % dotnet --info                        // .NET SDK 정보 출력

    % dotnet new webapp -o {프로젝트 이름}    // 새로운 프로젝트 생성

    % dotnet watch run                     // 디버깅(?) 모드로 실행 

    % dotnet build                         // 프로젝트 빌드
    % dotnet run                           // 프로젝트 실행
    % dotnet test                          // 테스트 실행
    % dotnet publish                       // 어플리케이션을 배포하기 위한 실행 파일 생성

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

## 3. Build

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

###  4-2. Service Container

    var myService = host.Services.GetService(typeof(MyServiceType));

.Service는 ASP.NET Core에서 제공하는 프레임워크의 일부이다. ASP.NET Core에서 Host 또는 WebHost를 생성하면, IServiceProvider 인터페이스를 구현한 서비스 컨테이너가 생성된다. 이 서비스 컨테이너는 애플리케이션 전체에서 사용 가능한 서비스를 관리하고 제공한다.

.Services는 이 서비스 컨테이너에서 서비스를 검색하는 데 사용되는 속성이다. 주로 의존성 주입(Dependency Injection)을 통해 서비스를 사용할 때 쓰인다.

위 코드는 MyServiceType이라는 서비스를 서비스 컨테이너에서 가져오는 코드이다. 이때 host는 일반적으로 IHost 또는 IWebHost인터페이스를 구현한 개체일 것이다.

### 4-3. IPEndPoint Class
IPEndPoint 클래스는 네트워크 엔드 포인트의 IP 주소와 포트 번호를 나타내는 클래스이다. 주로 네트워크 통신에서 특정 서버 또는 클라이언트의 위치를 나타내기 위해 사용된다.
- IP 주소 지정: 'IPEndPoint'는 IPv4 또는 IPv6 주소를 지정할 수 있다. IP 주소는 네트워크에서 특정 장치를 식별하는 데 사용된다.
- Port 지정: 포트는 특정 프로세스 또는 서비스를 식별하는데 사용된다. 서버는 특정 포트에서 대기하며, 클라이언트는 해당 포트로 연결하여 통신을 시작한다.
######
    // IPv4 주소와 포트 12345로 설정
    IPEndPoint endPointIPv4 = new IPEndPoint(IPAddress.Parse("192.168.1.1"), 12345);
    
    // IPv6 주소와 포트 8080으로 설정
    IPEndPoint endPointIPv6 = new IPEndPoint(IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334"), 8080);