using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_DataBinding_MVVM_Demo.Model;

namespace UWP_DataBinding_MVVM_Demo.ViewModel
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        private Employee myEmployee;
        public event PropertyChangedEventHandler PropertyChanged;
        public Employee MyEmployee
        {
            get { return myEmployee; }
            set
            {
                myEmployee = value;
                NotifyPropertyChanged("MyEmployee");
            }
        }
        public ObservableCollection<Employee> Employees { get; set; }
        public List<string> Titles { get; set; }
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public EmployeeViewModel()
        {
            MyEmployee = new Employee("Kalle Anka", 25000, "Sales Representant");

            Employees = new ObservableCollection<Employee>();
            Titles = new List<string>
            {
                "Sales Representant","Manager","Administrator", "Consultant"
            };
        }

        internal string AddEmployee(string text1, string text2, string selectedValue)
        {
            double salary;

            try
            {
               salary = double.Parse(text2);
            }
            catch (Exception e)
            {
                return "invalid input!";
            }

            Employee employee = new Employee(text1, salary, selectedValue);
            Employees.Add(employee);
            return "Employee has been added!";

        }

        internal void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        internal void ChangeloginName()
        {
            MyEmployee.Name = "Nicke Nyfiken";
        }
        internal void IncreaseSalary(Employee emp)
        {
            for(int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Name.Equals(emp.Name))
                {
                    Employees[i].Salary += 1000;
                }
            }

        }
    }
}
