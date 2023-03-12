#pragma comment(lib, "WS2_32.lib") 
#pragma warning(disable: 4996)
#include "Winsock2.h"
#include <algorithm>
#include "pch.h"

using namespace std;

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);

void main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	SOCKET sS;
	WSADATA wsaData;
	
	try
	{
		//...........................................................
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("socket:", WSAGetLastError());
		/////////////////////////////////////////////////////////////

		SOCKADDR_IN serv;                     
		serv.sin_family = AF_INET;            
		serv.sin_port = htons(2000);          
		serv.sin_addr.s_addr = inet_addr("127.0.0.1");    

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw  SetErrorMsgText("bind:", WSAGetLastError());


		if (listen(sS, SOMAXCONN) == SOCKET_ERROR)
			throw  SetErrorMsgText("listen:", WSAGetLastError());

		SOCKET cS;	              
		SOCKADDR_IN clnt;            
		memset(&clnt, 0, sizeof(clnt)); 
		int lclnt = sizeof(clnt);   

		while (true)
		{
			if ((cS = accept(sS, (sockaddr*)&clnt, &lclnt)) == INVALID_SOCKET)
				throw  SetErrorMsgText("accept:", WSAGetLastError());

			int lc = sizeof(clnt);
			char ibuf[50 * 1000];                  
			int  lb = 0;                    

			const int times = 1000;
			int t1;
			int t2;
			int lobuf;

			for (short i = 0; i < times; i++)
			{
				if ((lb = recvfrom(cS, ibuf, sizeof(ibuf), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR)
					throw  SetErrorMsgText("recv:", WSAGetLastError());

				cout << ibuf << endl;

				if ((lobuf = sendto(cS, ibuf, strlen(ibuf) + 1, NULL, (sockaddr*)&clnt, sizeof(clnt))) == SOCKET_ERROR)
					throw  SetErrorMsgText("recv:", WSAGetLastError());
			}

			closesocket(cS);
		}


		///////////////////////////////////////////////////////////////
		if (closesocket(sS) == SOCKET_ERROR)
			throw  SetErrorMsgText("closesocket:", WSAGetLastError());
		
		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
		//.............................................................
	}
	catch (string errorMsgText)
	{
		cout << endl << "WSAGetLastError: " << errorMsgText;
	}

}

string  SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
}

string  GetErrorMsgText(int code)    // cформировать текст ошибки 
{
	string msgText;
	switch (code)                      // проверка кода возврата  
	{
	case WSAEINTR:          msgText = "WSAEINTR";         break;
	case WSAEACCES:         msgText = "WSAEACCES";        break;
		//..........коды WSAGetLastError ..........................
	case WSASYSCALLFAILURE: msgText = "WSASYSCALLFAILURE"; break;
	default:                msgText = "***ERROR***";      break;
	};
	return msgText;
}
