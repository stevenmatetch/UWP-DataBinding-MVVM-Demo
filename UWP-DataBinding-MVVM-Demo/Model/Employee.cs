using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_DataBinding_MVVM_Demo.Model
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private double salary;
        private string title;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                NotifyPropertyChanged("Name");
            }
        }                
        public double Salary
        {
            get { return salary; }
            set { 
                salary = value;
                NotifyPropertyChanged("Salary");
                }
        }
       public string Title
        {
            get { return title; }
            set { title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public string Summary
        {
            get { return Name + " Job Title: " + Title + " Salary: " + Salary; }
           

        }
        public Employee(string name, double salary, string title)
        {
            Name = name;
            Salary = salary;
            Title = title;
        }
        public Employee(){ }
    }
}
