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
    public class ExamScheduleController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<ExamScheduleController>
        [HttpGet]
        public IEnumerable<ExamSchedule> Get()
        {
            return context.ExamSchedules.ToList();
        }

        // GET api/<ExamScheduleController>/5
        [HttpGet("{id}")]
        public ExamSchedule Get(int id)
        {
            return context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault();
        }

        // POST api/<ExamScheduleController>
        [HttpPost]
        public void Post([FromBody] ExamSchedule value)
        {
            context.ExamSchedules.Add(value);
            context.SaveChanges();
        }

        // PUT api/<ExamScheduleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ExamSchedule value)
        {
            context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().CourseCode = value.CourseCode;
            context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().ClassroomCode = value.ClassroomCode;
            context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().Supervisor = value.Supervisor;
            context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().Section = value.Section;
            context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().TimeSlotId = value.TimeSlotId;
            context.SaveChanges();
        }

        // DELETE api/<ExamScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.ExamSchedules.Remove(context.ExamSchedules.Where(schedule => schedule.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
