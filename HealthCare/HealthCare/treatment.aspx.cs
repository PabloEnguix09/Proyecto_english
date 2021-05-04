using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthCare
{
    public partial class treatment : System.Web.UI.Page
    {
        public int doctorId;
        public int patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            doctorId = int.Parse(Request.Cookies["doctorId"].Value.ToString());
            patientId = int.Parse(Request.Cookies["patientId"].Value.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string disease = illness.Value.ToString();
            string treatment = record.Value.ToString();
            string day = date.Value.ToString();

            string dbPath = Server.MapPath("~/database/healthCare.db");
            string conString = "Data Source=" + dbPath + ";Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                    SQLiteCommand command = new SQLiteCommand("INSERT into records VALUES(null," + doctorId + "," + patientId + ",'" + disease + "', '" + treatment + "','" + day + "')", connection);
                    command.ExecuteNonQuery();
                    Response.Redirect("doctor.aspx");
            }
        }
    }
}