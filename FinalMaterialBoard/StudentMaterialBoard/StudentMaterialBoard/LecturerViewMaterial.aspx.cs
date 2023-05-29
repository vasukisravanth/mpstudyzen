using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace StudentMaterialBoard
{
    public partial class LecturerViewMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataList1.DataSource = obj.GetMaterial();
                DataList1.DataBind();

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string res = obj.MaterialRating(Session["UserId"].ToString(), int.Parse(Session["MMId"].ToString()), Session["UserType"].ToString(), txtRate.Text);
            if (res == "1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Document Rated Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == "2")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Document Rated Already!!...";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }

        }

        protected void lnkRate_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Session["MMId"] = lnk.CommandArgument;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            LinkButton lnk = (LinkButton)sender;
            int MMId = int.Parse(lnk.CommandArgument.Split(',')[1]);
            string res = obj.UpdateMVCount(MMId);
            string strURL = lnk.CommandArgument.Split(',')[0];
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(strURL));
            Response.WriteFile(strURL);
            Response.End();
        }

        protected void lnkSpam_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            LinkButton lnk = (LinkButton)sender;
            int MMId = int.Parse(lnk.CommandArgument);
            string res = obj.UpdateMSpamCount(MMId, Session["UserId"].ToString());
            if (res == "1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Reported to Spam Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (res == "2")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Reported to Spam Already!!...";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void lnkDiscussion_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int MMId = int.Parse(lnk.CommandArgument);
            Response.Redirect("MaterialQuery_L.aspx?MMId=" + MMId);
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("Rate"))
            {
                LinkButton LinkButton1 = (LinkButton)e.Item.FindControl("lnkSpam");
                LinkButton1.Enabled = true;
            }
        }
    }
}