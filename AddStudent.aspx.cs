using Course_Registration_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Registration_App
{
    public partial class AddStudent : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void add_Click(object sender, System.EventArgs e)
		{

			if ((txtStudentName.Text == "" && drpStudent.SelectedValue.ToString() == "-1" && Session["var"] == null) || (txtStudentName.Text == "" && Session["var"] == null))
			{

				TableRow rowNew = new TableRow();
				tblStudents.Rows.Add(rowNew);

				TableCell cell = new TableCell();
				rowNew.Cells.Add(cell);

				cell = new TableCell();
				rowNew.Cells.Add(cell);
				cell.Text = "No Student Yet!";
				cell.ForeColor = System.Drawing.Color.Red;

			}
			else if (drpStudent.SelectedValue.ToString() == "-1" && Session["var"] == null)
			{
				TableRow rowNew = new TableRow();
				tblStudents.Rows.Add(rowNew);

				TableCell cell = new TableCell();
				rowNew.Cells.Add(cell);

				cell = new TableCell();
				rowNew.Cells.Add(cell);
				cell.Text = "No Student Type Yet!";
				cell.ForeColor = System.Drawing.Color.Red;
			}
			else if ((txtStudentName.Text == "" && drpStudent.SelectedValue.ToString() == "-1") || (txtStudentName.Text == "") || (drpStudent.SelectedValue.ToString() == "-1"))
			{
				List<Student> lst = new List<Student>();
				lst = (List<Student>)Session["var"];

				foreach (Student s in lst)
				{
					TableRow rowNew = new TableRow();
					tblStudents.Rows.Add(rowNew);

					TableCell cell = new TableCell();
					rowNew.Cells.Add(cell);
					cell.Text = s.Id.ToString();

					cell = new TableCell();
					rowNew.Cells.Add(cell);
					cell.Text = s.Name;

					cell = new TableCell();
					rowNew.Cells.Add(cell);
					cell.Text = s.GetType().ToString();
					cell.Text = cell.Text.Remove(0, 13);
				}
			}
			else
			{

				List<Student> lst = new List<Student>();
				if (Session["var"] == null)
				{
					Session["var"] = lst;

					if (drpStudent.SelectedValue.ToString() == "0")
					{
						lst.Add(new FulltimeStudent(txtStudentName.Text));
					}
					else if (drpStudent.SelectedValue.ToString() == "1")
					{
						lst.Add(new ParttimeStudent(txtStudentName.Text));
					}
					else if (drpStudent.SelectedValue.ToString() == "2")
					{
						lst.Add(new CoopStudent(txtStudentName.Text));
					}

					foreach (Student s in lst)
					{
						TableRow rowNew = new TableRow();
						tblStudents.Rows.Add(rowNew);

						TableCell cell = new TableCell();
						rowNew.Cells.Add(cell);
						cell.Text = s.Id.ToString();

						cell = new TableCell();
						rowNew.Cells.Add(cell);
						cell.Text = s.Name;
						cell.ForeColor = System.Drawing.Color.Empty;

						cell = new TableCell();
						rowNew.Cells.Add(cell);
						cell.Text = s.GetType().ToString();
						cell.Text = cell.Text.Remove(0, 13);
					}

				}
				else
				{
					lst = (List<Student>)Session["var"];

					if (drpStudent.SelectedValue.ToString() == "0")
					{
						lst.Add(new FulltimeStudent(txtStudentName.Text));
					}
					else if (drpStudent.SelectedValue.ToString() == "1")
					{
						lst.Add(new ParttimeStudent(txtStudentName.Text));
					}
					else if (drpStudent.SelectedValue.ToString() == "2")
					{
						lst.Add(new CoopStudent(txtStudentName.Text));
					}

					Session["var"] = lst;			
					foreach (Student s in lst) 
					{
						TableRow rowNew = new TableRow();
						tblStudents.Rows.Add(rowNew);

						TableCell cell = new TableCell();
						rowNew.Cells.Add(cell);
						cell.Text = s.Id.ToString();

						cell = new TableCell();
						rowNew.Cells.Add(cell);
						cell.Text = s.Name;

						cell = new TableCell();
						rowNew.Cells.Add(cell);
						cell.Text = s.GetType().ToString();
						cell.Text = cell.Text.Remove(0, 13);
					}
				}
			}
			pnlResult.Visible = true;
			txtStudentName.Text = "";
			drpStudent.SelectedValue = "-1";
		}
	}

}