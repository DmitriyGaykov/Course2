#include <iostream>
#include <string>
#include <vector>

using namespace std;

static int startN;

vector<int> find(
	int* arr,
	int N,
	vector<vector<int>>* subseqs = nullptr,
	vector<int> seq = {}
);

void main()
{
	setlocale(LC_ALL, "ru");
	int* arr;
	int N;

	cout << "—колько элементов будет?\n";
	cin >> N;

	arr = new int[N];

	for (int i = 0; i < N; i++)
	{
		cout << "\n\n¬ведите число: ";
		cin >> arr[i];
	}

	auto seq = find(arr, N);

	cout << endl;
	for (auto i : seq)
	{
		cout << i << " ";
	}

	delete[] arr;
}

vector<int> find(
	int* arr,
	int N,
	vector<vector<int>>* subseqs,
	vector<int> seq
)
{
	if (subseqs == nullptr)
	{
		subseqs = new vector<vector<int>>();
		startN = N;
	}

	seq.push_back(arr[0]);

	for (int i = 1; i < N; i++)
	{
		if (arr[0] <= arr[i])
		{
			find(arr + i, N - i, subseqs, seq);
		}
	}

	subseqs->push_back(seq);

	if (N == startN)
	{
		int max = -1;
		vector<int> _seq;
		int length;

		for (auto i : *subseqs)
		{
			length = i.size();

			if (max < length)
			{
				max = length;
				_seq = i;
			}
		}

		delete subseqs;

		return _seq;
	}

	return {};
}