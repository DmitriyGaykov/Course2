#pragma once
#include "stdafx.h"

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

void out_table(
	set<string> symbs,
	map<string, int> count_in_str);

void out_table(
	set<string> symbs,
	Graff& graff,
	string str
);