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

            //private static string dbPath = Application.StartupPath + @"\databases\furniture.db"; Just for windows form, not asp.net  
            dbPath = Server.MapPath("~/database/healthCare.db");
            conString = "Data Source=" + dbPath + ";Version=3;";
            user_ID = int.Parse(Request.Cookies["ID"].Value.ToString());
            Label1.Text = user_ID.ToString();

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


            /*
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT doctors.name, records.treatment FROM records LEFT JOIN doctors ON doctors.ID = records.doctorID WHERE " + id + " = records.patientID", connection);

                GridView1.DataSource = command.ExecuteReader();
                GridView1.DataBind();
                
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
                
            }
            */

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Clear();
            TextBox1.Text = "";
            // We search if there is an item selected
            if (ListBox1.SelectedItem != null)
            {
                // We get the selected item
                string curItem = ListBox1.SelectedItem.ToString();
                Label1.Text = curItem;

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
                Label9.Text = patID.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // We get the selected item
            string curItem = ListBox2.SelectedItem.ToString();
            Label1.Text = curItem;

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                if (ListBox1.SelectedItem != null)
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
                }
            }
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                if(ListBox2.SelectedItem != null)
                {
                    string curItem = ListBox2.SelectedItem.ToString();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM records WHERE '" + curItem + "' = records.treatment;", connection);
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            disease = reader[3].ToString();
                            record = reader[4].ToString();
                            date = reader[5].ToString();
                            diseaseId = int.Parse(reader[0].ToString());
                        }
                    }
                    HttpCookie userId = new HttpCookie("doctorId");
                    userId.Value = user_ID.ToString();
                    HttpCookie patientId = new HttpCookie("patientId");
                    patientId.Value = patID.ToString();
                    HttpCookie ckDisease = new HttpCookie("disease");
                    ckDisease.Value = disease;
                    HttpCookie ckRecord = new HttpCookie("record");
                    ckRecord.Value = record;
                    HttpCookie ckDate = new HttpCookie("date");
                    ckDate.Value = date;
                    HttpCookie ckDiseaseId = new HttpCookie("diseaseId");
                    ckDiseaseId.Value = diseaseId.ToString();

                    Response.Cookies.Add(userId);
                    Response.Cookies.Add(patientId);
                    Response.Cookies.Add(ckDisease);
                    Response.Cookies.Add(ckRecord);
                    Response.Cookies.Add(ckDate);
                    Response.Cookies.Add(ckDiseaseId);
                    Response.Redirect("editTreatment.aspx");
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Paciente
            dbPath = Server.MapPath("~/database/healthCare.db");
            conString = "Data Source=" + dbPath + ";Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(conString))
            {
                connection.Open();
                if (ListBox1.SelectedItem != null)
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

                    //INSERT into users VALUES(null,'illo',124,0);
                    SQLiteCommand update = new SQLiteCommand("UPDATE patients SET name = 'Josua', Birthdate='10/20/21', Gender = 'Male', DNI = '123456789L', SIP = '200000000' WHERE patients.ID = " + patID + "", connection);
                    update.ExecuteNonQuery();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                // We get the selected item
                string curItem = ListBox1.SelectedItem.ToString();
                Label1.Text = curItem;
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