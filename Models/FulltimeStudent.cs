using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_Registration_App.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours;
        public static string Type = "Full Time";
        public FulltimeStudent(string name)
            : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int hours = 0;
            int courses = 0;


            foreach (Course course in selectedCourses)
            {
                hours += course.WeeklyHours;
                courses += 1;

            }
            if (hours <= MaxWeeklyHours)
            {
                base.TotalCourses = courses;
                base.TotalWeeklyHours = hours;
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new Exception("Your selection exceeds the maximum weekly hours: " + MaxWeeklyHours);
            }
        }
        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Id, Name, Type);
        }

    }
}