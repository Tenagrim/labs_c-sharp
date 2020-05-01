using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8_2
{
    [Serializable]
    class Person
    {
        protected string name;
        protected int age;
       /// [NonSerialized]
        DateTime date;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { if (value > 0 && value < 99) age = value; else age = 0; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = DateTime.Now; }
        }
        public Person()
        {
            Name = ""; Age = 0; Date = DateTime.Now;
        }
        public Person(string N, int A)
        {
            Name = N; Age = A; date = DateTime.Now;
        }
    }
    [Serializable]
    class Student : Person
    {
        protected int year;
        protected double rating;
        public int Year 
        {
            get { return year; }
            set { if (value > 0 && value < 6) year = value; else year = 0; }
        }
        public double Rating 
        {
            get { return rating; }
            set { rating = value; }
        }
    }

    class Group 
    {
        protected string name;
        protected int fileIndex;
        protected int year;
        protected int studentsCount;

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public int FileIndex 
        {
            get { return fileIndex; }
        }
        public int Year
        {
            get { return year; }
        }
        public List<Student> students;

       public Group(string N, int I, int Y) 
        {
            name = N; fileIndex = I;
            year = Y;
            students = new List<Student>();
            studentsCount = 0;
        }
        public void AddStudent(Student st) 
        {
            students.Add(st);
            studentsCount++;
        }
        public void DelStudent(int ind) 
        {
            students.RemoveAt(ind);
            studentsCount--;
        }
        public void Count() 
        {
            studentsCount = students.Count;
        }
        public void ChangeYear(int Y) 
        {
            year = Y;
            for (int i = 0; i < students.Count; i++)
            {
                students[i].Year = Y;
            }
        }
        public void pressF() 
        {
            fileIndex--;
        }
    }
}
