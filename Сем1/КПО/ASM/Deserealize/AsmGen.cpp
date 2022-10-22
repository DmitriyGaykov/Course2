#include "AsmGen.h"
#include "stdafx.h"
#include <string>

string Join(string str);

void AsmGen::CreateFile(long Long, unsigned int Uint8) // 1 байт беззнаковое
{
	ofstream file(ASMFILE);
	string strLong = to_string(Long);
	string strUint8 = to_string(Uint8);
	strLong = Join(strLong);
	strUint8 = Join(strUint8);

	if (file.is_open())
	{
		file ASMHEADER;

		/*file << "FILESTR	 DB \"" << data.String << "\", 0" << endl << endl;

		file << "FILEINT	 DD " << '0' + data.Int << endl << endl;
		file << "INTSTR		DB \"num: \", 0" << endl;*/

		file << "FILELONG DD " << strLong << endl;
		file << "LONGSTR DB \"long:     \", 0" << endl << endl;
		file << "FILEUINT8 DD " << strUint8 << endl;
		file << "UINT8STR DB \"uint8:     \", 0" << endl << endl
			<< ".CODE\n" << endl
			<< "main PROC\n" << endl;

		string footer = "";
		string cTypes = "";
		int startI = 5;
		int countLong = to_string(Long).size();

		for (int i = 0; i < countLong; i++)
		{
			footer += "\n\nmov eax, FILELONG " + cTypes;
			footer += "\n";
			footer += "add eax, 30h\n";
			footer += "mov LONGSTR +" + to_string(startI++);
			footer += ", al\n";
			cTypes += " + type FILELONG";
		}

		footer += "invoke MessageBoxA, 0, offset LONGSTR, ADDR TEXT_MESSAGE, OK\n";

		string cTypesUint = "";
		startI = 6;

		for (int i = 0; i < to_string(Uint8).size(); i++)
		{
			footer += "\n\nmov eax, FILEUINT8 " + cTypesUint;
			footer += "\n";
			footer += "add eax, 30h\n";
			footer += "mov UINT8STR + " + to_string(startI++);
			footer += ", al\n";
			cTypesUint += " + type FILEUINT8";
		}

		footer += "invoke MessageBoxA, 0, offset UINT8STR, ADDR TEXT_MESSAGE, OK\n";

		footer += "push - 1\n";
		footer += "call ExitProcess\n";
		footer += "main ENDP\n";
		footer += "end main\n";

		file << footer;
	}
	else
	{
		cout << "File not open" << endl;
	}
}

string Join(string str)
{
	string newStr = "";
	for (int i = 0; i < str.size(); i++)
	{
		newStr += str[i];
		if (i + 1 != str.size())
		{
			newStr += ", ";
		}
	}
	return newStr;
}