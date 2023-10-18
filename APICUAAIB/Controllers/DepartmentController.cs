using APICUAAIB.DTO;
using APICUAAIB.Entities;
using APICUAAIB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICUAAIB.Controllers
{
    [Route("api/[controller]")] //replacement token --/api/Department
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        CompanyContext Db = new CompanyContext();
        [HttpGet]
        public ActionResult<List<Department>> Get()
        {
            return Db.Departments.ToList();
        }
        [HttpGet("/emps")]
        public ActionResult<List<Department>> GetAll()
        {
             List<Department> depts = Db.Departments.Include(e => e.Employees).ToList();
            List<DeptWithEmpsNamesDTO> deptDto = new List<DeptWithEmpsNamesDTO>();
            foreach(Department dept in depts)
            {
                List<string> names = new List<string>();
                foreach(var e in  dept.Employees)
                {
                    names.Add(e.Name);
                }
                deptDto.Add(new DeptWithEmpsNamesDTO() 
                { Department_Name = dept.Name , Department_Location=dept.Location, Department_Number=dept.Id , Department_Emps=names});
            }
            return Ok(deptDto);
        }


        [HttpGet]
        [Route("{id:int}")] //api/Department/1
        public ActionResult<Department> GetById(int id)
        {
            var dept = Db.Departments.FirstOrDefault(d => d.Id == id);
            if(dept == null)
            {
                return NotFound(new {ErrorMessage = "Department Not Found !!"});
            }
            return Ok(dept);
        }
        [HttpGet("{name:alpha}")]

        //[Route("{name}")]
        public ActionResult GetByName(string name)
        {
            var dept = Db.Departments.FirstOrDefault(d=>d.Name == name);
            if(dept != null)
            {
                return Ok(dept);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult Add(Department dept) 
        {
            if(ModelState.IsValid)
            {
                Db.Departments.Add(dept);
                Db.SaveChanges();
                return Ok(new {Message="Deparment Added Succefully!!",Depts = Db.Departments.ToList()});
            }
            else
            {
                return BadRequest();
            }
           

        }
     
        [HttpPut("{id}")]
        public ActionResult Edit(Department NewDept,int id)
        {
            var dept = Db.Departments.FirstOrDefault(d => d.Id == id);
            if (ModelState.IsValid)
            {
                dept.Name = NewDept.Name;
                dept.Location = NewDept.Location;
                Db.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dept = Db.Departments.FirstOrDefault(d => d.Id == id);
            if(dept != null)
            {
                Db.Departments.Remove(dept);
                Db.SaveChanges();
                return Ok(new {Message="Department Deleted Succefully" , depts = Db.Departments.ToList()});
            }
            else
            {
                return NotFound();
            }
           
        }
      
    }
}
