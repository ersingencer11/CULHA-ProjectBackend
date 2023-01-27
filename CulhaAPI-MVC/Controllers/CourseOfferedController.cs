using DataLayer.Repository;
using DataLayer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CulhaAPI_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin")]
    public class CourseOfferedController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<CourseOfferedController>
        [HttpGet]
        public IEnumerable<CourseOffered> Get()
        {
            return context.CourseOffereds.ToList();
        }

        // GET api/<CourseOfferedController>/5
        [HttpGet("{id}")]
        public CourseOffered Get(int id)
        {
            return context.CourseOffereds.Where(offered=>offered.Id==id).SingleOrDefault();
        }

        // POST api/<CourseOfferedController>
        [HttpPost]
        public void Post([FromBody] CourseOffered value)
        {
            context.CourseOffereds.Add(value);
            context.SaveChanges();
        }

        // PUT api/<CourseOfferedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CourseOffered value)
        {
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().Term = value.Term;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().Coyear = value.Coyear;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().Section = value.Section;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().IsOnline = value.IsOnline;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().StudentCount = value.StudentCount;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().IsAssigned = value.IsAssigned;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().SemesterCount = value.SemesterCount;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().CourseCode = value.CourseCode;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().DepartmentCode = value.DepartmentCode;
            context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault().AcademicianId = value.AcademicianId;
        }

        // DELETE api/<CourseOfferedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.CourseOffereds.Remove(context.CourseOffereds.Where(offered => offered.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
