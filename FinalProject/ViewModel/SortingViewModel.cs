using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Threading;

namespace FinalProject
{
    class SortingViewModel
    {
        Random r = new Random();
        int[] data = new int[1000];
        int swaps = 0;
        Thread T;

        SortingAlgorithms.selectionSort selSort = new SortingAlgorithms.selectionSort();
        SortingAlgorithms.quickSort qSort = new SortingAlgorithms.quickSort();
        SortingAlgorithms.bubbleSort bSort = new SortingAlgorithms.bubbleSort();
        SortingAlgorithms.heapSort hSort = new SortingAlgorithms.heapSort();
        SortingAlgorithms.shakeSort sSort = new SortingAlgorithms.shakeSort();
        SortingAlgorithms.cocktailSort cSort = new SortingAlgorithms.cocktailSort();
        SortingAlgorithms.shellSort shSort = new SortingAlgorithms.shellSort();

        public RelayCommand SortCommand
        {
            get;
            private set;
        }

        public RelayCommand ResetCommand
        {
            get;
            private set;
        }

        #region Bindings

        private ObservableCollection<LineModel> _lines = new ObservableCollection<LineModel>();
        public ObservableCollection<LineModel> Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }

        public class DisplayItem
        {
            public SortingAlgorithms.algorithm Algorithm { get; set; }
            public String DisplayMember { get; set; }
        }

        private ObservableCollection<DisplayItem> _algorithms = new ObservableCollection<DisplayItem>();
        public ObservableCollection<DisplayItem> Algorithms
        {
            get { return _algorithms; }
            set { _algorithms = value; }
        }

        private DisplayItem _selectedAlgorithm;
        public DisplayItem SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                _selectedAlgorithm = value;
                BigO = _selectedAlgorithm.Algorithm.O;
                Description = _selectedAlgorithm.Algorithm.Desc;
            }
        }

        private int[] _elementCounts = { 100, 1000, 10000 };
        public int[] ElementCounts
        {
            get { return _elementCounts; }
            set { _elementCounts = value; }
        }

        private int _numElements = 1000;
        public int NumElements
        {
            get { return _numElements; }
            set
            {
                _numElements = value;
                InitializeLines();
            }
        }

        private string _swaps = "";
        public string Swaps
        {
            get { return _swaps; }
            set { _swaps = value; }
        }

        private string _selected = "";
        public string Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        private string _compared = "";
        public string Compared
        {
            get { return _compared; }
            set { _compared = value; }
        }

        private string _bigO = "";
        public string BigO
        {
            get { return _bigO; }
            set { _bigO = value; }
        }

        private string _description = "";
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Boolean _canReset = false;
        public Boolean CanReset
        {
            get { return _canReset; }
            set{ _canReset = value; }
        }

        #endregion

        public SortingViewModel()
        {
            SortCommand = new RelayCommand(SortThread);
            ResetCommand = new RelayCommand(InitializeLines);

            DisplayItem item = new DisplayItem
            {
                Algorithm = selSort,
                DisplayMember = "Selection Sort"
            };
            Algorithms.Add(item);

            item = new DisplayItem
            {
                Algorithm = qSort,
                DisplayMember = "Quick Sort"
            };
            Algorithms.Add(item);

            item = new DisplayItem
            {
                Algorithm = bSort,
                DisplayMember = "Bubble Sort"
            };
            Algorithms.Add(item);

            item = new DisplayItem
            {
                Algorithm = hSort,
                DisplayMember = "Heap Sort"
            };
            Algorithms.Add(item);

            item = new DisplayItem
            {
                Algorithm = sSort,
                DisplayMember = "Shaker Sort"
            };
            Algorithms.Add(item);

            item = new DisplayItem
            {
                Algorithm = cSort,
                DisplayMember = "Cocktail Sort"
            };
            Algorithms.Add(item);

            item = new DisplayItem
            {
                Algorithm = hSort,
                DisplayMember = "Shell Sort"
            };
            Algorithms.Add(item);

            selSort.ElementsSwapped += algo_ElementsSwapped;
            selSort.SortFinished += algo_SortFinished;

            qSort.ElementsSwapped += algo_ElementsSwapped;
            qSort.SortFinished += algo_SortFinished;

            bSort.ElementsSwapped += algo_ElementsSwapped;
            bSort.SortFinished += algo_SortFinished;

            hSort.ElementsSwapped += algo_ElementsSwapped;
            hSort.SortFinished += algo_SortFinished;

            sSort.ElementsSwapped += algo_ElementsSwapped;
            sSort.SortFinished += algo_SortFinished;

            cSort.ElementsSwapped += algo_ElementsSwapped;
            cSort.SortFinished += algo_SortFinished;

            shSort.ElementsSwapped += algo_ElementsSwapped;
            shSort.SortFinished += algo_SortFinished;

            InitializeLines();
        }

        public void SortThread()
        {
            T = new Thread(new ThreadStart(SortTask));
            T.Start();
        }

        public void SortTask()
        {
            switch (Algorithms.IndexOf(SelectedAlgorithm))
            {
                case 0: //SelectionSort
                    selSort.sort(data, data.Length);
                    break;
                case 1: //QuickSort
                    qSort.sort(data, 0, data.Length - 1, data.Length);
                    break;
                case 2: //BubbleSort
                    bSort.sort(data, data.Length);
                    break;
                case 3: //HeapSort
                    hSort.sort(data, data.Length);
                    break;
                case 4:
                    sSort.sort(data, data.Length);
                    break;
                case 5: //CocktailSort
                    cSort.sort(data, data.Length);
                    break;
                case 6: //Shell Sort
                    shSort.sort(data, data.Length);
                    break;
                default:
                    break;
            }
        }

        public void InitializeLines()
        {
            double width = 1000;
            double height = 411;
            if (T != null && T.IsAlive)
            {
                T.Abort();
            }

            swaps = 0;

            data = new int[NumElements];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            data = data.OrderBy(x => r.Next()).ToArray();

            double lineWidth = ((double)width / (double)data.Length);
            double heightRatio = ((double)height / (double)data.Max());

            Lines.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                LineModel line = new LineModel
                {
                    Tag = data[i],
                    Stroke = Brushes.White,
                    StrokeThickness = lineWidth
                };

                double x = ((double)i * lineWidth) + (lineWidth / 2.0);
                line.From = new Point(x, height);

                double y = height - (double)data[i] * heightRatio;
                line.To = new Point(x, y);

                Lines.Add(line);
            }
        }

        void algo_ElementsSwapped(object sender, EventArgs e)
        {
            SortingAlgorithms.algorithm send = (SortingAlgorithms.algorithm)sender;
            if (send.selected != send.compared)
            {
                swapLines(send.selected, send.compared);
            }
        }

        private void algo_SortFinished(object sender, EventArgs e)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int index = Lines.IndexOf(Lines.FirstOrDefault(l => (int)l.Tag == i));
                Lines[index].Stroke = Brushes.LimeGreen;
            }
        }

        private void swapLines(int sel, int comp)
        {
            int index1 = Lines.IndexOf(Lines.FirstOrDefault(l => (int)l.Tag == sel));
            int index2 = Lines.IndexOf(Lines.FirstOrDefault(l => (int)l.Tag == comp));

            Point temp = Lines[index1].From;
            Lines[index1].From = Lines[index2].From;
            Lines[index2].From = temp;

            temp = Lines[index1].To;
            Point temp2 = Lines[index2].To;

            temp.X = temp2.X;
            temp2.X = Lines[index1].To.X;

            Lines[index1].To = temp;
            Lines[index2].To = temp2;

            swaps++;
            Swaps = "Swaps: " + Convert.ToString(swaps);
            Selected = "Selected: " + Convert.ToString(sel);
            Compared = "Compared: " + Convert.ToString(comp);
        }
    }
}
