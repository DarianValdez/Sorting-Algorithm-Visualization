// This is the main DLL file.

#include "stdafx.h"
#include <string.h>
#include "SortingAlgorithms.h"

using namespace std;

namespace SortingAlgorithms
{
	public ref class algorithm
	{
	public:
		event System::EventHandler^ ElementsSwapped;
		event System::EventHandler^ SortFinished;
		int selected;
		int compared;
		String ^ O;
		String ^ Desc;

		algorithm()
		{
			
		}

		void swap(array<int>^ dat, int a, int b)
		{
			selected = dat[a];
			compared = dat[b];
			int i = dat[a];
			dat[a] = dat[b];
			dat[b] = i;

			System::Threading::Thread::Sleep(1);

			ElementsSwapped(this, gcnew EventArgs());
		}
	};

	public ref class selectionSort: public algorithm
	{
	public:
		selectionSort()
		{
			O = gcnew String("Complexity: O(n^2)");
			Desc = gcnew String("Description:\nSelects the largest element in the non-sorted elements, and swaps it with the highest index + 1 of sorted elements.");
		}

		void sort(array<int>^ dat, int n)
		{
			int i, j, min;
			for (i = 0; i < n - 1; i++) //Iterate over every value
			{
				min = i;
				for (j = i; j < n; j++)
				{
					if (dat[j] < dat[min])	min = j; //if any value is less than min, set new min
				}

				if (min != i)	swap(dat, i, min); //swap min and current value
			}
			SortFinished(this, gcnew EventArgs());
		}
	};

	public ref class quickSort : public algorithm
	{
	public:
		quickSort()
		{
			O = gcnew String("Complexity: O(n * log(n))");
			Desc = gcnew String("Description:\nPartitions the data over a pivot value, then QuickSorts all data above and below the pivot, recursively.");
		}

		void sort(array<int>^ dat, const int min, const int max, const int n)
		{
			int mid, pivot, part, i, j;

			//base case
			if (min >= max) return;

			mid = min + (max - min) / 2; //get midpoint of current section
			pivot = dat[mid];	//set pivot to middle value

			swap(dat, mid, min); //swap mid to the left edge

			i = min + 1;
			j = max;

			//partition the data so all less than pivot are on left, and greater than on right
			while (i <= j) 
			{
				while (i <= j && dat[i] <= pivot) i++;
				while (i <= j && dat[j] > pivot) j--;

				if (i < j) swap(dat, i, j);
			}
			swap(dat, i - 1, min);
			part = i - 1;

			//recurse for < partition and > partition
			sort(dat, min, part - 1, n);
			sort(dat, part + 1, max, n);
			if (min == 0 && max == n -1)
			{
				SortFinished(this, gcnew EventArgs());
			}
		}
	};

	public ref class bubbleSort : public algorithm
	{
	public:
		bubbleSort()
		{
			O = gcnew String("Complexity: O(n^2)");
			Desc = gcnew String("Description:\nCompares adjascent elements and swaps them if data[i] > data[i+1]. Iterates over all unsorted values only. Ignores maximum bubble.");
		}

		void sort(array<int>^ dat, int n)
		{
			int i, newn;
			while (n) //while maximum value to sort is not 0;
			{
				newn = 0;
				for (i = 0; i < n-1; i++)
				{
					if (dat[i] > dat[i + 1]) //compare
					{
						swap(dat, i, i+1); //swap if out of order
						newn = i + 1; //set new n
					}
				}
				n = newn;
			}
			SortFinished(this, gcnew EventArgs());
		}
	};

	public ref class heapSort: public algorithm
	{
	public:
		heapSort()
		{
			O = gcnew String("Complexity: O(n * log(n))");
			Desc = gcnew String("Description:\nSimilar to Selection Sort. Uses the Heap data tree to organize the unsorted region, improving access time.");
		}

		void sort(array<int>^ dat, int n)
		{
			int i;
			makeHeap(dat, n); //Make initial heap

			for (i = n-1; i; i--)
			{
				swap(dat, 0, i); //move i to the top
				heapify(dat, 0, i); //fix the heap
			}
			SortFinished(this, gcnew EventArgs());
		}

		void makeHeap(array<int>^ dat, int n)
		{
			int i;
			for (i = (n / 2); i>=0; i--)
			{
				heapify(dat, i, n);
			}
		}

		void heapify(array<int>^ dat, int i, int n)
		{
			int left = 2*i;
			int right = (2*i) + 1;
			int max;

			if (left < n && dat[left] > dat[i]) max = left; //set max
			else max = i;

			if (right < n && dat[right] > dat[max]) max = right; //set max

			if (max != i)
			{
				swap(dat, i, max); //move i
				heapify(dat, max, n); //recurse
			}

		}
	};

	public ref class shakeSort : public algorithm
	{
	public:
		shakeSort()
		{
			O = gcnew String("Complexity: O(n^2)");
			Desc = gcnew String("Description:\nA combination of Selection Sort and Cocktail Sort. In essence a bi-directional selection sort.");
		}

		void sort(array<int>^ dat, int n)
		{
			int i, j, min, max;
			for (i = 0; i < n/2; i++)
			{
				min = i;
				max = i;

				//Selection sort upwards
				for (j = i; j < n; j++)
				{
					if (dat[j] < dat[min])	min = j;
				}
				if (min != i)	swap(dat, i, min); //swap to bottom

				//Selection sort downwards
				for (j = (n-1) - i; j >= i; j--)
				{
					if (dat[j] > dat[max])	max = j;
				}
				if (max != i)	swap(dat, (n-1) - i, max); //swap to top
			}
			SortFinished(this, gcnew EventArgs());
		}
	};

	public ref class cocktailSort : public algorithm
	{
	public:
		cocktailSort()
		{
			O = gcnew String("Complexity: O(n^2)");
			Desc = gcnew String("Description:\nBi-directional Bubble Sort. Treats the maximum and minimum bubbles equally, instead of ignoring the maximum bubble.");
		}

		void sort(array<int>^ dat, int n)
		{
			int i, j, newnH, newnL, nH, nL;
			nH = n; //high n
			nL = 0; //low n

			for (i = 0; i < n / 2; i++)
			{
				newnH = 0;
				//Bubble sort upwards (low values bubble down)
				for (j = 0; j < nH-1; j++)
				{
					if (dat[j] > dat[j + 1]) //compare
					{
						swap(dat, j, j + 1); //swap if out of order
						newnH = j + 1; //set new high n
					}
				}
				nH = newnH;
				newnL = newnH;

				//Bubble sort downwards (high values bubble up)
				for (j; j > nL; j--)
				{
					if (dat[j] < dat[j - 1]) //compare
					{
						swap(dat, j, j - 1); //swap if out of order
						newnL = j - 1; //set nes low n
					}
				}

				nL = newnL;
			}

			SortFinished(this, gcnew EventArgs());
		}
	};

	public ref class shellSort : public algorithm
	{
	public:
		shellSort()
		{
			O = "O(n^2), Depends on gap sequence";
			Desc = "Description:\nA generalized sort by exchane, it uses a sequence of numbers (gap sequence) in order to determine how to sort.";
		}

		void sort(array<int>^ dat, int n)
		{
			int i, j, k;
			for (i = n / 2; i > 0; i = i / 2)
			{
				for (j = i; j < n; j++)
				{
					for (k = j - i; k >= 0; k = k - i)
					{
						if (dat[k + i] >= dat[k])
							break;
						else
						{
							swap(dat, k, k + i);
						}
					}
				}
			}
			SortFinished(this, gcnew EventArgs());
		}
	};
}