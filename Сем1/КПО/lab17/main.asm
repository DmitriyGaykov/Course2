.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

; программа вызывает локальную процедуру с именем getmin;
; локальна€ процедура принимает два параметра:
; 1) адрес первого элемента массива четырехбайтовых целых чисел;
; 2) количество элементов в массиве;


ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD
 

.STACK 4096

.CONST

.DATA

OK			EQU	0
TEXT_MESSAGE		DB "test", 0
HW			DD ?

Nums dd 1,2,3,4,5,6,7,8,9,10

.CODE

main PROC

; программа объ€вл€ет и инициализирует массив из 10
; четырехбайтовых целых чисел;



; mov eax, FILELONG 
; add eax, 30h
; mov LONGSTR +5, al


push - 1
call ExitProcess
main ENDP
end main