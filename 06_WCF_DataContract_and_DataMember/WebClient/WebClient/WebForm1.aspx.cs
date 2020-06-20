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

            lblMessage.Text = "Employee retrieved";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EmployeeServiceRef.Employee employee = new EmployeeServiceRef.Employee();
            employee.Id = Convert.ToInt32(txtID.Text);
            employee.Name = txtName.Text;
            employee.Gender = txtGender.Text;
            employee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

            EmployeeServiceRef.EmployeeServiceClient client = new EmployeeServiceRef.EmployeeServiceClient();
            client.SaveEmployee(employee);
            lblMessage.Text = "Employee saved";
        }
    }
}