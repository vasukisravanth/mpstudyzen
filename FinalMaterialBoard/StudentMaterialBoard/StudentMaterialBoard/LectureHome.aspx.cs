using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudentMaterialBoard
{
    public partial class LectureHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetLeaderBoard();
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();


                    hc1.Text = "Student USN";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Student Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Student Score";
                    hr.Cells.Add(hc3);


                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        if (tab.Rows[i]["Score"].ToString() != "0")
                        {
                            Label lblSUSN = new Label();
                            lblSUSN.Text = tab.Rows[i]["SUSN"].ToString();
                            TableCell SUSN = new TableCell();
                            SUSN.Controls.Add(lblSUSN);

                            Label lblName = new Label();
                            lblName.Text = tab.Rows[i]["StudentName"].ToString();
                            TableCell Name = new TableCell();
                            Name.Controls.Add(lblName);

                            Label lblScore = new Label();
                            lblScore.Text = tab.Rows[i]["Score"].ToString();
                            TableCell Score = new TableCell();
                            Score.Controls.Add(lblScore);

                            row.Controls.Add(SUSN);
                            row.Controls.Add(Name);
                            row.Controls.Add(Score);
                            Table1.Controls.Add(row);
                        }
                    }
                }
                else
                {
                    //lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }
    }
}