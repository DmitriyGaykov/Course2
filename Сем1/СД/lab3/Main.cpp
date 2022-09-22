#include <iostream>
#include <array>

using namespace std;

#include "check.h"
#include "Graff.h"

void main()
{
	setlocale(LC_ALL, "ru");

	GRAFF::Graff<char> graff;
	char elA = 'A';
	char elB = 'B';
	char elC = 'C';
	char elD = 'D';
	char elE = 'E';
	char elF = 'F';
	char elG = 'G';
	char elH = 'H';
	char elI = 'I';

	graff.adds(9, &elA, &elB, &elC, &elD, &elE, &elF, &elG, &elH, &elI);

	graff.link(&elA, &elB, 7);
	graff.link(&elA, &elC, 10);
	graff.link(&elB, &elG, 27);
	graff.link(&elB, &elF, 9);
	graff.link(&elC, &elF, 8);
	graff.link(&elC, &elE, 31);
	graff.link(&elD, &elE, 32);
	graff.link(&elD, &elH, 17);
	graff.link(&elD, &elI, 21);
	graff.link(&elH, &elI, 15);
	graff.link(&elF, &elH, 11);
	graff.link(&elG, &elI, 15);

	// graff.goDeep(&elA, &elI);

	graff.outDistance(&elA);
	ent; ent;
	graff.outDistance(&elB);
	ent; ent;
	graff.outDistance(&elC);
	ent; ent;
	graff.outDistance(&elD);
	ent; ent;
	graff.outDistance(&elE);
	ent; ent;
	graff.outDistance(&elF);
	ent; ent;
	graff.outDistance(&elG);
	ent; ent;
	graff.outDistance(&elH);
	ent; ent;
	graff.outDistance(&elI);

}