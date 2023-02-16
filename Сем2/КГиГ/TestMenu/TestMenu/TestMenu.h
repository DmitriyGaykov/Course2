
// TestMenu.h: основной файл заголовка для приложения TestMenu
//
#pragma once

#ifndef __AFXWIN_H__
	#error "включить pch.h до включения этого файла в PCH"
#endif

#include "resource.h"       // основные символы


// CTestMenuApp:
// Сведения о реализации этого класса: TestMenu.cpp
//

class CTestMenuApp : public CWinApp
{
public:
	CTestMenuApp() noexcept;


// Переопределение
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Реализация

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CTestMenuApp theApp;
