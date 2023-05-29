using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace StudentMaterialBoard
{
    public class MyConnection
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        public MyConnection()
        {
            con = new MySqlConnection("server=localhost;database=materialboard;user id=root;password=root;port=3307;");
            con.Open();
        }
        public DataTable GetDepartment()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from deptmaster");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetSubject()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from subjectmaster");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public int LoginVerify(string UserId, string Password, string UserType)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            int result=0;
            if (UserType == "Department Admin")
            {
                sql = string.Format("Select count(*) from deptadmin where DAId='{0}' and Password='{1}'", UserId, Password);
            }
            else if (UserType == "Student")
            {
                //string EncryptData = AESCryptoClass.EncryptData(Password, "1234");
                string sqlsp = string.Format("select * from studentmaster where SUSN='{0}'", UserId);
                cmd.CommandText = sqlsp;
                DataTable tab = new DataTable();
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(tab);
                string _pswd = AESCryptoClass.Decrypt(tab.Rows[0]["Password"].ToString(),"1234");
                if (_pswd == Password)
                {
                    sql = string.Format("Select count(*) from studentmaster where SUSN='{0}' and Password='{1}'", UserId, tab.Rows[0]["Password"].ToString());
                    cmd.CommandText = sql;
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    result = 0;
                }
            }
            else if (UserType == "Lecture")
            {
                string sqlsp = string.Format("select * from lecturemaster where EmailId='{0}'", UserId);
                cmd.CommandText = sqlsp;
                DataTable tab = new DataTable();
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(tab);
                string _pswd = AESCryptoClass.Decrypt(tab.Rows[0]["Password"].ToString(), "1234");
                if (_pswd == Password)
                {
                    sql = string.Format("Select count(*) from lecturemaster where EmailId='{0}' and Password='{1}' and Status='Approve'", UserId, tab.Rows[0]["Password"].ToString());
                    cmd.CommandText = sql;
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                }
                else
                {
                    result = 0;
                }
            }
           
            con.Close();
            return result;
        }

        public string ChangePassword(string UserId, string Password, string UserType)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            if (UserType == "Department Admin")
            {
                sql = string.Format("Update deptadmin set Password='{0}' where DAId='{1}'", Password, UserId);
            }
            else if (UserType == "Student")
            {
                sql = string.Format("Update studentmaster set Password='{0}' where SUSN='{1}'", Password, UserId);
            }
            else if (UserType == "Lecture")
            {
                sql = string.Format("Update lecturemaster set Password='{0}' where EmailId='{1}'", Password, UserId);
            }
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string AddSubject(string DAId,string SubjectName,string Sem)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;

            string sql = string.Format("select * from deptadmin where DAId='{0}'",DAId);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);

            string chksql = string.Format("Select count(*) from subjectmaster where DeptId={0} and SubjectName='{1}' and Sem='{2}'", int.Parse(tab.Rows[0]["DeptId"].ToString()), SubjectName, Sem);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sqls = string.Format("insert into subjectmaster(DeptId,SubjectName,Sem)values({0},'{1}','{2}')", int.Parse(tab.Rows[0]["DeptId"].ToString()), SubjectName, Sem);
                cmd.CommandText = sqls;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public string LectureRegister(int DeptId, string Name, string Password, string EmailId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into lecturemaster(DeptId,LectureName,Password,EmailId,Status)values({0},'{1}','{2}','{3}','Pending')", DeptId, Name, Password, EmailId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetLectureRegisterPending(string DAId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from deptadmin where DAId='{0}'", DAId);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);

            string sqllp = string.Format("select * from lecturemaster where DeptId={0} and Status='Pending'", int.Parse(tab.Rows[0]["DeptId"].ToString()));
            cmd.CommandText = sqllp;
            DataTable tablp = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tablp);
            con.Close();
            return tablp;
        }
        public string ApproveLecture(int LectureId)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("Update lecturemaster set Status='Approve' where LectureId={0}", LectureId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string StudentRegister(string USN, string Name, string Password, string EmailId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into studentmaster(SUSN,StudentName,Password,EmailId,MUCount,MRCount,Status)values('{0}','{1}','{2}','{3}',0,0,'Active')", USN, Name, Password, EmailId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string UploadMaterials(string UId, int SubjectId,string UserType,string MaterialName,string Description, string FilePath)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into materialmaster(UId,SubjectId,UserType,MaterialName,Description,FilePath,UploadDate,ViewCount,SpamCount,RatePoint,Status)values('{0}',{1},'{2}','{3}','{4}','{5}','{6}',0,0,'0','Active')", UId, SubjectId, UserType, MaterialName,Description, FilePath, DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlmu = string.Format("update studentmaster set MUCount=MUCount+1 where SUSN='{0}'", UId);
            cmd.CommandText = sqlmu;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetMaterialCount()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select count(*) as TotalCount from materialmaster");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetMaterial()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from materialmaster where Status='Active'");
//            string sql = string.Format(@"SELECT materialmaster.MMId,materialmaster.MaterialName,
//                                        materialmaster.FilePath,materialmaster.UploadDate,
//                                        materialmaster.UserType,materialmaster.ViewCount,
//                                        materialmaster.SpamCount,materialmaster.Description,
//                                        AVG(materialrate.MRate)AS MRatePoint FROM materialmaster
//                                        INNER JOIN materialrate ON
//                                        materialmaster.MMId=materialrate.MMId
//                                        WHERE materialmaster.Status='Active' GROUP BY
//                                        materialmaster.MMId,materialmaster.MaterialName,
//                                        materialmaster.FilePath,materialmaster.UploadDate,
//                                        materialmaster.UserType,materialmaster.ViewCount,
//                                        materialmaster.SpamCount,materialmaster.Description");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string MaterialRating(string UId, int MMId, string UserType, string MRate)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string chksql = string.Format("Select count(*) from materialrate where UId='{0}' and MMId={1}", UId,MMId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            if (res == "0")
            {
                string sqls = string.Format("insert into materialrate(MMId,UId,UserType,MRate,RateDate)values({0},'{1}','{2}','{3}','{4}')", MMId,UId,UserType,MRate,DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.CommandText = sqls;
                result = cmd.ExecuteNonQuery().ToString();

                string chksqlAvg = string.Format("Select Avg(MRate) from materialrate where MMId={0}", MMId);
                cmd.CommandText = chksqlAvg;
                string avg = cmd.ExecuteScalar().ToString();


                string sqlup = string.Format("update materialmaster set RatePoint='{0}' where MMId={1}",avg,MMId);
                cmd.CommandText = sqlup;
                result = cmd.ExecuteNonQuery().ToString();


            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public string UpdateMVCount(int MMId)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            sql = string.Format("Update materialmaster set ViewCount=ViewCount+1 where MMId={0}", MMId);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public string UpdateMSpamCount(int MMId,string UId)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            string sqlspmcnt = string.Format("select * from materialmaster where MMId={0}", MMId);
            cmd.CommandText = sqlspmcnt;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            if (int.Parse(tab.Rows[0]["SpamCount"].ToString()) == 4)
            {
                sql = string.Format("Update materialmaster set Status='Deactive' where MMId={0}", MMId);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();

                string sqlspam = string.Format("insert into materialuserspam(MMId,UId)values({0},'{1}')", MMId, UId);
                cmd.CommandText = sqlspam;
                result = cmd.ExecuteNonQuery().ToString();

                string sqlus = string.Format("Update materialmaster set SpamCount=SpamCount+1 where MMId={0}", MMId);
                cmd.CommandText = sqlus;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else if (int.Parse(tab.Rows[0]["SpamCount"].ToString()) < 4)
            {
                string chksql = string.Format("Select count(*) from materialuserspam where UId='{0}' and MMId={1}", UId, MMId);
                cmd.CommandText = chksql;
                string res = cmd.ExecuteScalar().ToString();
                if (res == "0")
                {
                    string sqlspam = string.Format("insert into materialuserspam(MMId,UId)values({0},'{1}')", MMId, UId);
                    cmd.CommandText = sqlspam;
                    result = cmd.ExecuteNonQuery().ToString();

                    string sqlus = string.Format("Update materialmaster set SpamCount=SpamCount+1 where MMId={0}", MMId);
                    cmd.CommandText = sqlus;
                    result = cmd.ExecuteNonQuery().ToString();
                }
                else
                {
                    result = "2";
                }
            }
            
            con.Close();
            return result;
        }

        public string PostMaterialQuery(int MMId,string UId, string UserType, string PostQuery)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into materialquery(MMId,UId,UserType,PostQuery,PostDate,Status)values({0},'{1}','{2}','{3}','{4}','Pending')", MMId, UId, UserType, PostQuery, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetMaterialQuery(int MMId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from materialquery where MMId={0}",MMId);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetMaterialQuery()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT * FROM materialquery WHERE PostDate < NOW() - INTERVAL 24 HOUR and Status='Pending'");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            if (tab.Rows.Count == 0)
            {
                string sqld = string.Format(@"SELECT * FROM materialquery WHERE PostDate < NOW() - INTERVAL 1 Day and Status='Pending'");
                cmd.CommandText = sqld;
                tab = new DataTable();
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(tab);
            }

            con.Close();
            return tab;
        }

        public string MaterialReply(int MQId, string UId, string UserType, string ReplyQuery,string FilePath)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into materialqueryreply(MQId,UId,UserType,ReplyQuery,ReplyDate,FilePath)values({0},'{1}','{2}','{3}','{4}','{5}')", MQId, UId, UserType, ReplyQuery, DateTime.Now,FilePath);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlup = string.Format("update materialquery set Status='Active' where MQId={0}",MQId);
            cmd.CommandText = sqlup;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlmu = string.Format("update studentmaster set MRCount=MRCount+1 where SUSN='{0}'", UId);
            cmd.CommandText = sqlmu;
            result = cmd.ExecuteNonQuery().ToString();

            con.Close();
            return result;
        }
        public DataTable GetMaterialReplyQuery(int MQId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from materialqueryreply where MQId={0}", MQId);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetLeaderBoard()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("SELECT SUSN,StudentName,((MUCount*10)+(MRCount*2)) AS Score FROM studentmaster ORDER BY Score DESC LIMIT 5");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string PostGeneralQuestion(string UId, string UserType, string QuestionName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into generalquestion(UId,QuestionName,UserType,PostDate,Status)values('{0}','{1}','{2}','{3}','Active')", UId,QuestionName, UserType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public DataTable GetGeneralQuestion()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from generalquestion");
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string GQReply(int GQId, string UId, string UserType, string QuestionReply)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into gqreply(GQId,UId,QuestionReply,UserType,ReplyDate,Status)values({0},'{1}','{2}','{3}','{4}','Active')", GQId, UId,QuestionReply, UserType,DateTime.Now);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetGQReply(int GQId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from gqreply where GQId={0}", GQId);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }
    }
}