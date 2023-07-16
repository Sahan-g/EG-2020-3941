using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class EditStudentWindowVM:ObservableObject
    {
        [ObservableProperty]
        string firstName;
        [ObservableProperty]
        string lastName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Student1))]
        DateTime dob;
        [ObservableProperty]
        double gpa;
        [ObservableProperty]
        BitmapImage img;
        [ObservableProperty]
        int age;

        [ObservableProperty]
        string windowTitle;


        public Student Student1 { get; private set; }
        public Action CloseAction { get; internal set; }


        [RelayCommand]
        public void Save()  
        {
            if (gpa < 0 || gpa > 4) {

                MessageBox.Show("GPA Value must be Between 0 to 4.0","Error !");
                
            }
            else
            {
                if (windowTitle == "Modify Student ")
                {
                    if (FirstName != "" || FirstName != null)
                    {
                        Student1.FirstName = FirstName;
                        Student1.LastName = LastName;
                        Student1.Age = age;
                        Student1.Birthday = dob;
                        Student1.GPA = Gpa;
                        Student1.Image = img;
                        Student1.SetBdayString();

                        CloseAction();
                    }
                    else
                    {

                        MessageBox.Show("Student must have a First Name : ", "Error ");
                    }
                }
                else
                {
                    if (FirstName != "" && FirstName != null)
                    {


                        Student1.FirstName = FirstName;
                        Student1.LastName = LastName;
                        Student1.Age = age;
                        Student1.Birthday = dob;
                        Student1.GPA = Gpa;
                        Student1.Image = img;
                        Student1.SetBdayString();

                        CloseAction();
                    }
                    else
                    {
                        MessageBox.Show("Sthudent must have a First Name", "Error ");
                    }
                }

            }
        }

        [RelayCommand]
        public void UploadImage()
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter= "Image files | *.bmp; *.png; *.jpg";
            img.FilterIndex = 1;
            if (img.ShowDialog() == true)
            {
                Img= new BitmapImage( new Uri(img.FileName));
                return;
            }


        }


        public EditStudentWindowVM( Student  stu)
        {
            Student1 = stu;

            firstName= stu.FirstName;
            lastName= stu.LastName;
            dob = stu.Birthday;
            gpa = stu.GPA;
            age = stu.Age;
            img = stu.Image;
            stu.SetBdayString();


        }

        public EditStudentWindowVM()
        {
            Student1= new Student();
            Dob = DateTime.Now;

        }


  

    }
}
