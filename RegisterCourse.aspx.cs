using Course_Registration_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Registration_App
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			List<Student> lst = new List<Student>();
			if (Session["var"]==null)
            {
				Response.Redirect("AddStudent.aspx");
            }
			else
            {
				lst = (List<Student>)Session["var"];
			}
			if (!IsPostBack)
            {
				int val = 0;
				foreach (Student s in lst)
				{
					drpStudent.Items.Add(new ListItem(s.ToString(), val.ToString()));
					val++;
				}
				foreach (Course c in Helper.GetAvailableCourses())
				{
					chklst.Items.Add(new ListItem(" " + c.Title + " - " + c.WeeklyHours + " hours/week", c.Code));
				}
			}
		}

		protected void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			List<Student> lst = new List<Student>();
			lst = (List<Student>)Session["var"];
			List<Course> selectedCourses = new List<Course>();
			bool noBookSelected = true;

			foreach (ListItem lstItem in chklst.Items)
			{
				if (lstItem.Selected == true)
				{
					noBookSelected = false;
					Course selectedCourse = Helper.GetCourseByCode(lstItem.Value);
					selectedCourses.Add(selectedCourse);
				}
			}
			try
			{
				lst[drpStudent.SelectedIndex - 1].RegisterCourses(selectedCourses);
				foreach (ListItem listItem in chklst.Items)
				{
					foreach (Course course in lst[drpStudent.SelectedIndex - 1].RegisteredCourses)
					{
						if (Helper.GetCourseByCode(listItem.Value).Code == course.Code)
						{
							listItem.Selected = true;
							break;
						}
					}
					lblErrorMsg.Visible = false;
					lblCourseHoursRegistered.Text = "Selected student has registered " + lst[int.Parse(drpStudent.SelectedValue)].TotalCourses + " course(s), " + lst[int.Parse(drpStudent.SelectedValue)].TotalWeeklyHours + " hours weekly.";
				}
			}
			catch (Exception exception)
			{
				lblErrorMsg.Visible = true;
				lblErrorMsg.Text = exception.Message;
			}
			if (noBookSelected)
			{
				lblErrorMsg.Visible = true;
				lblErrorMsg.Text = "Please select at least one course!";
			}
		}

		protected void chklst_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void drpSelect(object sender, EventArgs e)
		{
			List<Student> lstSt = (List<Student>)Session["var"];
			chklst.ClearSelection();

			try
			{
				foreach (ListItem listItem in chklst.Items)
				{
					foreach (Course course in lstSt[int.Parse(drpStudent.SelectedValue)].RegisteredCourses)
					{
						if (Helper.GetCourseByCode(listItem.Value).Code == course.Code)
						{
							listItem.Selected = true;
							break;
						}
					}
				}
				lblErrorMsg.Visible = false;
				lblCourseHoursRegistered.Visible = true;
				lblCourseHoursRegistered.Text = "Selected student has registered " + lstSt[int.Parse(drpStudent.SelectedValue)].TotalCourses + " course(s), " + lstSt[int.Parse(drpStudent.SelectedValue)].TotalWeeklyHours + " hours weekly";
			}
			catch (Exception exception)
			{
				lblErrorMsg.Visible = true;
				lblErrorMsg.Text = exception.Message;
			}
			if (drpStudent.SelectedValue == "-1")
			{
				lblErrorMsg.Visible = false;
				lblCourseHoursRegistered.Visible = false;
			}
		}

		protected void rdbStudent_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

	}

}