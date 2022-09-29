.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

OK			EQU	0
TEXT_MESSAGE		DB "test", 0
HW			DD ?

FILELONG DD 1, 9, 8, 2
LONGSTR DB "long:     ", 0

FILEUINT8 DD 3
UINT8STR DB "uint8:     ", 0

.CODE

main PROC



mov eax, FILELONG 
add eax, 30h
mov LONGSTR +5, al


mov eax, FILELONG  + type FILELONG
add eax, 30h
mov LONGSTR +6, al


mov eax, FILELONG  + type FILELONG + type FILELONG
add eax, 30h
mov LONGSTR +7, al


mov eax, FILELONG  + type FILELONG + type FILELONG + type FILELONG
add eax, 30h
mov LONGSTR +8, al
invoke MessageBoxA, 0, offset LONGSTR, ADDR TEXT_MESSAGE, OK


mov eax, FILEUINT8 
add eax, 30h
mov UINT8STR + 6, al
invoke MessageBoxA, 0, offset UINT8STR, ADDR TEXT_MESSAGE, OK
push - 1
call ExitProcess
main ENDP
end main
