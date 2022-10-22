#include "Serealizer.h"
#include "stdafx.h"

void Serealizer::Serialize(long longVal, unsigned int unsignedVal)
{
	ofstream file(FILENAME, ios::binary);
	if (file.is_open())
	{
		file.write(reinterpret_cast<char*>(&longVal), sizeof(long));
		file.write(reinterpret_cast<char*>(&unsignedVal), sizeof(unsigned int));
		file.close();
	}
	else
	{
		cout << "File not open" << endl;
	}
}