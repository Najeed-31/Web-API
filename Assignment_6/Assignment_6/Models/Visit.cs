using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Assignment_6.Models
{
    public class Visit
    {
        public int VisitID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int VisitTypeID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Fee { get; set; }
    }
}