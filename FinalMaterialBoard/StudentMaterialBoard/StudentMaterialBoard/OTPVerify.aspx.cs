using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentMaterialBoard
{
    public partial class OTPVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerifyEmail_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text == Session["OTP"].ToString())
            {
                MyConnection obj = new MyConnection();
                string EncryptData = AESCryptoClass.EncryptData(Session["Password"].ToString(), "1234");
                string result = obj.LectureRegister(int.Parse(Session["DeptId"].ToString()), Session["LName"].ToString(), EncryptData, Session["Email"].ToString());
                if (result == "1")
                {
                    txtOTP.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Lecture Registration Successfully,Department Admin Need To Approve";
                }
                else 
                {
                   
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Registration Error";
                }
            }
            else
            {
                lblMsg.Text = "Invalid OTP";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}