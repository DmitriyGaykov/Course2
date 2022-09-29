#pragma once
#define ASMHEADER \
\
<< ".586P" << endl \
<< ".MODEL FLAT, STDCALL" << endl \
<< "includelib kernel32.lib\n" << endl \
<< "ExitProcess PROTO : DWORD" << endl \
<< "MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD\n" << endl \
<< ".STACK 4096\n" << endl \
<< ".CONST\n" << endl \
<< ".DATA\n" << endl \
<< "OK			EQU	0" << endl \
<< "TEXT_MESSAGE		DB \"test\", 0" << endl \
<< "HW			DD ?\n" << endl \


class AsmGen
{
public:
	void CreateFile(long valLong, unsigned int valUnsigned);

private:
	const char* ASMFILE = "../SEAsm04_asm/asmFile.asm";
};

