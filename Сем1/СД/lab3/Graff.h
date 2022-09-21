#pragma once
#include <vector>
#include <map>

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

		void add(T* el)
		{
			if (dataAbout[el] != NULL)
				return;

			allElements.push_back(el);
			Data* El = new Data(allElements.size(), el);

			dataAbout[el] = El;

			allDatas.push_back(El);
			Length++;
		} // добавить один элемент

		void adds(int n, T* el, ...)
		{
			auto first = &el;
			for (int i = 0; i < n; i++)
			{
				this->add(*(first + i));
			}
		} // добавить несколько элементов

		bool link(T* el1, T* el2, int distance)
		{
			if (dataAbout[el1] == NULL || dataAbout[el2] == NULL)
				return false;

			dataAbout[el1]->joined_Els.push_back(el2);
			dataAbout[el2]->joined_Els.push_back(el1);

			this->distance[el1][el2] = distance;
			this->distance[el2][el1] = distance;

			return true;
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

		void getDistance(T* el)
		{
			map<T*, int> distBetween;
			auto els = allElements;

			els.erase(els.begin() + indexOf(el, allElements));

			for (auto i : els)
			{
				distBetween[i] = INT_MAX;
			}

			for (auto i : els)
			{
				cout << "От " << *el << " до " << *i << " = " << GoDeystra(&distBetween, el, i, el) << endl;
			}


		}

	private:
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

		int GoDeystra(map<T*, int>* distBetween, T* el1, T* el2, T* baseEl, int wasWalked = 0)
		{

		}
	};
}