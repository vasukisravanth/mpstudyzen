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
    public partial class MaterialUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetSubject();
                ddlSubject.DataSource = tab;
                ddlSubject.DataTextField = "SubjectName";
                ddlSubject.DataValueField = "SubjectId";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(0, "--Select--");
            }
        }

        static string filename;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (MaterialFile.HasFile)
            {
                Random rnd = new Random();
                MyConnection obj = new MyConnection();
                filename = txtName.Text + "_" + rnd.Next(1000, 9999) + Path.GetExtension(MaterialFile.FileName); ;
                string filepath = "~/MaterialFiles/" + filename;
                MaterialFile.SaveAs(Server.MapPath(filepath));

                string res = obj.UploadMaterials(Session["UserId"].ToString(),int.Parse(ddlSubject.SelectedItem.Value),"Student",txtName.Text,txtDescription.Text,filepath);
                if (res == "1")
                {
                    txtName.Text = "";
                    txtDescription.Text = "";
                    ddlSubject.SelectedIndex = 0;
                    lblMsg.Text = "Material Document Uploaded Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtName.Text = "";
                    txtDescription.Text = "";
                    ddlSubject.SelectedIndex = 0;
                    lblMsg.Text = "Material Document Upload Error!!...";
                    lblMsg.ForeColor = System.Drawing.Color.Red;

                }
            }
        }
    }
}