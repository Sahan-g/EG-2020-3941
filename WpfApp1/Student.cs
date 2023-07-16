using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        
        public DateTime Birthday { get; set; }

        public double GPA { get; set; }
        
        public string BirthdayString { get; set; }



        public BitmapImage Image { get; set; }

        public String ImagePath
        {
            get { return $"/Icons/{Image}"; }
        }

        public Student(string firstName, string lastName,DateTime birthday, double gPA,BitmapImage img)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            Age = DateTime.Now.Year - birthday.Year;
            Birthday = birthday;
            GPA = gPA;
            Image = img;
            BirthdayString=birthday.Year.ToString()+"/"+birthday.Month.ToString()+"/"+birthday.Day.ToString();
        }

        public void  SetBdayString()
        {
            BirthdayString = Birthday.Year.ToString() + "/" + Birthday.Month.ToString() + "/" + Birthday.Day.ToString();
        }

        public Student()
        {
            FirstName = "";
            LastName = "";
            Age = 0;
            Birthday = DateTime.Now;
            GPA= 0;
            Image = null;

        }

    }
}
