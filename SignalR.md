# SignalR
SignalR은 web socket 기술에 기반한 통신 기술이다. 그러나 web socket은 클라이언트에서 서버로 요청을 보낼 수 없지만 SignalR은 보낼 수 있다는 점이 다르다.


## 1. SignalR 이란?

Microsoft에서 개발한 실시간 웹 응용 프로그램을 구축하기 위한 라이브러리  
(실시간 웹 기능은 서버측 코드가 클라이언트에 즉시 컨텐츠를 밀어주는 것을 의미)

#### SignalR의 기본 아키텍처

-   **클라이언트**: 웹 브라우저, 모바일 앱 또는 기타 클라이언트 애플리케이션은 SignalR 클라이언트 라이브러리를 사용하여 서버와 통신합니다.

-   **서버**: .NET Core 또는 .NET Framework에서 실행되는 SignalR 서버는 클라이언트와 통신하고 실시간 이벤트를 처리합니다.

-   **전송 프로토콜**: SignalR은 여러 가지 전송 프로토콜을 사용하여 클라이언트와 서버 간의 통신을 처리합니다. 이 중 웹소켓(WebSockets)이 가장 효율적이며 실시간 통신에 적합한 프로토콜입니다.

## 2. [예제] 
[자습서](https://learn.microsoft.com/ko-kr/aspnet/core/tutorials/signalr?view=aspnetcore-7.0&tabs=visual-studio)

1) 웹 프로젝트 만들기
2) SignalR 클라이언트 라이브러리 추가
3) SignalR 허브 만들기
4) SignalR 사용 프로젝트 구성
5) 모든 클라이언트에서 연결된 모든 클라이언트로 메시지 보내는 코드 추가(?)

### 2-1. 웹 프로젝트 만들기

    % dotnet new webapi -f net8.0 -o kisa-gcs-system
    
### 2-2. SignalR 클라이언트 라이브러리 추가

    % dotnet add package Microsoft.AspNetCore.SignalR

### 2-3. SignalR 허브 만들기
허브는 클라이언트-서버 통신을 처리하는 높은 수준의 파이프라인으로 제공되는 클래스이다.

#### /Hubs/ChatHub.cs
    using Microsoft.AspNetCore.SignalR;

    namespace SignalR.Hubs
    {
        public class ChatHub : Hub
        {
            public async Task SendMessage(string user, string message)  // 클라이언트로부터 호출되는 메서드
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);   // 모든 클라이언트에게 'ReceiveMessage' 메서드를 호출하여 데이터 전송
            }
        }
    }

ChatHub 클래스는 SignalRHub 클래스를 상속받는다. Hub 클래스는 연결, 그룹 및 메시징을 관리한다. 

연결된 클라이언트에서 SendMessage 메서드를 호출하여 모든 클라이언트에 메시즈를 보낼 수 있다.

#### /Hubs/ChatHub.cs

### 2-4. SignalR 사용 프로젝트 구성

### 2-5. 모든 클라이언트에서 연결된 모든 클라이언트로 메시지 보내는 코드 추가























