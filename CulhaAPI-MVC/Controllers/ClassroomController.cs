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
    public class ClassroomController : ControllerBase
    {
        public CulhaDbContext context = new CulhaDbContext();
        // GET: api/<ClassroomController>
        [HttpGet]
        public IEnumerable<Classroom> Get()
        {
                return context.Classrooms.ToList();
        }

        // GET api/<ClassroomController>/5
        [HttpGet("{id}")]
        public IEnumerable<Classroom> Get(string id)
        {
                return context.Classrooms.Where(classroom => classroom.ClassroomCode == id).ToList();
        }

        
        // POST api/<ClassroomController>
        [HttpPost]
        public void Post([FromBody] Classroom value)
        {
                context.Classrooms.Add(value);
                context.SaveChanges();
        }

        // PUT api/<ClassroomController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Classroom value)
        {
                context.Classrooms.Where(classroom => classroom.ClassroomCode == id).SingleOrDefault().ClassCapacity = value.ClassCapacity;
                context.Classrooms.Where(Classroom => Classroom.ClassroomCode == id).SingleOrDefault().IsEnabled = value.IsEnabled;
                context.Classrooms.Where(classroom => classroom.ClassroomCode == id).SingleOrDefault().ExamCapacity = value.ExamCapacity;
                context.Classrooms.Where(classroom => classroom.ClassroomCode == id).SingleOrDefault().CampusId = value.CampusId;
                context.Classrooms.Where(Classroom => Classroom.ClassroomCode == id).SingleOrDefault().Building = value.Building;
                context.Classrooms.Where(classroom => classroom.ClassroomCode == id).SingleOrDefault().Type = value.Type;

                context.SaveChanges();       
        }

        // DELETE api/<ClassroomController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
                context.Classrooms.Remove(context.Classrooms.Where(classroom => classroom.ClassroomCode == id).SingleOrDefault());
                context.SaveChanges();
        }

        //GET api/<ClassroomController>/ClassroomClassSchedule/5
        [HttpGet()]
        [Route("[action]/{id}")]
        public ActionResult<List<ClassroomClassScheduleResponse>> ClassroomClassSchedule(string? id)
        {
            return Ok(new ClassroomClassScheduleRepo().GetClassroomClassSchedule(id));
        }

        //GET api/<ClassroomController>/ClassroomCapacity/60/bigger
        [HttpGet()]
        [Route("[action]/{capacity}/{type}")]
        public ActionResult<List<Classroom>> ClassroomCapacity(int capacity, string type)
        {
            if (type.SequenceEqual("bigger"))
            {
                List<Classroom> classrooms = context.Classrooms.Where(classroom => classroom.ClassCapacity >= capacity && classroom.Type=="DERSLİK" || classroom.Type=="Amfi").ToList();
                List<ClassroomConstraintsResponse> responseList = new List<ClassroomConstraintsResponse>(); 


                foreach (var item in classrooms)
                {

                    if (context.ClassroomConstraints.Where(classroomConstraint => classroomConstraint.ClassroomCode == item.ClassroomCode).ToList().Count!=0)
                    {
                        foreach (var item2 in context.ClassroomConstraints.Where(classroomConstraint => classroomConstraint.ClassroomCode == item.ClassroomCode).ToList())
                        {
                            ClassroomConstraintsResponse classroomConstraintsResponse = new ClassroomConstraintsResponse();
                            classroomConstraintsResponse.ClassCapacity = item.ClassCapacity;
                            classroomConstraintsResponse.IsEnabled = item.IsEnabled;
                            classroomConstraintsResponse.ExamCapacity = item.ExamCapacity;
                            classroomConstraintsResponse.CampusId = (int)item.CampusId;
                            classroomConstraintsResponse.ClassroomCode = item.ClassroomCode;
                            classroomConstraintsResponse.Building = item.Building;
                            classroomConstraintsResponse.Type = item.Type;
                            classroomConstraintsResponse.TimeSlotId = (int)item2.TimeSlotId;
                            responseList.Add(classroomConstraintsResponse);
                        }
                    }
                    else
                    {
                        ClassroomConstraintsResponse classroomConstraintsResponse = new ClassroomConstraintsResponse();
                        classroomConstraintsResponse.ClassCapacity = item.ClassCapacity;
                        classroomConstraintsResponse.IsEnabled = item.IsEnabled;
                        classroomConstraintsResponse.ExamCapacity = item.ExamCapacity;
                        classroomConstraintsResponse.CampusId = (int)item.CampusId;
                        classroomConstraintsResponse.ClassroomCode = item.ClassroomCode;
                        classroomConstraintsResponse.Building = item.Building;
                        classroomConstraintsResponse.Type = item.Type;
                        classroomConstraintsResponse.TimeSlotId = null;
                        responseList.Add(classroomConstraintsResponse);
                    }
                    
                }
                return Ok(responseList);
            }
            else
            {
                List<Classroom> classrooms = context.Classrooms.Where(classroom => classroom.ClassCapacity < capacity && classroom.Type == "DERSLİK").ToList();
                List<ClassroomConstraintsResponse> responseList = new List<ClassroomConstraintsResponse>();


                foreach (var item in classrooms)
                {

                    if (context.ClassroomConstraints.Where(classroomConstraint => classroomConstraint.ClassroomCode == item.ClassroomCode).ToList().Count != 0)
                    {
                        foreach (var item2 in context.ClassroomConstraints.Where(classroomConstraint => classroomConstraint.ClassroomCode == item.ClassroomCode).ToList())
                        {
                            ClassroomConstraintsResponse classroomConstraintsResponse = new ClassroomConstraintsResponse();
                            classroomConstraintsResponse.ClassCapacity = item.ClassCapacity;
                            classroomConstraintsResponse.IsEnabled = item.IsEnabled;
                            classroomConstraintsResponse.ExamCapacity = item.ExamCapacity;
                            classroomConstraintsResponse.CampusId = (int)item.CampusId;
                            classroomConstraintsResponse.ClassroomCode = item.ClassroomCode;
                            classroomConstraintsResponse.Building = item.Building;
                            classroomConstraintsResponse.Type = item.Type;
                            classroomConstraintsResponse.TimeSlotId = (int)item2.TimeSlotId;
                            responseList.Add(classroomConstraintsResponse);
                        }
                    }
                    else
                    {
                        ClassroomConstraintsResponse classroomConstraintsResponse = new ClassroomConstraintsResponse();
                        classroomConstraintsResponse.ClassCapacity = item.ClassCapacity;
                        classroomConstraintsResponse.IsEnabled = item.IsEnabled;
                        classroomConstraintsResponse.ExamCapacity = item.ExamCapacity;
                        classroomConstraintsResponse.CampusId = (int)item.CampusId;
                        classroomConstraintsResponse.ClassroomCode = item.ClassroomCode;
                        classroomConstraintsResponse.Building = item.Building;
                        classroomConstraintsResponse.Type = item.Type;
                        classroomConstraintsResponse.TimeSlotId = null;
                        responseList.Add(classroomConstraintsResponse);
                    }

                }
                return Ok(responseList);
            }


        }


    }
}
