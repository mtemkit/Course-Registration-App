using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_Registration_App.Models
{
    public class Course
    {
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        public Course(string code, string title, int weeklyHours)
        {
            Code = code;
            Title = title;
            WeeklyHours = weeklyHours;
        }
    }
}