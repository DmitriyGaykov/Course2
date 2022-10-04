#include "stdafx.h"
#include "Serealizer.h"

using namespace std;
int indexNumIn(char arr[]);

void main()
{
	setlocale(LC_ALL, "ru");
	Serealizer serealizer;
	char longVal[50];
	long Long;
	char unsignedVal[30];
	unsigned short Unsigned;

	do
	{
		cout << "Enter long value(long name value ): ";
		cin.getline(longVal, 50);
	} while (!regex_match(longVal, longVal + strlen(longVal), regex("long [A-Za-z]+ (-|\\+|)([0-9]){1,10}")));

	Long = atol(longVal + indexNumIn(longVal));

	do
	{
		cout << "Enter unsigned value(unsigned name value ): ";
		cin.getline(unsignedVal, 30);
	} while (!regex_match(unsignedVal, unsignedVal + strlen(unsignedVal), regex("unsigned [A-Za-z]+ [0-9]{1,3}")) && (Unsigned = strtoul(unsignedVal + 9, NULL, 10)) <= 255);

	Unsigned = strtoul(unsignedVal + indexNumIn(unsignedVal), NULL, 10);

	cout << Long << " " << Unsigned << endl;

	serealizer.Serialize(Long, Unsigned);
}

int indexNumIn(char arr[])
{
	int i = 0;
	for (; i < strlen(arr); i++)
	{
		if (
			(arr[i] >= '0' && arr[i] <= '9') ||
			arr[i] == '-' || arr[i] == '+'
			)
		{
			return i;
		}
	}
	return -1;
}