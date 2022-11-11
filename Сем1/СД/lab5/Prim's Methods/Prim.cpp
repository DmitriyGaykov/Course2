#include <iostream>
#include <map>
#include <set>
#include <list>
#include <queue>
#include <algorithm>
#include <iterator>

#define Inf INT_MAX-5232
using namespace std;

const int N = 8;

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

bool areLinked(
	int** matrix,
	int el1,
	int el2,
	set<int>* visited = nullptr
);

int** CruskalaMethod();

void outOstTree(int** ostTree);

int getMin(
	int* posX,
	int* poxY,
	map<pair<int, int>, bool>& visited,
	set<int>& set,
	int** matrix);

void fillArr(
	int* arr,
	int val);

void main()
{
	setlocale(LC_ALL, "ru");

	auto ostTree = CruskalaMethod();

	outOstTree(ostTree);

	for (int i = 0; i < N; i++)
	{
		delete[] ostTree[i];
	}
	delete[] ostTree;
}

int** CruskalaMethod()
{
	int posX,
		posY;

	map<pair<int, int>, bool> visitedEls;
	set<int> setVisited;

	int min;

	bool allVisited = false;

	int countLinked = 0;

	// выделение памяти под остовое дерево

	int** ostTree = new int* [N];

	for (int i = 0; i < N; i++)
	{
		ostTree[i] = new int[N];

		fillArr(ostTree[i], Inf);
	}

	for (int i = 0; i < N; i++)
	{
		ostTree[i][i] = 0;
	}

	// конец выделения памяти 

	do
	{
		min = getMin(&posX, &posY, visitedEls, setVisited, ostTree);

		ostTree[posX][posY] = min;
		ostTree[posY][posX] = min;

		visitedEls[{posX, posY}] = true;
		visitedEls[{posY, posX}] = true;

		setVisited.insert(posX);
		setVisited.insert(posY);

	} while (setVisited.size() != N);

	int temp = ostTree[0][1];

	return ostTree;
}

int getMin(
	int* posX,
	int* poxY,
	map<pair<int, int>, bool>& visited,
	set<int>& setVisited,
	int** ostTree
)
{
	int min = Inf;
	int minI = 0;
	int minJ = 0;

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (
				matrix[i][j] < min &&
				matrix[i][j] != 0 &&
				!visited[{i, j}]
				)
			{
				if (areLinked(ostTree, i, j))
				{
					continue;
				}
				min = matrix[i][j];
				minI = i;
				minJ = j;
			}
		}
	}

	*posX = minI;
	*poxY = minJ;
	visited[{minI, minJ}] = true;
	visited[{minJ, minI}] = true;

	cout << minI + 1 << "  " << minJ + 1 << endl;

	return min;
}

void fillArr(
	int* arr,
	int val)
{
	for (int i = 0; i < N; i++)
	{
		arr[i] = val;
	}
}

void outOstTree(int** ostTree)
{
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (ostTree[i][j] != Inf)
			{
				cout << i + 1 << " - " << j + 1 << " = " << ostTree[i][j] << endl;
			}
		}
		cout << endl;
	}
}

bool areLinked(
	int** matrix,
	int el1,
	int el2,
	set<int>* visited
)
{
	if (visited == nullptr)
	{
		visited = new set<int>;
	}

	if (visited->find(el1) == visited->end())
	{
		visited->insert(el1);
		if (matrix[el1][el2] != Inf)
		{
			delete visited;
			return true;
		}
		else
		{
			for (int i = 0; i < N; i++)
			{
				if (
					matrix[el1][i] != Inf &&
					i != el1)
				{
					if (areLinked(matrix, i, el2, visited))
					{
						return true;
					}
				}
			}
		}
	}
	return false;
}
