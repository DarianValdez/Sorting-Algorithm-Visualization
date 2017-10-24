using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FinalProject.Models
{
    class LineModel : INotifyPropertyChanged
    {
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public int Tag { get; set; }

        private Point _from = new Point(0, 0);
        public Point From
        {
            get { return _from; }
            set
            {
                _from = value;
                NotifyPropertyChanged(nameof(From));
            }
        }

        private Point _to = new Point(0, 0);
        public Point To
        {
            get { return _to; }
            set
            {
                _to = value;
                NotifyPropertyChanged(nameof(To));
            }
        }

        private Brush _stroke = Brushes.White;
        public Brush Stroke
        {
            get { return _stroke; }
            set
            {
                _stroke = value;
                NotifyPropertyChanged(nameof(Stroke));
            }
        }
        public Double StrokeThickness { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
