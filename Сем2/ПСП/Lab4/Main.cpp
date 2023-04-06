#pragma comment(lib, "WS2_32.lib") 
#pragma warning(disable: 4996)
#include "Winsock2.h"

#include <algorithm>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

int countServers = 0;

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);

bool GetRequestFromClient(
	char* name, //[in] �������� �������
	short port, //[in] ����� �������������� �����
	sockaddr* from, //[out] ��������� �� SOCKADDR_IN
	int* flen //[out] ��������� �� ������ from
);

bool PutAnswerToClient(
	char* name, //[in] �������� �������
	short port,
	struct sockaddr* to, //[in] ��������� �� SOCKADDR_IN
	int* lto //[in] ��������� �� ������ from
);

// ����������: ������� ������������� ����������������� 
// ��������� ��������� ������� � ������ �� 
// ������� ������.

void GetServer(
	char* call, //[in] �������� ������� 
	short port, //[in] ����� ����� ������� 
	struct sockaddr* from, //[out] ��������� �� SOCKADDR_IN
	int* flen //[out] ��������� �� ������ from
);

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	SOCKET sS;
	WSADATA wsaData;
	
	const char name[] = "Hello";
	const auto PORT = htons(2000);

	SOCKADDR_IN serv;

	serv.sin_family = AF_INET;
	serv.sin_addr.s_addr = INADDR_ANY;
	serv.sin_port = PORT;

	SOCKADDR_IN client;
	int sizeC = sizeof(client);

	int sizeServ = sizeof(serv);
	try
	{
		//...........................................................
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());

		GetServer((char*)name, 2000, (sockaddr*)&client, &sizeC);

		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("socket:", WSAGetLastError());
		/////////////////////////////////////////////////////////////

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw SetErrorMsgText("bind:", WSAGetLastError());

		SOCKADDR_IN client;
		int size = sizeof(client);

		const int SIZE = 4096;
		char buffer[SIZE];


		while (true)
		{
			if (GetRequestFromClient((char*)name, sS, (SOCKADDR*)&client, &size))
			{
				cout << "������ �����������\n";
				cout << inet_ntoa(client.sin_addr) << endl;

				if (!PutAnswerToClient((char*)name /*"dd"*/, sS, (SOCKADDR*)&client, &size))
				{
					cout << "������. ����� ������� �� ����������!\n";
				}
			}
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
		std::cout << endl << "WSAGetLastError: " << errorMsgText;
	}

}


void GetServer(char* call, short port, struct sockaddr* from, int* flen) {
	SOCKET cC;
	SOCKADDR_IN all;

	int timeout = 5000;


	int optval = 1;
	char buf[50];

	try {
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("socket:", WSAGetLastError());

		// ��������� ������ ������ ������: ��� ������������� ������������������ ������ ����� SO_BROADCAST
		if (setsockopt(cC, SOL_SOCKET, SO_BROADCAST, (char*)&optval, sizeof(int)) == SOCKET_ERROR)
			throw  SetErrorMsgText("setsocketopt:", WSAGetLastError());
		if (setsockopt(cC, SOL_SOCKET, SO_RCVTIMEO, (char*)&timeout, sizeof(int)) == SOCKET_ERROR)
			throw  SetErrorMsgText("setsocketopt:", WSAGetLastError());

		all.sin_family = AF_INET;
		all.sin_port = htons(port);
		all.sin_addr.s_addr = INADDR_BROADCAST; // ����������������� �����
		//server.sin_addr.s_addr = inet_addr("192.168.157.99");

		// �������� ������������������ ������� � ��������
		if (sendto(cC, call, strlen(call) + 1, NULL, (sockaddr*)&all, sizeof(all)) == SOCKET_ERROR)
			throw SetErrorMsgText("sendto:", WSAGetLastError());
		// �������� ������
		if (recvfrom(cC, buf, sizeof(buf), NULL, from, flen) == SOCKET_ERROR)
			throw  SetErrorMsgText("recvfrom:", WSAGetLastError());

		// ���� �������� ���������
		if (strcmp(call, buf) == 0) {
			countServers++;
			cout << "Server N" << countServers;
			hostent* shostname = gethostbyaddr((char*)&((SOCKADDR_IN*)from)->sin_addr, sizeof(SOCKADDR_IN), AF_INET);
			cout << "\tIP: " << inet_ntoa(((SOCKADDR_IN*)from)->sin_addr) << endl;
			cout << "\t\tPort: " << ntohs(((struct sockaddr_in*)from)->sin_port) << endl;
			cout << "\t\tHostname: " << shostname->h_name << endl;
		}
	}
	catch (string errorMsgText)
	{
		if (WSAGetLastError() == WSAETIMEDOUT) {
			cout << "Total number of servers with that callsign: " << countServers << endl;
			if (closesocket(cC) == SOCKET_ERROR) throw SetErrorMsgText("closesocket: ", WSAGetLastError());
		}
		else throw SetErrorMsgText("GetServer:", WSAGetLastError());
	}
}


bool GetRequestFromClient(char* name, short port, sockaddr* from, int* flen)
{
	int lbuf;
	char ibuf[50] = "";

	cout << "Wait message..." << endl;
	while (true)
	{
		memset(from, 0, *flen);
		if (lbuf = recvfrom(port, ibuf, sizeof(ibuf), NULL, from, flen) == SOCKET_ERROR)
		{
			cout << "\n������� ����������� ��������\n";
			if (WSAGetLastError() == WSAETIMEDOUT)
				return false;
			else
				throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
		}
		if (strcmp(ibuf, name) == 0)
			return true;
		else
			return false;
	}
}

bool PutAnswerToClient(
	char* name, //[in] �������� �������
	short port,
	sockaddr* to, //[in] ��������� �� SOCKADDR_IN
	int* lto //[in] ��������� �� ������ from
)
{
	int size = strlen(name) + 1;
	return sendto(port, name, size, NULL, to, *lto) != SOCKET_ERROR;
}

string  SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
}

string  GetErrorMsgText(int code)    // c����������� ����� ������ 
{

	string msgText;
	switch (code)
	{
	case WSAEINTR:				 msgText = "������ ������� ��������\n";						  break;
	case WSAEACCES:				 msgText = "���������� ����������\n";						  break;
	case WSAEFAULT:				 msgText = "��������� �����\n";								  break;
	case WSAEINVAL:				 msgText = "������ � ���������\n";							  break;
	case WSAEMFILE:				 msgText = "������� ����� ������ �������\n";				  break;
	case WSAEWOULDBLOCK:		 msgText = "������ �������� ����������\n";					  break;
	case WSAEINPROGRESS:		 msgText = "�������� � �������� ��������\n";				  break;
	case WSAEALREADY: 			 msgText = "�������� ��� �����������\n";					  break;
	case WSAENOTSOCK:   		 msgText = "����� ����� �����������\n";						  break;
	case WSAEDESTADDRREQ:		 msgText = "��������� ����� ������������\n";				  break;
	case WSAEMSGSIZE:  			 msgText = "��������� ������� �������\n";				      break;
	case WSAEPROTOTYPE:			 msgText = "������������ ��� ��������� ��� ������\n";		  break;
	case WSAENOPROTOOPT:		 msgText = "������ � ����� ���������\n";					  break;
	case WSAEPROTONOSUPPORT:	 msgText = "�������� �� ��������������\n";					  break;
	case WSAESOCKTNOSUPPORT:	 msgText = "��� ������ �� ��������������\n";				  break;
	case WSAEOPNOTSUPP:			 msgText = "�������� �� ��������������\n";					  break;
	case WSAEPFNOSUPPORT:		 msgText = "��� ���������� �� ��������������\n";			  break;
	case WSAEAFNOSUPPORT:		 msgText = "��� ������� �� �������������� ����������\n";	  break;
	case WSAEADDRINUSE:			 msgText = "����� ��� ������������\n";						  break;
	case WSAEADDRNOTAVAIL:		 msgText = "����������� ����� �� ����� ���� �����������\n";	  break;
	case WSAENETDOWN:			 msgText = "���� ���������\n";								  break;
	case WSAENETUNREACH:		 msgText = "���� �� ���������\n";							  break;
	case WSAENETRESET:			 msgText = "���� ��������� ����������\n";					  break;
	case WSAECONNABORTED:		 msgText = "����������� ����� �����\n";						  break;
	case WSAECONNRESET:			 msgText = "����� �������������\n";							  break;
	case WSAENOBUFS:			 msgText = "�� ������� ������ ��� �������\n";				  break;
	case WSAEISCONN:			 msgText = "����� ��� ���������\n";							  break;
	case WSAENOTCONN:			 msgText = "����� �� ���������\n";							  break;
	case WSAESHUTDOWN:			 msgText = "������ ��������� send: ����� �������� ������\n";  break;
	case WSAETIMEDOUT:			 msgText = "���������� ���������� ��������  �������\n";		  break;
	case WSAECONNREFUSED:		 msgText = "���������� ���������\n";						  break;
	case WSAEHOSTDOWN:			 msgText = "���� � ����������������� ���������\n";			  break;
	case WSAEHOSTUNREACH:		 msgText = "��� �������� ��� �����\n";						  break;
	case WSAEPROCLIM:			 msgText = "������� ����� ���������\n";						  break;
	case WSASYSNOTREADY:		 msgText = "���� �� ��������\n";							  break;
	case WSAVERNOTSUPPORTED:	 msgText = "������ ������ ����������\n";					  break;
	case WSANOTINITIALISED:		 msgText = "�� ��������� ������������� WS2_32.DLL\n";		  break;
	case WSAEDISCON:			 msgText = "����������� ����������\n";						  break;
	case WSATYPE_NOT_FOUND:		 msgText = "����� �� ������\n";								  break;
	case WSAHOST_NOT_FOUND:		 msgText = "���� �� ������\n";								  break;
	case WSAEINVALIDPROCTABLE:	 msgText = "��������� ������\n";							  break;
	case WSAEINVALIDPROVIDER:	 msgText = "������ � ������ �������\n";						  break;
	case WSAEPROVIDERFAILEDINIT: msgText = "���������� ���������������� ������\n";			  break;
	case WSASYSCALLFAILURE:		 msgText = "��������� ���������� ���������� ������\n";		  break;
	case WSATRY_AGAIN:			 msgText = "������������������ ���� �� ������\n";			  break;
	case WSANO_RECOVERY:		 msgText = "�������������� ������\n";						  break;
	case WSANO_DATA:			 msgText = "��� ������ ������������ ����\n";				  break;
	default:					 msgText = "������ �� ����������\n";						  break;
	}

	return msgText;
}