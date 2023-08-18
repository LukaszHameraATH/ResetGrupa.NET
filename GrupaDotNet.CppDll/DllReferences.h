#pragma once

#define DLLEXPORT __declspec(dllimport)

extern "C"
{
	int DLLEXPORT sum_r(int* tab, int tab_count);
}