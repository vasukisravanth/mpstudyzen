using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace StudentMaterialBoard
{
    public partial class MaterialQuery_L : System.Web.UI.Page
    {
        static string MMId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MMId"] != null)
                {
                    MMId = Request.QueryString["MMId"].ToString();
                    MyConnection obj = new MyConnection();
                    DataList1.DataSource = obj.GetMaterialQuery(int.Parse(MMId));
                    DataList1.DataBind();
                    Panel1.Visible = false;

                }
                else
                    MMId = "0";


            }
        }
        protected void btnPostQuery_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            string res = obj.PostMaterialQuery(int.Parse(MMId), Session["UserId"].ToString(), Session["UserType"].ToString(), txtQuery.Text);
            if (res == "1")
            {
                txtQuery.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Query Posted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Query Posted Error!!...";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void lnkViewReply_Click(object sender, EventArgs e)
        {

            MyConnection obj = new MyConnection();
            LinkButton lnk = (LinkButton)sender;
            DataTable tab = new DataTable();
            tab = obj.GetMaterialReplyQuery(int.Parse(lnk.CommandArgument));
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
            Session["MQId"] = lnk.CommandArgument;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PostPopup();", true);
        }
        static string filename;
        protected void btnPostReply_Click(object sender, EventArgs e)
        {
            string filepath = "";
            if (MaterialFile.HasFile)
            {
                Random rnd = new Random();
                filename = Session["MQId"].ToString() + "_" + rnd.Next(1000, 9999) + Path.GetExtension(MaterialFile.FileName);
                filepath = "~/MaterialFiles/" + filename;
                MaterialFile.SaveAs(Server.MapPath(filepath));
            }

            MyConnection obj = new MyConnection();
            string res = obj.MaterialReply(int.Parse(Session["MQId"].ToString()), Session["UserId"].ToString(), Session["UserType"].ToString(), txtReply.Text, filepath);
            if (res == "1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMsg();", true);
                lblMsg.Text = "Material Reply Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Response.Redirect("ElevatedQuery.aspx");
            }
        }
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            LinkButton lnk = (LinkButton)sender;
            //int MMId = int.Parse(lnk.CommandArgument.Split(',')[1]);
            //string res = obj.UpdateMVCount(MMId);
            string strURL = lnk.CommandArgument.Split(',')[0];
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(strURL));
            Response.WriteFile(strURL);
            Response.End();
        }
    }
}