using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_DataBinding_MVVM_Demo.Model;
using UWP_DataBinding_MVVM_Demo.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_DataBinding_MVVM_Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private EmployeeViewModel employeeViewModel;
        public MainPage()
        {
           this.InitializeComponent();
           employeeViewModel = new EmployeeViewModel();
            this.DataContext = employeeViewModel.Employees;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            errorBlock.Text= employeeViewModel.AddEmployee(NameBox.Text, SalaryBox.Text, (string)title.SelectedValue);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selected = myListView.SelectedItems;

            foreach(Employee emp in selected)
            {
                employeeViewModel.RemoveEmployee(emp);
            }
           
        }

        private void increaseSalary_Click(object sender, RoutedEventArgs e)
        {
            var selected = myListView.SelectedItems;

            foreach (Employee emp in selected)
            {
                employeeViewModel.IncreaseSalary(emp);
            }

        }
    }
}
