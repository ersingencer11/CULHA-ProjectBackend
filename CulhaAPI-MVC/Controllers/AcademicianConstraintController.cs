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
   // [Authorize(Roles ="admin")]
    public class AcademicianConstraintController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<AcademicianConstraController>
        [HttpGet]
        public IEnumerable<AcademicianConstraint> Get()
        {
                return context.AcademicianConstraints.ToList();               
        }

        // GET api/<AcademicianConstraController>/5
        [HttpGet("{id}")]
        public IEnumerable<AcademicianConstraint> Get(int id)
        {
                return context.AcademicianConstraints.Where(academicianconstraint => academicianconstraint.Id == id).ToList();
        }

        // POST api/<AcademicianConstraController>
        [HttpPost]
        public void Post([FromBody]List<AcademicianConstraintRequest> req)
        {
                new AcademicianConstraintRepo().AcademicianConstraintInsert(req);
        }

        // PUT api/<AcademicianConstraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AcademicianConstraint value)
        {
                context.AcademicianConstraints.Where(academicianConstraint => academicianConstraint.Id == id).SingleOrDefault().Description = value.Description;
                context.AcademicianConstraints.Where(academicianConstraint => academicianConstraint.Id == id).SingleOrDefault().AcademicianId = value.AcademicianId;
                context.AcademicianConstraints.Where(academicianConstraint => academicianConstraint.Id == id).SingleOrDefault().TimeSlotId = value.TimeSlotId;

                context.SaveChanges();
        }

        // DELETE api/<AcademicianConstraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
                context.AcademicianConstraints.Remove(context.AcademicianConstraints.Where(academicianConstraint => academicianConstraint.Id == id).SingleOrDefault());
                context.SaveChanges();
        }
    }
}
