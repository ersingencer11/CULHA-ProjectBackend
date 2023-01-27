using CulhaAPI_MVC.API_Models.Request;
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
    //[Authorize(Roles = "admin")]
    public class CourseConstraintController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<CourseConstraintController>
        [HttpGet]
        public IEnumerable<CourseConstraint> Get()
        {
            return context.CourseConstraints.ToList();
        }

        // GET api/<CourseConstraintController>/5
        [HttpGet("{id}")]
        public CourseConstraint Get(int id)
        {
            return context.CourseConstraints.Where(constraint => constraint.Id == id).SingleOrDefault();
        }

        // POST api/<CourseConstraintController>
        [HttpPost]
        public void Post([FromBody] CourseConstraint value)
        {
            context.CourseConstraints.Add(value);  
            context.SaveChanges();
        }

        // PUT api/<CourseConstraintController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CourseConstraintRequest req)
        {
            new CourseConstraintRepo().CourseConstraintInsert(req);
        }

        // DELETE api/<CourseConstraintController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.CourseConstraints.Remove(context.CourseConstraints.Where(constraint => constraint.Id == id).SingleOrDefault());
            context.SaveChanges();
        }



        
        //GET api/<CourseConstraintController>/AllCourseOfferedConstraints
        [HttpGet()]
        [Route("[action]")]
        public ActionResult<List<CourseOfferedConstraints>> AllCourseOfferedConstraints()
        {
            List<CourseOffered> courseOffereds=context.CourseOffereds.ToList();
            List<CourseOfferedConstraints> responseList = new List<CourseOfferedConstraints>();

            foreach (var courseOffered in courseOffereds)
            {
                List<CourseConstraint> courseConstraints = context.CourseConstraints.
                Where(courseConstraint => courseConstraint.CourseCode == courseOffered.CourseCode).ToList();

                if (courseConstraints!=null)
                {
                    foreach (var constraint in courseConstraints)
                    {
                        CourseOfferedConstraints courseOfferedConstraints = new CourseOfferedConstraints();
                        courseOfferedConstraints.CourseOfferedId = courseOffered.Id;
                        courseOfferedConstraints.CourseCode = courseOffered.CourseCode;
                        courseOfferedConstraints.TimeSlotId = (int)constraint.TimeSlotId;
                        responseList.Add(courseOfferedConstraints);
                    }
                }
               
            }

            return Ok(responseList);

        }










    }
}
