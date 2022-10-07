.586P													;система команд (процессор Pentium)
.MODEL FLAT, STDCALL									;модель памяти, соглашение о вызовах
includelib kernel32.lib									;компановщику: компоновать с kernel32
includelib user32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

getmin PROTO : DWORD, : DWORD
getmax PROTO : DWORD, : DWORD

.STACK 4096

.DATA


arr SDWORD 0, 2, 3, 4, 5, 6, 7, 8, 9
min SDWORD ?
max SDWORD ?

str1 DB "Menu", 0
str2 DB "Min =      Max =   ", 0

MB_OK EQU 0	
HW DWORD ?	

.CODE

getmin PROC parm1 : DWORD, parm2 : DWORD
START:
	mov ecx, parm2 ; ecx - счетчик
	mov esi, parm1 ; esi - индекс источника
	mov eax, [esi]
	add esi, 4
	dec ecx; -1
	
	CYCLE: 
		mov edx, [esi]; edx - регистр данных
		cmp eax, edx;
		jl dontSetMin
		mov eax, edx
	
	dontSetMin:
		add esi, 4

	loop CYCLE
	
	mov min, eax
	ret
getmin	ENDP

getmax PROC parm1 : DWORD, parm2 : DWORD
START:
	mov ecx, parm2;
	mov esi, parm1;
	mov eax, [esi];
	add esi, 4;
	dec ecx;

	CYCLE:
		mov edx, [esi];
		cmp edx, eax;
		jl dontSetMax;
		mov eax, edx;
		
	dontSetMax:
		add esi, 4
		
	loop CYCLE;
	mov max, eax
	ret;

getmax ENDP
	
main PROC

	START:
	INVOKE getmin, OFFSET arr, LENGTHOF arr
	INVOKE getmax, OFFSET arr, LENGTHOF arr
	
	mov eax, min;
	add eax, 30h;
	mov str2 + 7, al;
	
	mov eax, max;
	add eax, 30h;
	mov str2 + 18, al;
	
	INVOKE MessageBoxA, HW, offset str2,offset str1, 0
	
	push - 1
	call ExitProcess
	
main ENDP

end main
	
