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

    