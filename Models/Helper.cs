using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_Registration_App.Models
{
    public class Helper
    {
        public static List<Course> GetAvailableCourses()
        {
            List<Course> courses = new List<Course>();

            Course course = new Course("CST8282", "Introduction to Database Systems", 4);
            //course.WeeklyHours = 4;
            courses.Add(course);

            course = new Course("CST8253", "Web Programming II", 2);
            //course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8256", "Web Programming Language I", 5);
            //course.WeeklyHours = 5;
            courses.Add(course);

            course = new Course("CST8255", "Web Imaging and Animations", 2);
            //course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8254", "Network Operating System", 1);
            //course.WeeklyHours = 1;
            courses.Add(course);

            course = new Course("CST2200", "Data Warehouse Design", 3);
            //course.WeeklyHours = 3;
            courses.Add(course);

            course = new Course("CST2240", "Advance Database topics", 1);
            //course.WeeklyHours = 1;
            courses.Add(course);

            return courses;
        }

        public static Course GetCourseByCode(string code)
        {
            foreach (Course c in GetAvailableCourses())
            {
                if (c.Code == code)
                {
                    return c;
                }
            }
            return null;
        }
    }
}