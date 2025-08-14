using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Assignment_6.DTO;

namespace Assignment_6.Repositories
{
    public interface IVisitRepository
    {
        Task AddVisitAsync(AddVisitRequest req);
        Task UpdateVisitAsync(UpdateVisitRequest req);
        Task DeleteVisitAsync(DeleteVisitRequest req);
        Task<IEnumerable<VisitDto>> SearchByPatientAsync(string patientName);
        Task<IEnumerable<VisitDto>> SearchByDoctorAsync(string doctorName);
        Task<IEnumerable<VisitDto>> SearchByVisitTypeAsync(string visitTypeName);
    }
}
