using CulhaAPI_MVC.API_Models.Response;
using CulhaAPI_MVC.Repos;
using DataLayer.Repository;
using DataLayer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CulhaAPI_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "admin")]
    public class DepartmentController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<DepartmentController>/Department
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return context.Departments.ToList();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(string id)
        {
            return context.Departments.Where(department=>department.DepartmentCode==id).SingleOrDefault();
        }
        

        // POST api/<DepartmentController>/Department
        [HttpPost]
        public void Post([FromBody] Department value)
        {
            context.Departments.Add(value);
            context.SaveChanges();
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Department value)
        {
            context.Departments.Where(department => department.DepartmentCode == id).SingleOrDefault().Name = value.Name;
            context.Departments.Where(department => department.DepartmentCode == id).SingleOrDefault().FacultyId = value.FacultyId;
            context.Departments.Where(department => department.DepartmentCode == id).SingleOrDefault().DepartmentChair = value.DepartmentChair;
            context.Departments.Where(department => department.DepartmentCode == id).SingleOrDefault().Email = value.Email;
            context.SaveChanges();
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            context.Departments.Remove(context.Departments.Where(department => department.DepartmentCode == id).SingleOrDefault());
            context.SaveChanges();
        }

        //GET api/<DepartmentController>/DepartmentClassSchedule/5
        [HttpGet()]
        [Route("[action]/{id}")]
        public ActionResult<List<DepartmentClassScheduleResponse>> DepartmentClassSchedule(string? id)
        {

            return Ok(new DepartmentClassScheduleRepo().GetDepartmentClassSchedule(id));
        }
    }
}
