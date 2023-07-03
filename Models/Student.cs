using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_Registration_App.Models
{
    public class Student
    {
        public int Id;
        public string Name { get; set; }

        public List<Course> RegisteredCourses;
        public int TotalWeeklyHours;
        public int TotalCourses;
        public Student(string name)
        {
            this.Name = name;
            Random rand = new Random();
            this.Id = rand.Next(9000000, 9999999);
            RegisteredCourses = new List<Course>();
            TotalWeeklyHours = 0;
            TotalCourses = 0;
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();

            foreach (Course course in selectedCourses)
            {
                RegisteredCourses.Add(course);
            }
        }

    }
}