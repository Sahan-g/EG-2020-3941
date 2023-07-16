using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;


        [ObservableProperty]
        public Student selectedStudent = null;

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent != null)
            {

                var edit = new EditStudentWindowVM( SelectedStudent);
                var editWindow = new EditStudentWIndow(edit) { DataContext= edit };
                edit.WindowTitle = "Modify Student ";
                editWindow.ShowDialog();

                int update = Students.IndexOf(SelectedStudent);
                Students.Remove(SelectedStudent);
                edit.Student1.SetBdayString();
                Students.Insert(update, edit.Student1);



            }
            else
            {
                MessageBox.Show("You need to select a Student First","  Error  ");
            }
            
        }

        [RelayCommand]
        public void Exit()
        {
            Application.Current.Shutdown();
        }

        [RelayCommand]
        public void DeleteStudent(Student student)
        {
            if (student != null)
            {
                Students.Remove(student);
                return;
            }
           MessageBox.Show("You need to Select a Stduent First", "Error ");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var add = new EditStudentWindowVM();
            var addWindow = new EditStudentWIndow(add) { DataContext = add };
            add.WindowTitle= "Add Student";
            addWindow.ShowDialog();
            Students.Insert(Students.Count, add.Student1);


                }
        

        public MainWindowVM()
        {
            
            students = new ObservableCollection<Student>();
            students.Add(new Student("Tom", "Brown", new DateTime(2000, 7, 31), 3.55, new BitmapImage(new Uri($"/Icons/1.png",UriKind.Relative))));
            students.Add(new Student("Anne", "Black", new DateTime(2002, 3, 12), 3.41, new BitmapImage(new Uri($"/Icons/2.png",UriKind.Relative))));
            students.Add(new Student("Jimmy", "White", new DateTime(2003, 5, 6), 3.0, new BitmapImage(new Uri($"/Icons/3.png", UriKind.Relative))));
            students.Add(new Student("Sam", "Green", new DateTime(2004, 1, 1), 3.41, new BitmapImage(new Uri($"/Icons/4.png", UriKind.Relative))));
            students.Add(new Student("Ann", "Pink", new DateTime(2001, 10, 24), 3.87, new BitmapImage(new Uri($"/Icons/5.png", UriKind.Relative))));
            students.Add(new Student("Tim", "Blue", new DateTime(2004, 1, 3), 2.78, new BitmapImage(new Uri($"/Icons/6.png", UriKind.Relative))));
            students.Add(new Student("Adam", "Blake", new DateTime(2004, 1, 3), 2.78, new BitmapImage(new Uri($"/Icons/7.png", UriKind.Relative))));
        }


    }
}
