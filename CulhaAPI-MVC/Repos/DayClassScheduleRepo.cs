using CulhaAPI_MVC.API_Models.Response;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class DayClassScheduleRepo
    {

        CulhaDbContext context = new CulhaDbContext();

        public List<DayClassScheduleResponse> GetDayClassSchedule(int id)
        {
            List<DayClassScheduleResponse> responseList = new List<DayClassScheduleResponse>();

            foreach (var item in context.TimeSlots.Where(ts => ts.Day == id).ToList())
            {
                foreach (var item2 in context.ClassSchedules.Where(classschedule => classschedule.TimeSlotId == item.Id).ToList())
                {

                    DayClassScheduleResponse dayClassScheduleResponse = new DayClassScheduleResponse();
                    dayClassScheduleResponse.Slot = item.Slot;
                    CourseOffered courseOffered = context.CourseOffereds.Where(courseOffered => courseOffered.Id == item2.CourseOfferedId).SingleOrDefault();
                    Academician academician = context.Academicians.Where(academician => academician.Id == courseOffered.AcademicianId).SingleOrDefault();
                    Department department = context.Departments.Where(department => department.DepartmentCode == courseOffered.DepartmentCode).SingleOrDefault();
                    Course course = context.Courses.Where(course => course.CourseCode == courseOffered.CourseCode).SingleOrDefault();


                    dayClassScheduleResponse.CourseName = course.CourseName;
                    dayClassScheduleResponse.ClassroomCode = item2.ClassroomCode;
                    dayClassScheduleResponse.SemesterCount = courseOffered.SemesterCount;
                    dayClassScheduleResponse.DepartmentName = department.Name;
                    dayClassScheduleResponse.AcademicianFullName = academician.FirstName + academician.LastName;

                    responseList.Add(dayClassScheduleResponse);
                }               
            }
            return responseList;
     
        }
    }
}
