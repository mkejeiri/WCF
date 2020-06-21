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
            EmployeeService.IEmployeeService client = new EmployeeService.EmployeeServiceClient();

            EmployeeService.EmployeeRequest request = new EmployeeService.EmployeeRequest("sqfqsfsqdf", Convert.ToInt32(txtID.Text));

            EmployeeService.EmployeeInfo employeeInfo = client.GetEmployeeInfo(request);
            txtName.Text = employeeInfo.Name;
            txtGender.Text = employeeInfo.Gender;
            txtDateOfBirth.Text = employeeInfo.DOB.ToShortDateString();

            if (employeeInfo.Type == EmployeeService.EmployeeType.FullTimeEmployee)
            {
                txtAnnualSalary.Text = employeeInfo.AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text =employeeInfo.HourlyPay.ToString();
                txtHoursWorked.Text = employeeInfo.HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
            ddlEmployeeType.SelectedValue = ((int)employeeInfo.Type).ToString();
            lblMessage.Text = "Employee retrieved";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EmployeeService.EmployeeInfo employeeInfo = null;
            EmployeeService.IEmployeeService client = new EmployeeService.EmployeeServiceClient();


            if (ddlEmployeeType.SelectedValue=="-1")
            {
                lblMessage.Text = "Please select Employee Type";
                return;
            }


            employeeInfo = new EmployeeService.EmployeeInfo()
            {
                Id = Convert.ToInt32(txtID.Text),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DOB = Convert.ToDateTime(txtDateOfBirth.Text),
                Type = EmployeeService.EmployeeType.FullTimeEmployee
            };



            if (((EmployeeService.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue)) == EmployeeService.EmployeeType.FullTimeEmployee)
            {
                employeeInfo.AnnualSalary = Convert.ToInt32(txtAnnualSalary.Text);
               
                
            }
            else if (((EmployeeService.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue)) == EmployeeService.EmployeeType.PartTimeEmployee)
            {

                employeeInfo.HourlyPay = Convert.ToInt32(txtHourlyPay.Text);
                employeeInfo.HoursWorked = Convert.ToInt32(txtHoursWorked.Text);
                
            }
             client.SaveEmployee(employeeInfo);
            lblMessage.Text = "Employee saved";

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