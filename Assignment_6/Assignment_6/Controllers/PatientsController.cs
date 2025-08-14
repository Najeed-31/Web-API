using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment_6.DTO;
using Assignment_6.Services;
using Assignment_6.Repositories;
namespace Assignment_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repo;
        public PatientsController(IPatientRepository repo) { _repo = repo; }

        [HttpGet("id")]
        //[Authorize]
        public async Task<IActionResult> GetId([FromQuery] string name)
        {
            var id = await _repo.GetPatientIdByNameAsync(name);
            if (id == null) return NotFound();
            return Ok(new { PatientID = id });
        }
    }
}