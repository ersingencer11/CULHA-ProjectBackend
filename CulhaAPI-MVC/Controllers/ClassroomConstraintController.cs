using CulhaAPI_MVC.API_Models.Request;
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
    //[Authorize(Roles = "admin")]
    public class ClassroomConstraintController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<ClassroomConstraintController>
        [HttpGet]
        public IEnumerable<ClassroomConstraint> Get()
        {
                return context.ClassroomConstraints.ToList();       
        }

        // GET api/<ClassroomConstraintController>/5
        [HttpGet("{id}")]
        public IEnumerable<ClassroomConstraint> Get(int id)
        {
            return context.ClassroomConstraints.Where(constraint=>constraint.Id == id).ToList();
        }

        // POST api/<ClassroomConstraintController>
        [HttpPost]
        public void Post([FromBody] ClassroomConstraint value)
        {
            context.ClassroomConstraints.Add(value);
            context.SaveChanges();
        }

        // PUT api/<ClassroomConstraintController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClassroomConstraintRequest req)
        {
            new ClassroomConstraintRepo().ClassroomConstraintInsert(req);

        }

        // DELETE api/<ClassroomConstraintController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.ClassroomConstraints.Remove(context.ClassroomConstraints.Where(constraint => constraint.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
