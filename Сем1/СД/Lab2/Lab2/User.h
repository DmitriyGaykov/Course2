#pragma once
class User
{
public:
	bool IsChecked;
	string Name;
	unsigned short Number;
	vector<User*> OtherUsers;

	static queue<User*> ExpectedUsers;
	static int AdjacencyMatrix[10][10];

	// Начало | Ширина

	User* ToUserBy(int Number)
	{
		cout << this->Number << " ";
		if (this->Number != Number)
		{
			AddToQueue();
			IsChecked = true;
			if (ExpectedUsers.size() != 0)
			{
				return GoToNumber(Number);
			}
			else
			{
				return nullptr;
			}
		}
		else
		{
			this->IsChecked = false;
			auto FindedUser = this;
			return FindedUser;
		}
	}

	void LinkWith(User* us)
	{
		us->OtherUsers.push_back(this);
		this->OtherUsers.push_back(us);

		AdjacencyMatrix[us->Number - 1][this->Number - 1] = 1;
		AdjacencyMatrix[this->Number - 1][us->Number - 1] = 1;
	}

	void LinksWith(int N, User* us, ...)
	{
		auto pUs = &us;
		for (int i = 0; i < N; i++)
		{
			this->LinkWith(*(pUs + i));
		}
	}

	User(int Number, string Name)
	{
		this->Number = Number;
		this->Name = Name;
		this->IsChecked = false;

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				AdjacencyMatrix[i][j] = 0;
			}
		}
	}

	// Конец | Ширина

	// Начало | Глубина

	User* GoDeep(int Number)
	{
		cout << this->Number << " ";

		if (this->Number != Number)
		{
			this->IsChecked = true;

			if (this->OtherUsers.size() != 0)
			{
				for (auto& el : OtherUsers)
				{
					if (!el->IsChecked)
					{
						auto Answer = el->GoDeep(Number);

						if (Answer != nullptr)
						{
							this->IsChecked = false;
							return Answer;
						}
					}
				}
			}
			else
			{
				this->IsChecked = false;
				return nullptr;
			}
		}
		else
		{
			this->IsChecked = false;
			return this;
		}
		this->IsChecked = false;
		return nullptr;
	}

	// Конец | Глубина

	void PrintInfoFromMatrix()
	{
		for (int i = 0; i < 10; i < i++)
		{
			cout << "User " << i + 1 << " связан с: ";
			for (int j = 0; j < 10; j++)
			{
				if (AdjacencyMatrix[i][j] == 1)
				{
					cout << "\t" << j + 1 << ";";
				}
			}
			cout << endl;
		}
	}

private:

	// Начало | Ширина
	void AddToQueue()
	{
		for (User* El : OtherUsers)
		{
			if (!El->IsChecked)
			{
				ExpectedUsers.push(El);
				El->IsChecked = true;
			}
		}
	}

	User* GoToNumber(int Number)
	{
		while (!ExpectedUsers.empty())
		{
			auto el = ExpectedUsers.front();
			ExpectedUsers.pop();

			auto Answer = el->ToUserBy(Number);

			if (Answer != nullptr)
			{
				while (!ExpectedUsers.empty()) // очистка очереди, если элемент найден
				{
					ExpectedUsers.pop();
				}

				this->IsChecked = false;

				return Answer;
			}
		}

		return nullptr;
	}
	// Конец | Ширина
};
queue<User*> User::ExpectedUsers;
int User::AdjacencyMatrix[10][10];