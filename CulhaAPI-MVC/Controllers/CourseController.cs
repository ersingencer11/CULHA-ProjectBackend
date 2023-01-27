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
    public class CourseController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return context.Courses.ToList();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Course Get(string id)
        {
            return context.Courses.Where(course=>course.CourseCode==id).SingleOrDefault();
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Course value)
        {
            context.Courses.Add(value);
            context.SaveChanges();  
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Course value)
        {
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().CourseCode= value.CourseCode;
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().Quota = value.Quota;
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().CourseType = value.CourseType;
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().PracticalHour = value.PracticalHour;
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().TheoreticalHour = value.TheoreticalHour;
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().Credit = value.Credit;
            context.Courses.Where(course => course.CourseCode == id).SingleOrDefault().Ects = value.Ects;
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            context.Courses.Remove(context.Courses.Where(course => course.CourseCode == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
