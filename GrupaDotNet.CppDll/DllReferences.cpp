#include "DllReferences.h"

int sum_r(int* tab, int tab_count)
{
	auto sum = 0;
	for (size_t i = 0; i < tab_count;i++)
	{
		sum += tab[i];
	}
	return sum;
}
