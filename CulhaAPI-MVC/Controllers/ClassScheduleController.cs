using CulhaAPI_MVC.API_Models.Request;
using DataLayer.Repository;
using DataLayer.Repository.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CulhaAPI_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassScheduleController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();

        // GET: api/<ClassScheduleController>
        [HttpGet]
        public IEnumerable<ClassSchedule> Get()
        {
            return context.ClassSchedules.ToList();
        }

        // GET api/<ClassScheduleController>/5
        [HttpGet("{id}")]
        public ClassSchedule Get(int id)
        {
            return context.ClassSchedules.Where(schedule=>schedule.Id==id).SingleOrDefault();
        }

        // POST api/<ClassScheduleController>
        [HttpPost]
        public void Post([FromBody] ClassScheduleResponse value)
        {
            ClassSchedule classSchedule = new ClassSchedule();
            classSchedule.ClassScheduleItemNo = value.ClassScheduleItemNo;
            classSchedule.ClassroomCode = value.ClassroomCode;
            classSchedule.CourseOfferedId = value.CourseOfferedId;

            TimeSlot ts = context.TimeSlots.Where(timeslot => timeslot.Day == value.Day && timeslot.Slot==value.Slot).SingleOrDefault();

            classSchedule.TimeSlotId = ts.Id;

            context.ClassSchedules.Add(classSchedule); 
            context.SaveChanges();
        }

        // PUT api/<ClassScheduleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClassSchedule value)
        {
            context.ClassSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().ClassScheduleItemNo = value.ClassScheduleItemNo;
            context.ClassSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().ClassroomCode = value.ClassroomCode;
            context.ClassSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().TimeSlotId = value.TimeSlotId;
            context.ClassSchedules.Where(schedule => schedule.Id == id).SingleOrDefault().CourseOfferedId = value.CourseOfferedId;
            context.SaveChanges();

        }

        // DELETE api/<ClassScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.ClassSchedules.Remove(context.ClassSchedules.Where(schedule => schedule.Id == id).SingleOrDefault());
            context.SaveChanges();
        }
    }
}
