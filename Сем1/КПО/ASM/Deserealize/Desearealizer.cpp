#include "Desearealizer.h"
#include "stdafx.h"

void Desearealizer::Deserialize(long* valLong, unsigned int* valUnsigned)
{
	ifstream file(FILENAME, ios::binary);
	if (file.is_open())
	{
		file.read(reinterpret_cast<char*>(valLong), sizeof(long));
		file.read(reinterpret_cast<char*>(valUnsigned), sizeof(unsigned int));
		file.close();
	}
	else
	{
		cout << "File not open" << endl;
	}
}