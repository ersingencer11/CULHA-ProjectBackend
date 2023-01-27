using CulhaAPI_MVC.API_Models.Response;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class DepartmentClassScheduleRepo
    {
        CulhaDbContext context = new CulhaDbContext();

        public List<DepartmentClassScheduleResponse> GetDepartmentClassSchedule(string departmentCode)
        {
            List<DepartmentClassScheduleResponse> responseList = new List<DepartmentClassScheduleResponse>();
            
            List<CourseOffered> departmentCoursesOffered = new List<CourseOffered>();
            
            foreach (var item in context.CourseOffereds.Where(courseoffered => courseoffered.DepartmentCode == departmentCode).ToList())
            {
                departmentCoursesOffered.Add(item);    
            }

            /*if (coursesOffered != null)
            {*/

                foreach (var courseoffered in departmentCoursesOffered)
                {
                    foreach (var item in context.ClassSchedules.Where(classSchedule => classSchedule.CourseOfferedId == courseoffered.Id).ToList())
                    {
                        Course course = context.Courses.Where(course => course.CourseCode == courseoffered.CourseCode).SingleOrDefault();
                        DepartmentClassScheduleResponse departmentClassSchedule = new DepartmentClassScheduleResponse();

                        departmentClassSchedule.TimeSlotId = (int)item.TimeSlotId;
                        departmentClassSchedule.CourseCode = course.CourseCode;
                        departmentClassSchedule.CourseName = course.CourseName;
                        departmentClassSchedule.ClassroomCode = item.ClassroomCode;
                        departmentClassSchedule.SemesterCount = courseoffered.SemesterCount;
                        
                        
                   
                        responseList.Add(departmentClassSchedule);
                    } 
                }
            return responseList;
            


            

            

        }

    }
}
