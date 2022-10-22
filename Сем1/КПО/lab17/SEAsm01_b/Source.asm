.586P													;система команд (процессор Pentium)
.MODEL FLAT, STDCALL									;модель памяти, соглашение о вызовах
includelib kernel32.lib									;компановщику: компоновать с kernel32
includelib user32.lib
includelib ucrt.lib		
includelib "..\SEAsm01_a\Debug\SEAsm01_a.lib"

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

getmax PROTO : DWORD, : DWORD;
getmin PROTO : DWORD, : DWORD;

WriteConsoleA		PROTO	: DWORD, : DWORD, : DWORD, : DWORD, : DWORD		;вывод на консоль(стандартная фукция)
SetConsoleTitleA	PROTO	: DWORD	

SetConsoleOutputCP	PROTO : DWORD									;устанавливает номер входной кодовой строки														;страницы для терминала
SetConsoleCP PROTO : DWORD

printconsole PROTO : DWORD ; вызов поцедуры вывода в консоль
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

		push -11;     стандартный вывод
	call GetStdHandle ; получить handle ->eax
	mov consolehandle, eax
	
	push 0
	push 0
	push sizeof pstr +2;количество выводимых байт
	push  pstr
	push consolehandle
	call WriteConsoleA

	ret
printconsole ENDP


int_to_char PROC uses eax ebx ecx edi esi,
	pstr : dword, ; адрес строки результата
	intfield : sdword ; число для преобразования
	
	
	mov edi, pstr ; копирует из pstr в edi
	mov esi, 0 ; количество символов в результате 
	mov eax, intfield ; число -> в eax
	cdq ; знак числа распространяется с eax на edx
	mov ebx, 10 ; основание системы счисления (10) -> ebx
	idiv ebx ; eax = eax/ebx, остаток в edx (деление целых со знаком)
	test eax, 80000000h ; тестируем знаковый бит
	jz plus ; если положительное число - на plus
	neg eax ; иначе мнеяем знак eax
	neg edx ; edx = -edx
	mov cl, '-' ; первый символ результата '-'
	mov[edi], cl ; первый символ результата '-'
	inc edi ; ++edi

plus : ; цикл разложения по степеням 10
	push dx ; остаток -> стек
	inc esi ; ++esi
	test eax, eax ; eax == ?
	jz fin ; если да, то на fin
	cdq ; знак распространяется с eax на edx 
	idiv ebx ; eax = eax/ebx, остаток в edx
	jmp plus ; безусловный переход на plus

fin : ; в ecx кол-во не 0-вых остатков = кол-ву символов результата
	mov ecx, esi
	write : ; цикл записи результата
	pop ebx ; остаток из стека -> bx
	add ebx, '0' ; сформировали символ в bl
	mov [esi], bl ; ebl -> в результат
	inc esi ; esi++
	loop write ; если (--ecx)>0 переход на write

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
	
