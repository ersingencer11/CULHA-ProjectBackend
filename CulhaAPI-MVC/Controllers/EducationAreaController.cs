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
    public class EducationAreaController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<EducationAreaController>
        [HttpGet]
        public IEnumerable<EducationArea> Get()
        {
            return context.EducationAreas.ToList();
        }

        // GET api/<EducationAreaController>/5
        [HttpGet("{id}")]
        public EducationArea Get(int id)
        {
            return context.EducationAreas.Where(area=>area.Id==id).SingleOrDefault();
        }

        // POST api/<EducationAreaController>
        [HttpPost]
        public void Post([FromBody] EducationArea value)
        {
            context.EducationAreas.Add(value);
            context.SaveChanges();
        }

        // PUT api/<EducationAreaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EducationArea value)
        {
            context.EducationAreas.Where(area => area.Id == id).SingleOrDefault().ClassroomCode = value.ClassroomCode;
            context.EducationAreas.Where(area => area.Id == id).SingleOrDefault().CourseCode = value.CourseCode;
        }

        // DELETE api/<EducationAreaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.EducationAreas.Remove(context.EducationAreas.Where(area => area.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
