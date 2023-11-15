# DotNetty

## 1. What is the DotNetty?
DotNetty는 .NET 기반의 비동기 네트워크 라이브러리로, 고성능 네트워크 애플리케이션을 개발하는 데 사용되는 오픈 소스 프로젝트이다. 이 라이브러리는 C# 및 .NET 플랫폼에서 TCP/UDP 프로토콜을 처리하고 다른 네트워크 프로그래밍 작업을 수행하기 위한 기능을 제공한다.  
(DotNetty는 Netty라고 불리는 자바에서 유명한 네트워크 프레임워크의 .NET 버전이라고 할 수 있다.)

## 2. Why those use the DotNetty?
1) 비동기 및 이벤트 기반: DotNetty는 비동기 및 이벤트 기반의 프로그래밍 모델을 채택하여 다중 클라이언트와 서버 연결을 효율적으로 처리할 수 있다.
2) 고성능: DotNetty는 높은 처리량과 낮은 대기 시간을 제공하는 고성능 네트워크 라이브러리로 알려져 있다.
3) 다양한 프로토콜 지원: TCP 및 UDP와 같은 다양한 네트워크 프로토콜을 처리할 수 있어 다양한 종류의 애플리케이션을 지원한다.
4) 유연성: DotNetty는 커스터마이징 및 확장이 가능하며, 다양한 네트워크 요구 사항에 맞게 조정할 수 있다.
5) 오픈 소스: DotNetty는 오픈 소스 프로젝트로 개발 및 사용이 무료이며, 커뮤니티의 지원을 받고 있다.

## 3. How to install?
DotNetty는 NuGet 패키지로 제공되므로 패키지 관리자를 사용하여 DotNetty 패키지 설치
#### .cspoj

    <ItemGroup>
        <PackageReference Include="DotNetty.Transport" Version="0.6.0" /> <!-- 네트워크 전송 계층을 처리하는 기능 제공 -->
        <PackageReference Include="DotNetty.Handlers" Version="0.6.0" />  <!-- 데이터 핸들링 및 프로토콜 처리를 위한 핸들러 및 유틸리티 클래스 제공 -->
    </ItemGroup>
  
## 4. How to use? 

    
## 5. etc

### 의존성 주입(Dependency Injection, DI)
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

### .Service

    var myService = host.Services.GetService(typeof(MyServiceType));

.Service는 ASP.NET Core에서 제공하는 프레임워크의 일부이다. ASP.NET Core에서 Host 또는 WebHost를 생성하면, IServiceProvider 인터페이스를 구현한 서비스 컨테이너가 생성된다. 이 서비스 컨테이너는 애플리케이션 전체에서 사용 가능한 서비스를 관리하고 제공한다.

.Services는 이 서비스 컨테이너에서 서비스를 검색하는 데 사용되는 속성이다. 주로 의존성 주입(Dependency Injection)을 통해 서비스를 사용할 때 쓰인다. 

위 코드는 MyServiceType이라는 서비스를 서비스 컨테이너에서 가져오는 코드이다. 이때 host는 일반적으로 IHost 또는 IWebHost인터페이스를 구현한 개체일 것이다.