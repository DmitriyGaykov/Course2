.586P													;������� ������ (��������� Pentium)
.MODEL FLAT, STDCALL									;������ ������, ���������� � �������
includelib kernel32.lib									;������������: ����������� � kernel32
includelib user32.lib
includelib ucrt.lib		
includelib "..\SEAsm01_a\Debug\SEAsm01_a.lib"

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

getmax PROTO : DWORD, : DWORD;
getmin PROTO : DWORD, : DWORD;

WriteConsoleA		PROTO	: DWORD, : DWORD, : DWORD, : DWORD, : DWORD		;����� �� �������(����������� ������)
SetConsoleTitleA	PROTO	: DWORD	

SetConsoleOutputCP	PROTO : DWORD									;������������� ����� ������� ������� ������														;�������� ��� ���������
SetConsoleCP PROTO : DWORD

printconsole PROTO : DWORD ; ����� �������� ������ � �������
GetStdHandle PROTO :DWORD
WriteConsoleA PROTO :DWORD,:DWORD,:DWORD,:DWORD,:DWORD

.STACK 4096

.DATA

min SDWORD 0

consolehandle dd 0h

arr SDWORD 1, 0, -202, 3, 5, 1, 2, 3, 3, 2

MB_OK EQU 0	
HW DWORD ?	


str1 DB "Menu", 0;
str2 DB "Max:  ",0;
str3 DB "       ", 0;

.CODE

printconsole proc uses eax ebx ecx edi esi,
	pstr :dword

		push -11;     ����������� �����
	call GetStdHandle ; �������� handle ->eax
	mov consolehandle, eax
	
	push 0
	push 0
	push sizeof pstr +2;���������� ��������� ����
	push  pstr
	push consolehandle
	call WriteConsoleA

	ret
printconsole ENDP


int_to_char PROC uses eax ebx ecx edi esi,
	pstr : dword, ; ����� ������ ����������
	intfield : sdword ; ����� ��� ��������������
	
	
	mov edi, pstr ; �������� �� pstr � edi
	mov esi, 0 ; ���������� �������� � ���������� 
	mov eax, intfield ; ����� -> � eax
	cdq ; ���� ����� ���������������� � eax �� edx
	mov ebx, 10 ; ��������� ������� ��������� (10) -> ebx
	idiv ebx ; eax = eax/ebx, ������� � edx (������� ����� �� ������)
	test eax, 80000000h ; ��������� �������� ���
	jz plus ; ���� ������������� ����� - �� plus
	neg eax ; ����� ������ ���� eax
	neg edx ; edx = -edx
	mov cl, '-' ; ������ ������ ���������� '-'
	mov[edi], cl ; ������ ������ ���������� '-'
	inc edi ; ++edi

plus : ; ���� ���������� �� �������� 10
	push dx ; ������� -> ����
	inc esi ; ++esi
	test eax, eax ; eax == ?
	jz fin ; ���� ��, �� �� fin
	cdq ; ���� ���������������� � eax �� edx 
	idiv ebx ; eax = eax/ebx, ������� � edx
	jmp plus ; ����������� ������� �� plus

fin : ; � ecx ���-�� �� 0-��� �������� = ���-�� �������� ����������
	mov ecx, esi
	write : ; ���� ������ ����������
	pop ebx ; ������� �� ����� -> bx
	add ebx, '0' ; ������������ ������ � bl
	mov [esi], bl ; ebl -> � ���������
	inc esi ; esi++
	loop write ; ���� (--ecx)>0 ������� �� write

	ret
int_to_char ENDP

result byte 60 dup(0)

main PROC

	START:

	INVOKE SetConsoleOutputCP, 1251d;
	INVOKE SetConsoleCP, 1251d;
	xor eax, eax;
	INVOKE getmin, arr, LENGTHOF arr;
	push eax;
	pop min;
	INVOKE ExitProcess, 0
	
main ENDP

end main
	
