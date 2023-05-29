using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace StudentMaterialBoard
{
    public partial class ElevatedQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetMaterialQuery();
                if (tab.Rows.Count > 0)
                {
                    //for (int i = 0; i < tab.Rows.Count; i++)
                    //{
                    //    DateTime now = DateTime.Now;
                    //    if (DateTime.Parse(tab.Rows[i]["PostDate"].ToString()) < now.AddHours(-24) && DateTime.Parse(tab.Rows[i]["PostDate"].ToString()) <= now)
                    //    {
                    //        string DatePost = tab.Rows[i]["PostDate"].ToString();
                    //    }

                    //    DateTime yesterday = now.AddDays(-1);
                    //    if (DateTime.Parse(tab.Rows[i]["PostDate"].ToString()) < yesterday && DateTime.Parse(tab.Rows[i]["PostDate"].ToString()) <= now)
                    //    {
                    //        string DatePost = tab.Rows[i]["PostDate"].ToString();
                    //    }
                    //}

                    DataList1.DataSource = tab;
                    DataList1.DataBind();
                }
                

            }
        }

        protected void lnkReply_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Session["MQId"] = lnk.CommandArgument;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }
        static string filename;
        protected void btnSave_Click(object sender, EventArgs e)
        {
             string filepath="";
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
                Response.Redirect("ElevatedQuery.aspx");
            }
        }
    }
}