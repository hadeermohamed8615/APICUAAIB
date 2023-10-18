using APICUAAIB.Entities;
using APICUAAIB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICUAAIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        CompanyContext db = new CompanyContext();
        [HttpGet]
         public ActionResult Get()
        {
            var emps = db.Employee.ToList();
            if(emps != null)
            {
                return Ok(emps);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var emp = db.Employee.FirstOrDefault(e=>e.SSN==id);
            if (emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        //[Authorize]
        public ActionResult add(Employee emp)
        {
         
            if (ModelState.IsValid)
            {
                db.Add(emp);
                db.SaveChanges();
                return Created("/api/Employee",emp);
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
