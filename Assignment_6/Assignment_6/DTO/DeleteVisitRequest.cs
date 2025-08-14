using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Assignment_6.DTO
{
    public class DeleteVisitRequest
    {
        public string PatientName { get; set; }
        public string VisitTypeName { get; set; }
        public string DoctorName { get; set; }
        public int DurationMinutes { get; set; }
    }
}
