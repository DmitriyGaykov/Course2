#include <iostream>
#include <string>
#include <Windows.h>

#define ent cout<<endl

using namespace std;

#include "Product.h"

void initProds(Product* prods, int N);
int calcMaxPrice(Product* prods, int N, int maxWeight);
void autoInit(Product* prods, int N);

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int N;
	int maxWeight;
	
	cout << "Введите максимальную вместимость рюкзака: ";
	cin >> maxWeight;
	
	cout << "Введите, сколько товаров будет: ";
	cin >> N;

	auto products = new Product[N];
	
	autoInit(products, N);
	
	ent;
	ent;
	
	int maxPrice = calcMaxPrice(products, N, maxWeight);
}
void autoInit(Product* prods, int N)
{
	for (int i = 0; i < N; i++)
	{
		prods[i].SetName("Product" + to_string(i));
		prods[i].SetPrice(rand() % 100 + 1);
		prods[i].SetAmount(rand() % 10 + 1);

		cout << "Товар " << prods[i].GetName() << " стоит " << prods[i].GetPrice() << " и весит " << prods[i].GetAmount() << endl;
	}
}

void fillNull(int** matrix, int rows, int cols)
{
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			matrix[i][j] = 0;
		}
	}
}

void initProds(Product* prods, int N)
{
	string name;
	int price;
	int amount;

	for (int i = 0; i < N; i++)
	{
		cout << "\n\nВведите название товара: ";
		cin >> name;
		cout << "\nВведите цену товара: ";
		cin >> price;
		cout << "\nВведите вместимость товара: ";
		cin >> amount;

		prods[i] = Product(name, price, amount);
	}
}

int calcMaxPrice(Product* prods, int N, int maxWeight)
{
	int result = 0;
	
	int** matrix = new int* [N + 1];

	int rows = N + 1;
	int cols = maxWeight + 1;

	for (int i = 0; i < rows; i++)
	{
		matrix[i] = new int[cols];
	}

	fillNull(matrix, rows, cols);

	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < cols; j++)
		{
			if (prods[i - 1].GetAmount() <= j)
			{
				matrix[i][j] = max(matrix[i - 1][j], matrix[i - 1][j - prods[i - 1].GetAmount()] + prods[i - 1].GetPrice());
			}
			else
			{
				matrix[i][j] = matrix[i - 1][j];
			}
		}
	}

	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < cols; j++)
		{
			cout << matrix[i][j] << "\t";
		}
		ent;
	}

	cout << "\nТовары, которые нужно взять: " << endl;
	
	int i = rows - 1;
	int j = cols - 1;

	while (i > 0 && j > 0)
	{
		if (matrix[i][j] != matrix[i - 1][j])
		{
			cout << prods[i - 1].GetName() << endl;
			j -= prods[i - 1].GetAmount();
		}
		i--;
	}

	for (int i = 0; i < rows; i++)
	{
		delete[] matrix[i];
	}
	delete[] matrix;
	return result;
}