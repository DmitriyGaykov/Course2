#include <iostream>
#include <set>
#include <queue>

using namespace std;

#define Inf INT_MAX-5232
using namespace std;

const int N = 8;

int** PrimsMethods();

int matrix[N][N] =
{
	{0, 2, Inf, 8, 2, Inf, Inf, Inf},
	{2, 0, 3, 10, 5, Inf, Inf, Inf},
	{Inf, 3, 0, Inf, 12, Inf, Inf, 7},
	{8, 10, Inf, 0, 14, 3, 1, Inf},
	{2, 5, 12, 14, 0, 11, 4, 8},
	{Inf, Inf, Inf, 3, 11, 0, 6, Inf},
	{Inf, Inf, Inf, 1, 4, 6, 0, 9},
	{Inf, Inf, 7, Inf, 8, Inf, 9, 0}
};

void main()
{
	setlocale(LC_ALL, "ru");

	auto ostTree = PrimsMethods();

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (matrix[i][j] != Inf)
			{
				cout << i + 1 << " - " << j + 1 << " = " << matrix[i][j] << endl;
			}
		}
		cout << endl;
	}
}

void go(
	set<int>& visited,
	int start,
	queue<int>* to = nullptr);

void fillLinked(
	queue<int>& linked,
	int posX);

int** PrimsMethods()
{
	set<int> visited;
	int** ostTree = new int* [N];

	for (int i = 0; i < N; i++)
	{
		ostTree[i] = new int[N];
	}

	go(visited, 0);

	return ostTree;
}

void go(
	set<int>& visited,
	int start,
	queue<int>* to)
{
	if (visited.size() == N)
	{
		return;
	}
	if (to == nullptr)
	{
		to = new queue<int>;
	}

	visited.insert(start);
	queue<int> linked;
	queue<int> temp;

	fillLinked(linked, start);

	temp = linked;
	int el;
	int min = Inf;
	int minIndex;

	while (!linked.empty())
	{
		el = linked.front();

		if (
			min > matrix[start][el] &&
			visited.find(el) == visited.end())
		{
			min = matrix[start][el];
			minIndex = el;
		}

		linked.pop();
	}

	linked = temp;

	while (!linked.empty())
	{
		el = linked.front();

		if (
			min != matrix[start][el] &&
			visited.find(el) == visited.end())
		{
			matrix[start][el] = matrix[el][start] = Inf;
		}
		else
		{
			to->push(el);
		}

		linked.pop();
	}

	el = to->front();

	while (!to->empty())
	{
		el = to->front();

		to->pop();
		go(visited, el, to);
	}
}

void fillLinked(
	queue<int>& linked,
	int posX)
{
	for (int i = 0; i < N; i++)
	{
		if (
			matrix[posX][i] != Inf &&
			posX != i)
		{
			linked.push(i);
		}
	}
}