# SignalR
SignalR은 web socket 기술에 기반한 통신 기술이다. 그러나 web socket은 클라이언트에서 서버로 요청을 보낼 수 없지만 SignalR은 보낼 수 있다는 점이 다르다.


## 1. SignalR 이란?

Microsoft에서 개발한 실시간 웹 응용 프로그램을 구축하기 위한 라이브러리  
(실시간 웹 기능은 서버측 코드가 클라이언트에 즉시 컨텐츠를 밀어주는 것을 의미)

#### SignalR의 기본 아키텍처

-   **클라이언트**: 웹 브라우저, 모바일 앱 또는 기타 클라이언트 애플리케이션은 SignalR 클라이언트 라이브러리를 사용하여 서버와 통신합니다.

-   **서버**: .NET Core 또는 .NET Framework에서 실행되는 SignalR 서버는 클라이언트와 통신하고 실시간 이벤트를 처리합니다.

-   **전송 프로토콜**: SignalR은 여러 가지 전송 프로토콜을 사용하여 클라이언트와 서버 간의 통신을 처리합니다. 이 중 웹소켓(WebSockets)이 가장 효율적이며 실시간 통신에 적합한 프로토콜입니다.

## 2. [예제] 실시간 채팅

1) web-app project 만들기
2) SignalR Client Library 추가
3) SignalR Hub 만들기
4) SignalR 구성
5) SignalR Client Code 추가
6) App 실행

### 2-2. .Net side
SignalR Hub는 클라이언트-서버 통신을 처리하는 높은 수준의 파이프라인으로 제공되는 클래스이다. 

#### [SignalR 허브 만들기] project-name/Hubs/ChatHub.cs
    using Microsoft.AspNetCore.SignalR;

    namespace SignalRChat.Hubs
    {
        public class ChatHub : Hub  // 상속하는 Hub 클래스는 연결, 그룹 및 메시징을 관리한다. 연결된 클라이언트에서 SendMessage 메서드를 호출하여 모든 클라이언트에 메시지를 보낼 수 있다. (브로드캐스팅 기능?)
        {
            public async Task SendMessage(string user, string message)
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }
        }
    }

#### [SignalR 구성] project-name/Program.cs

    using SignalRChat.Hubs;

    ...

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSignalR();

    // Add services to the container

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    
    // Configure the HTTP request pipline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)     // allow any origin
            .AllowCredentials());                   // allow credentials
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.MapHub<SignalrHub>("/hub")   

    app.Run();

### 2-3. React side

#### project-name/src/SignalRConnection.ts
    
    import * as signalR from "@microsoft/signalr";

    const URL = process.env.HUB_ADDRESS ?? "https://localhost:5000/hub;

    class Connector {
        private connection: signalR.HubConnection;
        public events: (onMessageReceived: (username: string, message: string) => void) => void;
        static instance: Connector;
        constructor() {
            this.connection = new signalR.HubConnectionBuilder()
                .withUrl(URL)
                .withAutomaticReconnect()
                .build();
            this.connection.start().catch(err => document.write(err))
            this.events = (onMessageReceived) => {
                this.connection.on("messageReceived", (username, message) => {
                    onMessageReceived(username, message);
                    });
                };
        }
        public newMessage = (messages: string) => {
            this.connection.send("newMessage", "foo", messages).then(x => console.log("sent"))
        }
        public static getInstance(): Connector {
            if (!Connector.instance)
                Connector.instance = new Connector();
            return Connector.instance;
        }

    }
    export default Connector.getInstance;

#### project-name/src/App.ts
    import React, { useEffect, useState } from 'react';
    import './App.css';
    import Connector from './signalr-connection'
    
    function App() {
        const { newMessage, events } = Connector();
        const [message, setMessage] = useState("initial value");
        
        useEffect(() => {
            events((_, message) => setMessage(message));
        });

        return (
            <div calssName="App">
                <span>message from signalR: <span style={{ color: "green" }}>{message}</sapn></span>
                <br />
                <button onClick={() => newMessage((new Data()).toISOString())}>send date</button>
            <div>
        )
    }

#### project-name/src/App.css



























#### ??? 

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

#### HubConnectionBuilder
Signal 연결 설정을 돕는 도우미 클래스
- 연결 URL 설정
- 연결 메서드 설정
- 허브 메서드에 대한 클라이언트 콜백 설정
- 연결 옵션 설정
- 연결 빌드
