#pragma comment(lib, "WS2_32.lib") 
#pragma warning(disable: 4996)
#include "Winsock2.h"

#include "pch.h"

using namespace std;

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);

void main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	SOCKET cC;
	WSADATA wsaData;

	try
	{
		//...........................................................
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());

		if ((cC = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("socket:", WSAGetLastError());

		/////////////////////////////////////////////////////////////

		SOCKADDR_IN serv;                    
		serv.sin_family = AF_INET;            
		serv.sin_port = htons(2000);                   
		serv.sin_addr.s_addr = inet_addr("127.0.0.1");  

		if ((connect(cC, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
			throw  SetErrorMsgText("connect:", WSAGetLastError());


		cout << "Server | Ip address: " << inet_ntoa(serv.sin_addr)
				   << " | Port: " << ntohs(serv.sin_port) << endl;

		string obuf = "client: Hello world   ";   
		string temp;
		int  lobuf = 0;                    
		const short times = 1000;
		int t1;
		int t2;
		int lb;
		int lc = sizeof(serv);
		char ibuf[50];

		for (short i = 0; i < times; i++)
		{
			temp = "Message " + to_string(i);
			if ((lobuf = sendto(cC, temp.c_str(), strlen(temp.c_str()) + 1, NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
				throw  SetErrorMsgText("recv:", WSAGetLastError());

			if ((lb = recvfrom(cC, ibuf, sizeof(ibuf), NULL, (sockaddr*)&serv, &lc)) == SOCKET_ERROR)
				throw  SetErrorMsgText("recv:", WSAGetLastError());

			cout << endl << ibuf << endl;
		}

		///////////////////////////////////////////////////////////////

		if (closesocket(cC) == SOCKET_ERROR)
			throw  SetErrorMsgText("closesocket:", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
		//.............................................................
	}
	catch (string errorMsgText)
	{
		cout << endl << "WSAGetLastError: " << errorMsgText;
	}
	system("pause");
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
