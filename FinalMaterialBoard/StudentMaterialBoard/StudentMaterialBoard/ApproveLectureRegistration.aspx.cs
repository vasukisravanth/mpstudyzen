﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudentMaterialBoard
{
    public partial class ApproveLectureRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = obj.GetLectureRegisterPending(Session["UserId"].ToString());
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();

                    hc1.Text = "Lecture Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Email Id";
                    hr.Cells.Add(hc2);
                    hc3.Text = "";
                    hr.Cells.Add(hc3);


                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["LectureName"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);

                        Label lblEmailId = new Label();
                        lblEmailId.Text = tab.Rows[i]["EmailId"].ToString();
                        TableCell EmailId = new TableCell();
                        EmailId.Controls.Add(lblEmailId);



                        LinkButton Approve = new LinkButton();
                        Approve.Text = "Approve";
                        Approve.ID = "lnkApprove" + i.ToString();
                        Approve.CommandArgument = tab.Rows[i]["LectureId"].ToString();
                        Approve.Click += new EventHandler(Approve_Click);

                        TableCell ApproveCell = new TableCell();
                        ApproveCell.Controls.Add(Approve);


                        row.Controls.Add(Name);
                        row.Controls.Add(EmailId);
                        row.Controls.Add(ApproveCell);
                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }

        void Approve_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            MyConnection obj = new MyConnection();
            int LectureId = int.Parse(lnk.CommandArgument);
            string result = obj.ApproveLecture(LectureId);
            if (result== "1")
            {
                Response.Redirect("ApproveLectureRegistration.aspx");
            }
        }
    }
}