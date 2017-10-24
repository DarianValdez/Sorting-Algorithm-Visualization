using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            btnSort.IsEnabled = true;
            boxElements.IsEnabled = true;
            boxAlgorithm.IsEnabled = true;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            btnSort.IsEnabled = false;
            boxElements.IsEnabled = false;
            boxAlgorithm.IsEnabled = false;
        }
    }
}
