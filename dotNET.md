# .NET

## 1.NET이란?
Microsoft에서 개발한 프로그래밍 플랫폼이다. 다양한 운영 체제와 플랫폼에서 다양한 종류의 응용 프로그램을 개발하는데 사용된다.

## 2. NuGet 패키지 관리
.NET 플랫폼용 패키지 관리자이다. NuGet을 사용하면 .NET 애플리케이션에서 라이브러리, 패키지 및 종속성을 쉽게 설치, 업데이트 및 관리할 수 있다.

### 2-1. 패키지 의존성 설정 (.csproj 파일 안에서)
.csproj은 C# 프로젝트 파일의 확장자이다. 이 파일은 XML 형식으로 프로젝트의 정보, 종속성, 빌드 설정, 대상 프레임 워크 버전 등을 설정한다.

    <ItemGroup>
      <PackageReference Include="PackageName" Version="1.0.0" />
    </ItemGroup>

### 2-2. 패키지 설치 (NuGet CLI)
    // .csproj 파일 안에서 선언했다면 따로 설치할 필요는 없다.
    % dotnet add pacakge PackageName

### 2-3. 패키지 사용 (.cs 코드 안에서)
    using PacakgeName;

## 3. .NET 용어
[Document](https://learn.microsoft.com/ko-kr/dotnet/standard/glossary)