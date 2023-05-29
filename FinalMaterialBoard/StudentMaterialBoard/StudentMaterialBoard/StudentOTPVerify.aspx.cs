using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentMaterialBoard
{
    public partial class StudentOTPVerify : System.Web.UI.Page
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
                string result = obj.StudentRegister(Session["USN"].ToString(), Session["SName"].ToString(), EncryptData, Session["Email"].ToString());
                if (result == "1")
                {
                    txtOTP.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Student Registration Successfully";
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