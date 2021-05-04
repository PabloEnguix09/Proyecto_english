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
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbPath = Server.MapPath("~/database/healthCare.db");
            int user_ID = int.Parse(Request.Cookies["ID"].Value.ToString());
            string conString = "Data Source=" + dbPath + ";Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM patients WHERE " + user_ID + " = patients.userID", connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    lName.Text = Convert.ToString(reader[1]);
                    lDate.Text = Convert.ToString(reader[3]);
                    lGender.Text = Convert.ToString(reader[4]);
                    lDNI.Text = Convert.ToString(reader[5]);
                    lSIP.Text = Convert.ToString(reader[6]);

                    id = int.Parse(reader["ID"].ToString());

                }
            }

            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT doctors.name, records.disease, records.treatment FROM records LEFT JOIN doctors ON doctors.ID = records.doctorID WHERE " + id + " = records.patientID", connection);

                GridView1.DataSource = command.ExecuteReader();
                GridView1.DataBind();
            }

        }
    }
}