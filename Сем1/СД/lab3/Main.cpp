#include <iostream>
#include <array>

using namespace std;

#include "check.h"
#include "Graff.h"

void main()
{
	setlocale(LC_ALL, "ru");

	GRAFF::Graff<string> graff;
	string elA = "A";
	string elB = "B";
	string elC = "C";
	string elD = "D";
	string elE = "E";
	string elF = "F";
	string elG = "G";
	string elH = "H";
	string elI = "I";

	graff.adds(9, &elA, &elB, &elC, &elD, &elE, &elF, &elG, &elH, &elI);

	graff.link(&elA, &elB, 7);
	graff.link(&elA, &elC, 10);
	graff.link(&elB, &elG, 27);
	graff.link(&elB, &elF, 9);
	graff.link(&elG, &elI, 15);
	graff.link(&elI, &elH, 15);
	graff.link(&elI, &elD, 21);
	graff.link(&elD, &elH, 17);
	graff.link(&elF, &elG, 11);
	graff.link(&elD, &elE, 32);
	graff.link(&elC, &elE, 31);
	graff.link(&elC, &elF, 8);

	// graff.goDeep(&elA, &elI);

	graff.getDistance(&elA);

}