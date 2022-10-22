#include <iostream>
#include <string>
#define INF INT_MAX-500

using namespace std;

// 1.	Разработать приложение, для нахождения всех кратчайшие пути в орграфе, используя алгоритм Флойда-Уоршелла.

void main()
{
	int dists[6][6] =
	{
		{0, 28, 21, 59, 12, 27},
		{7, 0, 24, INF, 21, 9},
		{9, 32, 0, 13, 11, INF},
		{8, INF, 5, 0, 16, INF},
		{14, 13, 15, 10, 0, 22},
		{15, 18, INF, INF, 6, 0},
	};

	int ways[6][6] =
	{
		{0, 2, 3, 4, 5, 6},
		{1, 0, 3, 4, 5, 6},
		{1, 2, 0, 4, 5, 6},
		{1, 2, 3, 0, 5, 6},
		{1, 2, 3, 4, 0, 6},
		{1, 2, 3, 4, 5, 0},
	};

	for (int k = 0; k < 6; k++)
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				if (dists[i][j] > dists[i][k] + dists[k][j])
				{
					dists[i][j] = dists[i][k] + dists[k][j];
					ways[i][j] = ways[i][k];
				}
			}
		}
	}

	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 6; j++)
		{
			cout << dists[i][j] << "\t";
		}
		cout << endl;
	}

	cout << endl;

	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 6; j++)
		{
			cout << ways[i][j] << "\t";
		}
		cout << endl;
	}
}