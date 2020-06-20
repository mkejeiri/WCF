using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeServiceRef.EmployeeServiceClient client = new EmployeeServiceRef.EmployeeServiceClient();
            EmployeeServiceRef.Employee employee = client.GetEmployee(Convert.ToInt32(txtID.Text));
            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();

            if (employee.Type == EmployeeServiceRef.EmployeeType.FullTimeEmployee)
            {
                txtAnnualSalary.Text = ((EmployeeServiceRef.FullTimeEmployee)employee).AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text = ((EmployeeServiceRef.PartTimeEmployee)employee).HourlyPay.ToString();
                txtHoursWorked.Text =
                    ((EmployeeServiceRef.PartTimeEmployee)employee).HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
            ddlEmployeeType.SelectedValue = ((int)employee.Type).ToString();

            lblMessage.Text = "Employee retrieved";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EmployeeServiceRef.Employee employee = null;
            EmployeeServiceRef.EmployeeServiceClient client = new EmployeeServiceRef.EmployeeServiceClient();

            if (((EmployeeServiceRef.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue)) == EmployeeServiceRef.EmployeeType.FullTimeEmployee)
            {
                employee = new EmployeeServiceRef.FullTimeEmployee
                {
                    ID = Convert.ToInt32(txtID.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                    Type = EmployeeServiceRef.EmployeeType.FullTimeEmployee,
                    AnnualSalary = Convert.ToInt32(txtAnnualSalary.Text),
                };
                client.SaveEmployee(employee);
                lblMessage.Text = "Full time Employee saved";
            }
            else if (((EmployeeServiceRef.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue)) == EmployeeServiceRef.EmployeeType.PartTimeEmployee)
            {
                employee = new EmployeeServiceRef.PartTimeEmployee
                {
                    ID = Convert.ToInt32(txtID.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                    Type = EmployeeServiceRef.EmployeeType.PartTimeEmployee,
                    HourlyPay = Convert.ToInt32(txtHourlyPay.Text),
                    HoursWorked = Convert.ToInt32(txtHoursWorked.Text),
                };
                client.SaveEmployee(employee);
                lblMessage.Text = "Part time Employee saved";
            }
            else
            {
                lblMessage.Text = "Please select Employee Type";
            }



        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeType.SelectedValue == "-1")
            {
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (ddlEmployeeType.SelectedValue == "1")
            {
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
        }
    }
}