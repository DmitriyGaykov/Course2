#pragma once
#include <vector>
#include <map>
#include <stack>
#include <queue>

using namespace std;

namespace GRAFF
{
	template <typename T>
	class Graff
	{
	public:
		int Length = 0;

		typedef vector<T*> Links;

		~Graff()
		{
			Clear();
		}

		void add(T* el) // добавить один элемент в граф
		{
			if (dataAbout[el] != NULL)
				return;

			allElements.push_back(el);
			Data* El = new Data(allElements.size(), el);

			dataAbout[el] = El;

			allDatas.push_back(El);
			Length++;
		} // добавить один элемент

		void adds(int n, T* el, ...) // добавить N элементов в граф
		{
			auto first = &el;
			for (int i = 0; i < n; i++)
			{
				this->add(*(first + i));
			}
		} // добавить несколько элементов

		bool link(T* el1, T* el2, int distance) // связать элементы
		{
			if (dataAbout[el1] == NULL || dataAbout[el2] == NULL)
				return false;

			dataAbout[el1]->joined_Els.push_back(el2);
			dataAbout[el2]->joined_Els.push_back(el1);

			this->distance[el1][el2] = distance;
			this->distance[el2][el1] = distance;

			return true;
		}

		bool isLinked(T* el1, T* el2) // проверка на связаны ли вершины
		{
			for (auto i : dataAbout[el1]->joined_Els)
			{
				if (i == el2)
				{
					return true;
				}
			}

			return false;
		}

		T* getElements()
		{
			T* arr = new T[allElements.size()];

			for (int i = 0; i < allElements.size(); i++)
			{
				arr[i] = *allElements[i];
			}

			return arr;
		} // получить все элементы графа

		void goDeep(T* el1, T* el2)
		{
			auto result = search(el1, el2);
			outWay();
			clearVisited();
			cout << " " << *result << endl;
		}

		void outDistance(T* el)
		{
			map<T*, map<T*, int>> dists;
			map<T*, int> resDist;
			for (int i = 0; i < allElements.size(); i++)
			{
				els = allElements;
				fillDist();
				dist[allElements[i]] = 0;
				getDistance(allElements[i]);
				dists[allElements[i]] = dist;
			}


			for (auto i : allElements)
			{
				if (i != el)
				{
					resDist[i] = ((dists[i][el] > dists[el][i]) ? dists[el][i] : dists[i][el]);
				}
			}

			dist = resDist;
			out(el);
		}

		void getDistance(T* el, int cost = 0)
		{
			auto linkWith = dataAbout[el]->joined_Els;
			els.erase(els.begin() + indexOf(el, els));
			int min = INT_MAX;
			T* pMin = nullptr;

			for (auto i : linkWith)
			{
				if (dist[i] > (cost + distance[el][i]))
				{
					dist[i] = cost + distance[el][i];

					if (dist[i] < min && indexOf(i, els) != -1)
					{
						min = dist[i];
						pMin = i;
					}
				}
			}

			if (pMin != nullptr)
			{
				getDistance(pMin, dist[pMin]);

				for (auto i : linkWith)
				{
					if (indexOf(i, els) != -1 && i != pMin)
					{
						getDistance(i, cost + distance[el][i]);
					}
				}
			}
		}

	private:
		map<T*, int> dist;
		vector<T*> Visited;
		vector<T*> els;

		struct Data
		{
			int number;
			T* element;
			Links joined_Els;

			Data(int number, T* element)
			{
				this->number = number;
				this->element = element;
			}
		};

		Links allElements; // все элементы графа
		map<T*, Data*> dataAbout; // информация об отдельном элементе графа
		vector<Data*> allDatas;
		map<T*, map<T*, int>> distance; // расстояния между элементами

		vector<int> allVisited; // все посещенные элементы

		void Clear()
		{
			for (auto i : allDatas)
			{
				delete i;
			}
		}

		vector<T*> sortVector(vector<T*>* pVec)
		{
			auto vec = *pVec;
			bool isSorted = true;

			do
			{
				isSorted = true;

				for (int i = 0; i < vec.size() - 1; i++)
				{
					if (*vec[i] > *vec[i + 1])
					{
						auto temp = vec[i];
						vec[i] = vec[i + 1];
						vec[i + 1] = temp;
						isSorted = false;
					}
				}

			} while (!isSorted);

			return vec;
		}

		T* search(T* el1, T* el2)
		{
			allVisited.push_back(dataAbout[el1]->number);

			if (el1 == el2)
			{
				return el1;
			}
			else
			{
				for (auto el : dataAbout[el1]->joined_Els)
				{
					if (!isThere(dataAbout[el]->number))
					{
						if (el == el2)
						{
							allVisited.push_back(dataAbout[el]->number);
							return el;
						}
						else
						{
							auto res = search(el, el2);

							if (res != nullptr)
								return res;
						}
					}
				}
			}

			return nullptr;
		}

		void outWay()
		{
			for (auto i : allVisited)
			{
				cout << i << " ";
			}
		}

		void clearVisited()
		{
			allVisited.clear();
		}

		bool isThere(int number)
		{
			for (auto el : allVisited)
			{
				if (el == number)
				{
					return true;
				}
			}
			return false;
		}

		template <typename T2>

		int indexOf(T* el, T2 collection)
		{
			int num = 0;
			for (auto i : collection)
			{
				if (i == el)
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		int indexOf(T* el, queue<T*> q)
		{
			int index = 0;
			while (!q.empty())
			{
				if (el == q.front())
				{
					return index;
				}
				index++;
				q.pop();
			}
			return -1;
		}

		void outVect()
		{
			for (auto i : els)
			{
				cout << *i << " ";
			}
		}

		void fillDist()
		{
			for (auto el : els)
			{
				dist[el] = INT_MAX;
			}
		}

		void out(T* El)
		{
			for (auto el : allElements)
			{
				cout << "От " << *El << " до " << *el << " = " << dist[el] << endl;
			}
		}
	};
}