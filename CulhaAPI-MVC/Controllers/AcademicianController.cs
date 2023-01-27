using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Repository;
using DataLayer.Repository.Models;
using CulhaAPI_MVC.API_Models.Response;
using CulhaAPI_MVC.Repos;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CulhaAPI_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="admin")]
    public class AcademicianController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();

        // GET: api/<AcademicianController>
        [HttpGet]
        public IEnumerable<Academician> Get()
        {
                return context.Academicians.ToList();
        }

        // GET api/<AcademicianController>/5
        [HttpGet("{id}")]
        public IEnumerable<Academician> Get(int id)
        {
                return context.Academicians.Where(academician=>academician.Id==id).ToList();
        }

        // POST api/<AcademicianController>
        [HttpPost]
        public void Post([FromBody]Academician academician)
        {
                context.Academicians.Add(academician);
                context.SaveChanges();
        }

        // PUT api/<AcademicianController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Academician academician)
        {
                context.Academicians.Where(academician => academician.Id == id).SingleOrDefault().IsAssistant = academician.IsAssistant;
                context.Academicians.Where(academician => academician.Id == id).SingleOrDefault().FirstName=academician.FirstName;
                context.Academicians.Where(academician => academician.Id == id).SingleOrDefault().LastName = academician.LastName;
                context.Academicians.Where(academician => academician.Id == id).SingleOrDefault().Email = academician.Email;
                context.Academicians.Where(academician => academician.Id == id).SingleOrDefault().Title = academician.Title;
                context.Academicians.Where(academician => academician.Id == id).SingleOrDefault().IdentityNo = academician.IdentityNo;

                context.SaveChanges();
        }

        // DELETE api/<AcademicianController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
                context.Academicians.Remove(context.Academicians.Where(academician => academician.Id == id).SingleOrDefault());
                context.SaveChanges();       
        }


        //GET api/<AcademicianController>/AcademicianClassSchedule/5
        [HttpGet()]
        [Route("[action]/{id}")]
        public ActionResult<List<AcademicianClassScheduleResponse>> AcademicianClassSchedule(int? id)
        {

            return Ok(new AcademicianClassScheduleRepo().GetAcademicianClassSchedule((int)id));
        }


        //GET api/<AcademicianController>/AcademicianClassSchedule
        [HttpGet()]
        [Route("[action]")]
        public ActionResult<List<AcademicianClassScheduleResponse>> AllAcademicianClassSchedule()
        {

            return Ok(new AcademicianClassScheduleRepo().GetAllAcademicianClassSchedule());
        }
    }
}
