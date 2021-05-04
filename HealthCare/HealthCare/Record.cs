using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCare
{
    public class Record
    {
        public string id { get; set; }
        public string doctorId { get; set; }
        public string patientId { get; set; }
        public string disease { get; set; }
        public string treatment { get; set; }
        public string date { get; set; }

        public Record(string id, string doctorId, string patientId, string disease, string treatment, string date)
        {
            this.id = id;
            this.doctorId = doctorId;
            this.patientId = patientId;
            this.disease = disease;
            this.treatment = treatment;
            this.date = date;
        }
    }
}