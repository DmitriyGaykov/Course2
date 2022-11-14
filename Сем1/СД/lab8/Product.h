#pragma once

class Product
{
private:
	string name;
	int price;
	int amount;
	
public:

	Product()
	{

	}

	Product(
		string name, 
		int price,
		int amount)
	{
		this->name = name;
		this->price = price;
		this->amount = amount;
	}

	
	string GetName()
	{
		return name;
	}

	void SetName(string name)
	{
		this->name = name;
	}

	int GetPrice()
	{
		return price;
	}

	void SetPrice(int price)
	{
		this->price = price;
	}
	
	int GetAmount()
	{
		return amount;
	}
	
	void SetAmount(int amount)
	{
		this->amount = amount;
	}
};