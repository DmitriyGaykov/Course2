#include "pch.h"
#include "LibChart2D.h"

CMatrix CreateTranslate2D(double dx, double dy)
{
	CMatrix matrix(3, 3);

	matrix = InitMatrix(
		1, 0, dx,
		0, 1, dy,
		0, 0, 1
	);

	return matrix;
}

CMatrix CreateRotate2D(double fi) 
{
	CMatrix matrix;

	double rad = fi * _PI / 180;

	double cosFI = cos(rad);
	double sinFI = sin(rad);

	matrix = InitMatrix(
		cosFI,	sinFI,	0,
		-sinFI,	cosFI,	0,
		0,		0,		1
	);

	return matrix;
}