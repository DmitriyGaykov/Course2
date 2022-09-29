#pragma once
class Serealizer
{
public:
	void Serialize(long valLong, unsigned int valUnsigned);

private:
	const char* FILENAME = "bin.txt";
};

