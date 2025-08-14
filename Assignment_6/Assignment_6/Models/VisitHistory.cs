using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Assignment_6.Models
{
    public class VisitHistory
    {
        public int HistoryID { get; set; }
        public string Action { get; set; }
        public int PatientID { get; set; }
        public DateTime VisitDate { get; set; }
        public int VisitTypeID { get; set; }
        public string Description { get; set; }
        public int DoctorID { get; set; }
    }
}
