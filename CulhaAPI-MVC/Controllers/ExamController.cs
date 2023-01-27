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
    public class ExamController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<ExamController>
        [HttpGet]
        public IEnumerable<Exam> Get()
        {
            return context.Exams.ToList();
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public Exam Get(int id)
        {
            return context.Exams.Where(exam=>exam.Id==id).SingleOrDefault();
        }

        // POST api/<ExamController>
        [HttpPost]
        public void Post([FromBody] Exam value)
        {
            context.Exams.Add(value);
            context.SaveChanges();
        }

        // PUT api/<ExamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Exam value)
        {
            context.Exams.Where(exam => exam.Id == id).SingleOrDefault().Duration = value.Duration;
            context.SaveChanges();
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Exams.Remove(context.Exams.Where(exam => exam.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
