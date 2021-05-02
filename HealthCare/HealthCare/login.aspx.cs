using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace HealthCare
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //private static string dbPath = Application.StartupPath + @"\databases\furniture.db"; Just for windows form, not asp.net  
            string dbPath = Server.MapPath("~/database/healthCare.db");

            string conString = "Data Source=" + dbPath + ";Version=3;";

            string password = pass.Value;
            HashPassword(pass.Value.ToString());


        }

        private void HashPassword(String password)
        {

            string dbPath = Server.MapPath("~/database/healthCare.db");

            string conString = "Data Source=" + dbPath + ";Version=3;";

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                password = BitConverter.ToString(data).Replace("-", string.Empty);

            }

            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                string user = username.Value;
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM users WHERE users.user = '" + user + "' AND users.password = '" + password + "'", connection);

                int userType = -1;
                int user_ID = -1;
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.StepCount == 1)
                    {


                        userType = int.Parse(reader["type"].ToString());
                        user_ID = int.Parse(reader["ID"].ToString());



                    }
                }

                if (userType == 0)
                {
                    HttpCookie myCookie = new HttpCookie("ID");
                    myCookie.Value = user_ID.ToString();
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("patient.aspx");
                }
            }
        }
    }
}