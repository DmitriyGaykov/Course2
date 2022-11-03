#include "Hafner.h"

void hafner(string str)
{
	set<string> symbs;
	int count_of_all;
	map<string, int> count_in_str;
	Graff graff;
	
	string last;
	string pre_last;
	string new_el;

	get_count_of_symb_in(str, count_in_str, symbs);

	auto temp = symbs;
	
	out_table(symbs, count_in_str);

	count_of_all = symbs.size();
	
	auto els = new Node[symbs.size()];
	int index_of_last;
	fill_els(els, symbs, count_in_str);
	
	while (els[0].symb.size() != count_of_all)
	{
		sort(els, symbs.size());
        ////////////////////////////////////////////
		index_of_last = symbs.size() - 1;

		last = els[index_of_last].symb;
		pre_last = els[index_of_last - 1].symb;

		new_el = last + pre_last;

		////////////////////////////////////////////

		count_in_str[new_el] = count_in_str[last] + count_in_str[pre_last];

		////////////////////////////////////////////
		
		count_in_str.erase(last);
		count_in_str.erase(pre_last);
		
		////////////////////////////////////////////

		symbs.erase(last);
		symbs.erase(pre_last);

		////////////////////////////////////////////

		graff.add(last);
		graff.add(pre_last);
		graff.add(new_el);

		graff.link(last, new_el, 0);
		graff.link(pre_last, new_el, 1);
		
		////////////////////////////////////////////

		symbs.insert(new_el);

		////////////////////////////////////////////

		els = fill_els(els, symbs, count_in_str);
	}
	symbs = temp;
	
	out_table(symbs, graff, str);
	
	delete[] els;
}

void get_count_of_symb_in(
	string str,
	map<string, int>& count_in_str,
	set<string>& symbs
)
{
	string temp;
	for (auto s : str)
	{
		temp = s;
		symbs.insert(temp);
		count_in_str[temp]++;
	}
}

Node* fill_els(
	Node* els,
	set<string>& symbs,
	map<string, int>& count_in_str
)
{
	delete[] els;
	els = new Node[symbs.size()];
	
	int i = 0;
	for (auto s : symbs)
	{
		els[i] = { s, count_in_str[s] };
		i++;
	}

	return els;
}

void sort(
	Node* arr, 
	int length)
{
	bool is_sorted = false;

	while (!is_sorted)
	{
		is_sorted = true;
		for (int i = 0; i < length - 1; i++)
		{
			if (arr[i].count < arr[i + 1].count)
			{
				is_sorted = false;
				swap(arr[i], arr[i + 1]);
			}
		}
	}
}

Node::Node(
	string symb,
	int count
)
{
	this->symb = symb;
	this->count = count;
}

Node::Node()
{
	this->count = 0;
	this->symb = "";
}


void out_table(
	set<string> symbs,
	map<string, int> count_in_str)
{
	cout << "Таблица встречаемости" << endl;
	
	for (auto i : symbs)
	{
		cout << i << "\t\t" << count_in_str[i] << endl;
	}
}

void out_table(
	set<string> symbs,
	Graff& graff,
	string str
)
{
	cout << "\n\nТаблица на соответсвие каждому символу его кода" << endl;
	
	for (auto i : symbs)
	{
		cout << i << "\t\t" << graff.get_way(i) << endl;
	}

	cout << "\n\nИсходная строка: " << str << endl;
	
	string new_str;
	string temp;
	
	for (auto i : str)
	{
		temp = i;
		new_str += graff.get_way(temp);
	}
	
	cout << "\n\nНовая строка: " << new_str << endl;
}