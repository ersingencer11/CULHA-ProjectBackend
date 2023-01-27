using CulhaAPI_MVC.API_Models.Response;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class ClassroomClassScheduleRepo
    {
        CulhaDbContext context = new CulhaDbContext();

        public List<ClassroomClassScheduleResponse> GetClassroomClassSchedule(string classroomCode)
        {
            Classroom classroom = context.Classrooms.Where(classroom => classroom.ClassroomCode == classroomCode).SingleOrDefault();

            List<ClassroomClassScheduleResponse> responseList = new List<ClassroomClassScheduleResponse>();

            List<ClassSchedule> classroomClassSchedules = new List<ClassSchedule>();
            foreach(var item in context.ClassSchedules.Where(classschedule => classschedule.ClassroomCode == classroomCode).ToList())
            {
                classroomClassSchedules.Add(item);
            }

            foreach (var item in classroomClassSchedules)
            {
                CourseOffered courseOffered = context.CourseOffereds.Where(courseoffered => courseoffered.Id == item.CourseOfferedId).SingleOrDefault();
                Academician academician = context.Academicians.Where(academician => academician.Id == courseOffered.AcademicianId).SingleOrDefault();
                TimeSlot ts = context.TimeSlots.Where(timeslot=>timeslot.Id==item.TimeSlotId).SingleOrDefault();
                Course course = context.Courses.Where(course => course.CourseCode == courseOffered.CourseCode).SingleOrDefault();

                ClassroomClassScheduleResponse classroomClassScheduleResponse = new ClassroomClassScheduleResponse();

                classroomClassScheduleResponse.TimeDescription = ts.Description;
                classroomClassScheduleResponse.Slot = ts.Slot;
                classroomClassScheduleResponse.CourseName = courseOffered.CourseCode;
                classroomClassScheduleResponse.SemesterCount = courseOffered.SemesterCount;
                classroomClassScheduleResponse.AcademicianFullName = academician.FirstName + academician.LastName;

                responseList.Add(classroomClassScheduleResponse);
            }

            return responseList;
        }
    }
}
