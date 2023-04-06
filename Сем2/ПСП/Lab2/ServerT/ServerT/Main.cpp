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

		if (listen(sS, 10) == SOCKET_ERROR)
			throw  SetErrorMsgText("listen:", WSAGetLastError());

		SOCKET cS;	              
		SOCKADDR_IN clnt;            
		  
		while (true)
		{
			memset(&clnt, 0, sizeof(clnt));
			int lclnt = sizeof(clnt);
			if ((cS = accept(sS, (sockaddr*)&clnt, &lclnt)) == INVALID_SOCKET)
				throw  SetErrorMsgText("accept:", WSAGetLastError());

			cout << "Client| Ip address: " << inet_ntoa(clnt.sin_addr)
				<< " | Port: " << ntohs(clnt.sin_port) << endl;

			int lc = sizeof(clnt);
			char ibuf[50 * 1000];                  
			int  lb = 0;                    

			const int times = 10;
			int t1;
			int t2;
			int lobuf;
			string msg;

			clock_t start = clock();

			clock_t n1000,
				n2000,
				n3000,
				n4000,
				n7000,
				n8000,
				n10000;

			for (short i = 0; i <= times; i++)
			{
				if ((lb = recvfrom(cS, ibuf, sizeof(ibuf), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR)
					throw  SetErrorMsgText("recv:", WSAGetLastError());

				msg = ibuf;

				cout << msg << endl;

				msg.replace(msg.find("client"s), "client"s.size(), "server"s);

				if ((lobuf = sendto(cS, ibuf, strlen(ibuf) + 1, NULL, (sockaddr*)&clnt, sizeof(clnt))) == SOCKET_ERROR)
					throw  SetErrorMsgText("recv:", WSAGetLastError());

				/*switch (i) {
				case 1000:
					n1000 = clock() - start;
					break;
				case 2000:
					n2000 = clock() - start;
					break;
				case 3000:
					n3000 = clock() - start;
					break;
				case 4000:
					n4000 = clock() - start;
					break;
				case 7000:
					n7000 = clock() - start;
					break;
				case 8000:
					n8000 = clock() - start;
					break;
				case 10000:
					n10000 = clock() - start;
					break;
				}*/
			}

			/*cout << "1000 раз = " << n1000 << "мс\n";
			cout << "2000 раз = " << n2000 << "мс\n";
			cout << "3000 раз = " << n3000 << "мс\n";
			cout << "4000 раз = " << n4000 << "мс\n";
			cout << "7000 раз = " << n7000 << "мс\n";
			cout << "8000 раз = " << n8000 << "мс\n";
			cout << "10000 раз = " << n10000 << "мс\n";*/

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
