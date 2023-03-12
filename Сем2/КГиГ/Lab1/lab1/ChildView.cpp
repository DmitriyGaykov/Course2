
// ChildView.cpp: реализация класса CChildView
//

#include "pch.h"
#include "framework.h"
#include "lab1.h"
#include "ChildView.h"
#include "CMatrix.h";
#include "MyFuns.h";
#include <wchar.h>
#include <String>
#include <corecrt_wstring.h>
#include <map>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define MENU_TESTS 700

#define SUBMENU_MATRIX 8001

// CChildView

CChildView::CChildView()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "RU");
	srand(1);
	dc = nullptr;
}

CChildView::~CChildView()
{
}


BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_COMMAND(24, &CChildView::OnClickMatrix)
	ON_COMMAND(ID_EXPR, &CChildView::OnExpression)
	ON_COMMAND(ID_VECT, &CChildView::OnVect)
	ON_COMMAND(ID_SCALAR, &CChildView::OnScalar)
	ON_COMMAND(ID_COS, &CChildView::OnCos)
	ON_COMMAND(ID_SPHERE, &CChildView::OnSphere)
	ON_COMMAND(ID_MOD, &CChildView::OnMod)
END_MESSAGE_MAP()



// Обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(nullptr, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), nullptr);

	return TRUE;
}

CMatrix A = initMatrix(3, 3),
		B = initMatrix(3, 3),
		V1 = initMatrix(3, 1),
		V2 = initMatrix(3, 1);

map<string, bool> isClicked = {
	{"Выражения", false},
	{"Векторное умножение", false},
	{"Скалярное произведение", false},
	{"Модуль", false},
	{"Косинус", false},
	{"Сферические", false}
};

void CChildView::OnPaint() 
{
	if (dc != nullptr)
	{
		delete dc;
	}
	this->dc = new CPaintDC(this);

	if (isClicked["Выражения"])
	{
		auto C1 = A + B;
		PrintExpression(50, 50, *dc, A, L"+", B, C1);

		auto C2 = A * B;
		PrintExpression(50, 4 * SIZE, *dc, A, L"*", B, C2);

		auto D = A * V1;
		PrintExpression(50, 8 * SIZE, *dc, A, L"*", V1, D);

		auto q = V1.Transp() * V2;
		PrintExpression(50, 12 * SIZE, *dc, V1.Transp(), L"*", V2, q);

		auto p = V1.Transp() * A * V2;
		PrintExpression(50, 16 * SIZE, *dc, V1.Transp(), L"*", A, V1.Transp() * A);
		PrintExpression(1000, 16 * SIZE, *dc, V1.Transp() * A, L"*", V2, p);
	}

	if (isClicked["Векторное умножение"])
	{
		auto vecV1V2 = VectorMult(V1, V2);
		PrintExpression(50, 50, *dc, V1, L"x", V2, vecV1V2);
	}
	if (isClicked["Скалярное произведение"])
	{
		auto scalV1V2 = ScalarMult(V1, V2);
		auto x = PrintExpWithoutAnswer(50, 50, *dc, V1, L"•", V2);
		const wchar_t* wchAnsw = to_wchar(scalV1V2);
		dc->TextOutW(x, 2 * SIZE, wchAnsw);
	}
	if (isClicked["Модуль"])
	{
		auto modV1 = ModVec(V1);
		wchar_t startText[30] = L"|V1| = ";
		wcscat_s(startText, to_wchar(modV1));
		dc->TextOutW(50, 50, startText);
	}

	wchar_t Text[30] = L"CosV1V2 = ";
	if (isClicked["Косинус"])
	{
		double cos = CosV1V2(V1, V2);
		wcscat_s(Text, to_wchar(cos));
		dc->TextOutW(50, 50, Text);
	}

	if (isClicked["Сферические"])
	{
		CMatrix sphere = SphereToCart(V1);
		wcscpy_s(Text, L"SphereToCart(V1) = ");
		dc->TextOutW(40, 2 * SIZE, Text);
		PrintMatrix(*dc, 250, SIZE, sphere);
	}
}



void CChildView::OnClickMatrix()
{
}


void CChildView::OnExpression()
{
	// TODO: добавьте свой код обработчика команд
	isClicked["Выражения"] = !isClicked["Выражения"];
	hideOther("Выражения");
	this->RedrawWindow();
}


void CChildView::OnVect()
{
	// TODO: добавьте свой код обработчика команд
	isClicked["Векторное умножение"] = !isClicked["Векторное умножение"];
	hideOther("Векторное умножение");
	this->RedrawWindow();
}


void CChildView::OnScalar()
{
	// TODO: добавьте свой код обработчика команд
	isClicked["Скалярное произведение"] = !isClicked["Скалярное произведение"];
	hideOther("Скалярное произведение");
	this->RedrawWindow();
}


void CChildView::OnCos()
{
	// TODO: добавьте свой код обработчика команд
	isClicked["Косинус"] = !isClicked["Косинус"];
	hideOther("Косинус");
	this->RedrawWindow();
}


void CChildView::OnSphere()
{
	// TODO: добавьте свой код обработчика команд
	isClicked["Сферические"] = !isClicked["Сферические"];
	hideOther("Сферические");
	this->RedrawWindow();
}


void CChildView::OnMod()
{
	// TODO: добавьте свой код обработчика команд
	isClicked["Модуль"] = !isClicked["Модуль"];
	hideOther("Модуль");
	this->RedrawWindow();
}

void CChildView::hideOther(string text)
{
	for (auto& el : isClicked)
	{
		if (el.first != text)
		{
			el.second = false;
		}
	}
}
