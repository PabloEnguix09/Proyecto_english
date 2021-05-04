using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.IO;

namespace HealthCare
{
    public partial class doctor : System.Web.UI.Page
    {
        public string name;
        public int user_ID;
        public int patID;
        public string disease;
        public string record;
        public string date;
        public int diseaseId;
        public string dbPath;
        public string conString;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbPath = Server.MapPath("~/database/healthCare.db");
            conString = "Data Source=" + dbPath + ";Version=3;";
            user_ID = int.Parse(Request.Cookies["ID"].Value.ToString());

            List<string> pacientesID = new List<string>();
            List<string> historial = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM records WHERE " + user_ID + " = records.doctorID", connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        if (!pacientesID.Contains(Convert.ToString(reader[2])))
                        {
                            pacientesID.Add(Convert.ToString(reader[2]));
                            historial.Add(Convert.ToString(reader[3]));
                        }

                    }

                }
            }

            if (ListBox1.Items.Count == 0)
            {


                foreach (string paciente in pacientesID)
                {
                    using (SQLiteConnection connection = new SQLiteConnection(conString))
                    {
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand("SELECT patients.name FROM patients WHERE " + int.Parse(paciente) + " = patients.ID", connection);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                                ListBox1.Items.Add(Convert.ToString(reader[0]));
                            }

                        }
                    }
                }
            }

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Clear();
            TextBox1.Text = "";
            if (ListBox1.SelectedItem != null)
            {
                string curItem = ListBox1.SelectedItem.ToString();

                using (SQLiteConnection connection = new SQLiteConnection(conString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM patients WHERE '" + curItem + "' = patients.name", connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            lName.Text = Convert.ToString(reader[1]);
                            lDate.Text = Convert.ToString(reader[3]);
                            lGender.Text = Convert.ToString(reader[4]);
                            lDNI.Text = Convert.ToString(reader[5]);
                            lSIP.Text = Convert.ToString(reader[6]);

                            patID = int.Parse(Convert.ToString(reader[0]));
                        }
                    }
                }

                using (SQLiteConnection connection = new SQLiteConnection(conString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT records.treatment FROM records WHERE " + patID + " = records.patientID AND " + user_ID + " = records.doctorID", connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            ListBox2.Items.Add(Convert.ToString(reader[0]));
                        }

                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ListBox2.SelectedItem != null)
            {
                string curItem = ListBox2.SelectedItem.ToString();

                using (SQLiteConnection connection = new SQLiteConnection(conString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM records WHERE '" + curItem + "' = records.treatment;", connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            TextBox1.Text = "Illness: " + Convert.ToString(reader[3]) + "\r\n" +
                               "Record: " + Convert.ToString(reader[4]) + "\r\n" +
                               "Date: " + Convert.ToString(reader[5]);
                        }
                    }
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                if(ListBox1.SelectedItem != null)
                {
                    string curItem = ListBox1.SelectedItem.ToString();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM patients WHERE '" + curItem + "' = patients.name", connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            patID = int.Parse(Convert.ToString(reader[0]));
                        }
                    }
                    HttpCookie userId = new HttpCookie("doctorId");
                    userId.Value = user_ID.ToString();
                    HttpCookie patientId = new HttpCookie("patientId");
                    patientId.Value = patID.ToString();
                    Response.Cookies.Add(userId);
                    Response.Cookies.Add(patientId);
                    Response.Redirect("treatment.aspx");
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                string curItem = ListBox1.SelectedItem.ToString();
                dbPath = Server.MapPath("~/database/healthCare.db");
                conString = "Data Source=" + dbPath + ";Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(conString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM patients WHERE '" + curItem + "' = patients.name", connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            patID = int.Parse(Convert.ToString(reader[0]));
                        }
                    }

                    SQLiteCommand patient = new SQLiteCommand("SELECT * from records WHERE patientID=" + patID + "", connection);
                    List<Record> patientRecords = new List<Record>();
                    using (SQLiteDataReader reader = patient.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            string id = Convert.ToString(reader[0]);
                            string doctorId = Convert.ToString(reader[1]);
                            string patientId = Convert.ToString(reader[2]);
                            string disease = Convert.ToString(reader[3]);
                            string treatment = Convert.ToString(reader[4]);
                            string date = Convert.ToString(reader[5]);
                            patientRecords.Add(new Record(id, doctorId, patientId, disease, treatment, date));
                        }
                        string jsonData = JsonConvert.SerializeObject(patientRecords);
                        File.WriteAllText(Server.MapPath("~/data/record.json"), jsonData);
                    }
                }
            }
        }
    }
}