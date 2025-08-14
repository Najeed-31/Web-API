using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Assignment_6.DTO
{
    public class VisitDto
    {
        public int VisitId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Fee { get; set; }
    }
}
