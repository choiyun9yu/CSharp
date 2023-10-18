# .NET

## .NET이란?
도구, 프로그래밍 언어 및 다양한 유형의 애플리케이션을 구축하기 위한 라이브러리로 구성된 개발자 플랫폼

### .NET의 구현체
.NET에는 다양한 구현체가 있고 각 구현체를 통해 .NET 코드를 Linux, macOS, Windows, IOS, Android 등 다양한 환경에서 실행 가능  

**NET Framework**는 .NET의 최초 구현체로 Windows에서 웹 사이트, 서비스, 데스크톱 앱 등을 실행하는 것을 지원

**.NET(.NET Core)**는 Windows, Linux 및 macOS에서 웹 사이트, 서비스 및 콘솔 앱을 실행하기 위한 플랫폼 간 구현체  
언어로는 C#, F# 또는 Visual Basic을 사용

**Xamarin/Mono**는 IOS 및 Android를 포함한 모든 주요 모바일 운영체제에서 앱을 실행하기 위한 .NET 구현체

**.NET Standard**는 .NET 구현에서 공통적인 API의 공식 사양이다. 이렇게 하면 동일한 코드와 라이브러리를 다른 구현에서 실행 할 수 있다.

## .csproj 파일
.csproj은 C# 프로젝트 파일의 확장자이다. 이 파일은 XML 형식으로 프로젝트의 정보, 종속성, 빌드 설정, 대상 프레임 워크 버전 등을 설정한다.

## NuGet 패키지
.NET 개발 환경에서 사용되는 패키지 관리 시스템의 일부로 .NET 프로젝트에 필요한 라이브러리, 도구, 코드, 리소스 등을 쉽게 추가하고 관리할 수 있는 방법을 제공하는 패키지 형식이다.


## .NET

    # 출력
    var name = "Ana";
    Console.WriteLine("Hello" + " " + name + "!");
    >> Hello Ana!

    # 포맷 스트링
    Console.WriteLine($"Hello {name}!");
    >> Hello Ana!

    # 대문자 전환
    Console.WriteLine($"Hello {name.ToUpper()}!");

    # 반복문
    var names = new[] {"Ana", "Felipe", "Emillia"};
    foreach (var name in names) {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
