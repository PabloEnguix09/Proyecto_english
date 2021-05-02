using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SQLite;

namespace HealthCare
{
    public partial class patient : System.Web.UI.Page
    {
        public string name;
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //private static string dbPath = Application.StartupPath + @"\databases\furniture.db"; Just for windows form, not asp.net  
            string dbPath = Server.MapPath("~/database/healthCare.db");
            int user_ID = int.Parse(Request.Cookies["ID"].Value.ToString());
            //int user_ID = 0;
            string conString = "Data Source=" + dbPath + ";Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT patiences.name, patiences.ID FROM patiences WHERE " + user_ID + " = patiences.userID", connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    name = reader["name"].ToString();
                    id = int.Parse(reader["ID"].ToString());

                }
            }

            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT doctors.name, records.record FROM records LEFT JOIN doctors ON doctors.ID = records.doctorID WHERE " + id + " = records.patienceID", connection);

                GridView1.DataSource = command.ExecuteReader();
                GridView1.DataBind();
                /*  
                  using (SQLiteDataReader reader = command.ExecuteReader())
                  {

                      DataTable dt = new DataTable();
                      dt.Load(reader);
                      foreach (DataRow dr in dt.Rows)
                      {

                      }

                        SQLiteDataAdapter da = new SQLiteDataAdapter();
                         da.InsertCommand = comm;
                         da.InsertCommand.ExecuteNonQuery();
                         da.DeleteCommand = comm;
                         da.DeleteCommand.ExecuteNonQuery();
                         da.UpdateCommand = comm;
                         da.UpdateCommand.ExecuteNonQuery();

                  }
                  */
            }

        }
    }
}