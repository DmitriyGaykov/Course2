#pragma once
#include "stdafx.h"
using namespace std;
#define INF INT_MAX-SHRT_MAX

struct Data
{
	string value;

	vector<Data*> link_with;

	Data(string value)
	{
		this->value = value;
	}
	Data()
	{
		this->value = "";
	}
};

class Graff
{
public:
	
	void add(string value)
	{
		if (has(value))
		{
			return;
		}
		
		auto node = new Data(value);
		els.push_back(node);
	}
	
	void link(
		string value1,
		string value2,
		int dist)
	{
		if (!has(value1) || !has(value2))
		{
			return;
		}

		auto node1 = get(value1);
		auto node2 = get(value2);

		if (node1 == nullptr || node2 == nullptr)
		{
			return;
		}

		node1->link_with.push_back(node2);
		node2->link_with.push_back(node1);

		this->dist[node1->value][node2->value] = dist;
		this->dist[node2->value][node1->value] = dist;
	}
	
	bool has(string value)
	{
		for (auto i : els)
		{
			if (i->value == value)
			{
				return true;
			}
		}

		return false;
	}
	
	Data* get(string value)
	{
		for (int i = 0; i < els.size(); i++)
		{
			if (els[i]->value == value)
			{
				return els[i];
			}
		}
		
		return nullptr;
	}

	void clear()
	{
		for (int i = 0; i < els.size(); i++)
		{
			delete els[i];
		}
	}

	string get_way(string a)
	{
		string way = "";
		
		auto last = els.back();
		auto node = get(a);
		bool is_finded;

		while (node != last)
		{
			is_finded = false;
			
			for (int i = 0; i < last->link_with.size(); i++)
			{
				if (last->link_with[i]->value.find(a) != string::npos)
				{
					way += to_string(dist[last->value][last->link_with[i]->value]);
					last = last->link_with[i];
					is_finded = true;
					break;
				}
			}

			if (!is_finded)
			{
				return "None";
			}
		}

		return way;
	}
	
	~Graff()
	{
		clear();
	}
	
private:	
	vector<Data*> els;
	map<string, map<string, int>> dist;
	int size;
};