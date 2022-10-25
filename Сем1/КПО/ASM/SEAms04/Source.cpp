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

		cout << "Enter long value(long name value ): ";
		cin.getline(longVal, 50);

	Long = atol(longVal + indexNumIn(longVal));

		cout << "Enter unsigned value(unsigned name value ): ";
		cin.getline(unsignedVal, 30);

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