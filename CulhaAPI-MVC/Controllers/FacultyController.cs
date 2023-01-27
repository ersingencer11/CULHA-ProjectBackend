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
    public class FacultyController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<FacultyController>
        [HttpGet]
        public IEnumerable<Faculty> Get()
        {
            return context.Faculties.ToList();
        }

        // GET api/<FacultyController>/5
        [HttpGet("{id}")]
        public Faculty Get(int id)
        {
            return context.Faculties.Where(faculty => faculty.Id == id).SingleOrDefault();
        }

        // POST api/<FacultyController>
        [HttpPost]
        public void Post([FromBody] Faculty value)
        {
            context.Faculties.Add(value);
            context.SaveChanges();
        }

        // PUT api/<FacultyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Faculty value)
        {
            context.Faculties.Where(faculty => faculty.Id == id).SingleOrDefault().Name = value.Name;
            context.SaveChanges();
        }

        // DELETE api/<FacultyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Faculties.Remove(context.Faculties.Where(faculty => faculty.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
