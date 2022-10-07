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

temp DD 0;

.CODE

getmin PROC parm1 : DWORD, parm2 : DWORD
START:
	mov esi, parm1;
	mov ecx, parm2;
	dec ecx;
	mov eax, [esi];
	add esi, 4;

	CYCLE:
		mov edx, [esi];
		cmp eax, edx;
		jl dontSetMin
		mov eax, edx;

		dontSetMin:
			add esi, 4;

	loop CYCLE;
	
	ret
getmin ENDP;

getmax PROC parm1 : DWORD, parm2: DWORD
START:
	mov esi, parm1;
	mov eax, [esi];
	add esi, 4;
	mov ecx, parm2;
	dec ecx;

	CYCLE:
		mov edx, [esi];
		cmp edx, eax;
		jl dontSetMax
		mov eax, edx;

		dontSetMax:
			add esi, 4;
	loop CYCLE;

	ret;
getmax ENDP;

END
	
