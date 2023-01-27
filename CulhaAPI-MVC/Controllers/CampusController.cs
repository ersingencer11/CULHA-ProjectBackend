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
    public class CampusController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<CampusController>
        [HttpGet]
        public IEnumerable<Campus> Get()
        {
                return context.Campuses.ToList(); 
        }

        // GET api/<CampusController>/5
        [HttpGet("{id}")]
        public Campus Get(int id)
        {
                return context.Campuses.Where(campus => campus.Id == id).ToList().FirstOrDefault();
        }

        // POST api/<CampusController>
        [HttpPost]
        public Campus Post([FromBody] Campus value)
        {
                context.Campuses.Add(value);
                context.SaveChanges();

                return value;
        }

        // PUT api/<CampusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Campus value)
        {
                context.Campuses.Where(campus => campus.Id == id).SingleOrDefault().Name = value.Name;
                context.SaveChanges();
        }

        // DELETE api/<CampusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
                context.Campuses.Remove(context.Campuses.Where(campus => campus.Id == id).SingleOrDefault());
                context.SaveChanges();
        }
    }
}
