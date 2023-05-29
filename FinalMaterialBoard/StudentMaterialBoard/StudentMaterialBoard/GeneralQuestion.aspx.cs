using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudentMaterialBoard
{
    public partial class GeneralQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetGeneralQuestion();
                if (tab.Rows.Count > 0)
                {
                    DataList1.DataSource = tab;
                    DataList1.DataBind();
                    Panel1.Visible = false;
                }
            }
        }
        protected void btnPostQuery_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string res = obj.PostGeneralQuestion(Session["UserId"].ToString(), Session["UserType"].ToString(), txtQuery.Text);
            if (res == "1")
            {
                txtQuery.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "General Question Posted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "General Question Posted Error!!...";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
        protected void lnkViewReply_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            LinkButton lnk = (LinkButton)sender;
            DataTable tab = new DataTable();
            tab = obj.GetGQReply(int.Parse(lnk.CommandArgument));
            if (tab.Rows.Count > 0)
            {
                Panel1.Visible = true;
                DataList2.DataSource = tab;
                DataList2.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "No Reply for Material Query!!...";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkPostReply_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Session["GQId"] = lnk.CommandArgument;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PostPopup();", true);
        }

        protected void btnPostReply_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string res = obj.GQReply(int.Parse(Session["GQId"].ToString()), Session["UserId"].ToString(), Session["UserType"].ToString(), txtReply.Text);
            if (res == "1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "General Question Reply Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Response.Redirect("ElevatedQuery.aspx");
            }
        }
    }
}