#include <iostream>
#include <string>
#include <conio.h>
#include <iomanip>

#include "Ex2/Levenshtein.h"

using namespace std;

string generateString(uint16_t len);

void main() {
	setlocale(LC_ALL, "ru");
	srand(time(NULL));

	string str300 = generateString(300);
	string str200 = generateString(200);

	cout << "Строка на 300 элементов: " << str300 << "\n\n";
	cout << "Строка на 200 элементов: " << str200 << "\n\n";

	clock_t 
		t1 = 0,
		t2 = 0,
		t3 = 0, 
		t4 = 0;

	int lx = sizeof(str300);
	int ly = sizeof(str200);

	int s1_size[]{ 300 / 25, 300 / 20, 300 / 15, 300 / 10, 300 / 5, 300 / 2, 300 };
	int s2_size[]{ 200 / 25, 200 / 20, 200 / 15, 200 / 10, 200 / 5, 200 / 2, 200 };

	std::cout << std::endl;
	std::cout << std::endl << "-- расстояние Левенштейна -----" << std::endl;
	std::cout << std::endl << "--длина --- рекурсия -- дин.програм. ---"
		<< std::endl;

	for (int i = 0; i < min(lx, ly); i++)
	{
		t1 = clock();
			levenshtein_r(s1_size[i], str300.c_str(), s2_size[i], str200.c_str());
		t2 = clock();

		t3 = clock();
			levenshtein(s1_size[i], str300.c_str(), s2_size[i], str200.c_str());
		t4 = clock();

		cout << right << setw(2) << s1_size[i] << "/" << setw(2) << s2_size[i]
			<< "        " << left << setw(10) << (t2 - t1)
			<< "   " << setw(10) << (t4 - t3) << endl;
	}
	system("pause");
}

string generateString(uint16_t len) {
	string res = ""s;

	static const auto calc = [](uint8_t start, uint8_t end) {
		return rand() % (end - start + 1) + start;
	};

	const char fstart = 'a';
	const char fend = 'z';

	const char sstart = 'A';
	const char send = 'Z';

	char symb;
	uint8_t rnum;

	for (uint16_t i = 0; i < len; i++) {
		rnum = rand() % 100 + 1;

		symb = rnum > 50 ? 
			   calc(fstart, fend) :
			   calc(sstart, send);

		res += symb;
	}

	return res;
}