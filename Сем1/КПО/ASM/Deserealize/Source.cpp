#include "stdafx.h"
#include "AsmGen.h"

void main()
{
	setlocale(LC_ALL, "ru");
	long longVal;
	unsigned int unsignedVal;

	Desearealizer des;
	des.Deserialize(&longVal, &unsignedVal);

	cout << longVal << " " << unsignedVal << endl;

	AsmGen AG;
	AG.CreateFile(longVal, unsignedVal);
}