#pragma once
#include <iostream>
#include <algorithm>
#include <map>
#include <string>
#include <vector>
#include <set>
#include "Graff.h"

using namespace GRAFF;
using namespace std;

struct Node
{
	string symb;
	int count;

	Node(
		string symb,
		int count
	);

	Node();
};

void get_count_of_symb_in(
	string str,
	map<string, int>& count_in_str,
	set<string>& symbs
);

void hafner(string str);

Node* fill_els(
	Node* els,
	set<string>& symbs,
	map<string, int>& count_in_str
);

void sort(
	Node* arr,
	int length);

void add_to_graff(
	Graff& graff,
	set<string>& symbs);