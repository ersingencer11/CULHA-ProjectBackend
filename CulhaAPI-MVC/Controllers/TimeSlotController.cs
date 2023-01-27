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
   // [Authorize(Roles = "admin")]
    public class TimeSlotController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<TimeSlotController>
        [HttpGet]
        public IEnumerable<TimeSlot> Get()
        {
            return context.TimeSlots.ToList();
        }

        // GET api/<TimeSlotController>/5
        [HttpGet("{id}")]
        public TimeSlot Get(int id)
        {
            return context.TimeSlots.Where(slot=>slot.Id==id).SingleOrDefault();
        }

        // POST api/<TimeSlotController>
        [HttpPost]
        public void Post([FromBody] TimeSlot value)
        {
            context.TimeSlots.Add(value);
            context.SaveChanges();
        }

        // PUT api/<TimeSlotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeSlot value)
        {
            context.TimeSlots.Where(slot => slot.Id == id).SingleOrDefault().Slot = value.Slot;
            context.TimeSlots.Where(slot => slot.Id == id).SingleOrDefault().Day = value.Day;
            context.TimeSlots.Where(slot => slot.Id == id).SingleOrDefault().Description = value.Description;
            context.SaveChanges();
        }

        // DELETE api/<TimeSlotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.TimeSlots.Remove(context.TimeSlots.Where(slot => slot.Id == id).SingleOrDefault());
        }


        //GET api/<TimeSlotController>/DayClassSchedule/5
        [HttpGet()]
        [Route("[action]/{id}")]
        public ActionResult<List<DayClassScheduleResponse>> DayClassSchedule(int? id)
        {

            return Ok(new DayClassScheduleRepo().GetDayClassSchedule((int)id));
        }
    }
}
