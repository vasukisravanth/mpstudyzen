using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentMaterialBoard
{
    public partial class AddSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string result = obj.AddSubject(Session["UserId"].ToString(), txtName.Text, ddlSem.SelectedItem.Text);
            if (result == "1")
            {
                ddlSem.SelectedIndex = 0;
                txtName.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Subject Added Successfully";
            }
            else if (result == "2")
            {
                ddlSem.SelectedIndex = 0;
                txtName.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Subject Added Already";
            }
        }
    }
}