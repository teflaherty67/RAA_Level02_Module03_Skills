﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;


namespace RAA_Level02_Module03_Skills
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MyForm : Window
    {
        ObservableCollection<DataClass1> dataList {  get; set; }
        ObservableCollection<string> dataItems { get; set; }
        public MyForm()
        {
            InitializeComponent();

            dataList = new ObservableCollection<DataClass1>();
            dataList.Add(new DataClass1());

            dataItems = new ObservableCollection<string> { "one", "two", "three", "four" };

            grdData.ItemsSource = dataList;
            colItem4.ItemsSource = dataItems;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }

    public class DataClass1
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public bool Item3 { get; set; }
        public string Item4 { get; set; }
    }
}
