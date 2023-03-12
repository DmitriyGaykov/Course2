
// ChildView.h: интерфейс класса CChildView
//
#include <iostream>
using std::string;

#pragma once


// Окно CChildView

class CChildView : public CWnd
{
// Создание
public:
	CChildView();

// Атрибуты
public:
	CPaintDC* dc; // контекст устройства для рисования
// Операции
public:

// Переопределение
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Реализация
public:
	virtual ~CChildView();

	// Созданные функции схемы сообщений
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnClickMatrix();
	afx_msg void OnExpression();
	afx_msg void OnVect();
	afx_msg void OnScalar();
	afx_msg void OnCos();
	afx_msg void OnSphere();
	afx_msg void OnMod();
	void hideOther(string text);
};

