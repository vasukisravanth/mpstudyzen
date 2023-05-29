using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudentMaterialBoard
{
    public partial class LectureRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetDepartment();
                ddlDept.DataSource = tab;
                ddlDept.DataTextField = "DeptName";
                ddlDept.DataValueField = "DeptId";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, "--Select--");
            }
        }

        protected void btnVerifyEmail_Click(object sender, EventArgs e)
        {
            Random rnd=new Random();
            string OTP=rnd.Next(1000,9999).ToString();
            string Password = rnd.Next(1000, 9999).ToString();
            Session["DeptId"] = ddlDept.SelectedItem.Value;
            Session["LName"] = txtName.Text;
            Session["OTP"] = OTP;
            Session["Email"]=txtEmailId.Text;
            SendEmail.Send(txtEmailId.Text, "Password:" + Password + " & OTP:" + OTP);
            Response.Redirect("OTPVerify.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}