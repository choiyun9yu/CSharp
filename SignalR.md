# SignalR

## 1. SignalR 이란?

Microsoft에서 개발한 실시간 웹 응용 프로그램을 구축하기 위한 라이브러리  
(실시간 웹 기능은 서버측 코드가 클라이언트에 즉시 컨텐츠를 밀어주는 것을 의미)

#### SignalR의 기본 아키텍처

-   **클라이언트**: 웹 브라우저, 모바일 앱 또는 기타 클라이언트 애플리케이션은 SignalR 클라이언트 라이브러리를 사용하여 서버와 통신합니다.

-   **서버**: .NET Core 또는 .NET Framework에서 실행되는 SignalR 서버는 클라이언트와 통신하고 실시간 이벤트를 처리합니다.

-   **전송 프로토콜**: SignalR은 여러 가지 전송 프로토콜을 사용하여 클라이언트와 서버 간의 통신을 처리합니다. 이 중 웹소켓(WebSockets)이 가장 효율적이며 실시간 통신에 적합한 프로토콜입니다.

## 2. 사용하기

### 2-1. HubConnectionBuilder

Signal 연결 설정을 돕는 도우미 클래스

-   연결 URL 설정
-   연결 메서드 설정
-   허브 메서드에 대한 클라이언트 콜백 설정
-   연결 옵션 설정
-   연결 빌드

#### .Net side

#### React side

    import { HubConnectionBuilder } from '@microsoft/signalr';


    // 연결 URL 설정
    const hubUrl = 'https://example.com/myHub';

    // HubConnectionBuilder를 사용하여 클라이언트 생성
    const connection = new HubConnectionBuilder()
    .withUrl(hubUrl) // 연결 URL 설정
    .build(); // 연결 빌드

    // 연결 시작
    connection.start()
    .then(() => {
        console.log('SignalR 연결 성공');
    })
    .catch(error => {
        console.error('SignalR 연결 실패: ', error);
    });
