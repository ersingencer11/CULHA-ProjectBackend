using CulhaAPI_MVC.API_Models.Response;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class AcademicianClassScheduleRepo
    {

        CulhaDbContext context = new CulhaDbContext();

        public List<AcademicianClassScheduleResponse> GetAcademicianClassSchedule(int id)
        {
            Academician academician = context.Academicians.Where(academician=>academician.Id==id).SingleOrDefault();
            List<AcademicianClassScheduleResponse> responseList = new List<AcademicianClassScheduleResponse>();

            foreach (var item in context.CourseOffereds.Where(courseOffered => courseOffered.AcademicianId == academician.Id).ToList())
            {
                List<ClassSchedule> classSchedules = context.ClassSchedules.Where(classSchedule=>classSchedule.CourseOfferedId==item.Id).ToList();

                foreach (var classSchedule in classSchedules)
                {
                    AcademicianClassScheduleResponse academicianClassScheduleResponse = new AcademicianClassScheduleResponse();
                    Course course = context.Courses.Where(course=>course.CourseCode==item.CourseCode).SingleOrDefault();

                    
                    academicianClassScheduleResponse.TimeSlotId = classSchedule.TimeSlotId;
                    academicianClassScheduleResponse.CourseName = course.CourseName;
                    academicianClassScheduleResponse.ClassroomCode = classSchedule.ClassroomCode;
                    academicianClassScheduleResponse.SemesterCount = item.SemesterCount;
                    academicianClassScheduleResponse.CourseCode = course.CourseCode;
                    academicianClassScheduleResponse.AcademicianId = academician.Id;
                    

                    responseList.Add(academicianClassScheduleResponse);
                }
            }
            return responseList;
        }


        public List<AcademicianClassScheduleResponse> GetAllAcademicianClassSchedule()
        {
            List<Academician> academicians = context.Academicians.ToList();
            List<AcademicianClassScheduleResponse> responseList = new List<AcademicianClassScheduleResponse>();

            foreach (var academician in academicians)
            {
                foreach (var item in context.CourseOffereds.Where(courseOffered => courseOffered.AcademicianId == academician.Id).ToList())
                {
                    List<ClassSchedule> classSchedules = context.ClassSchedules.Where(classSchedule => classSchedule.CourseOfferedId == item.Id).ToList();

                    foreach (var classSchedule in classSchedules)
                    {
                        AcademicianClassScheduleResponse academicianClassScheduleResponse = new AcademicianClassScheduleResponse();
                        Course course = context.Courses.Where(course => course.CourseCode == item.CourseCode).SingleOrDefault();


                        academicianClassScheduleResponse.TimeSlotId = classSchedule.TimeSlotId;
                        academicianClassScheduleResponse.CourseName = course.CourseName;
                        academicianClassScheduleResponse.ClassroomCode = classSchedule.ClassroomCode;
                        academicianClassScheduleResponse.SemesterCount = item.SemesterCount;
                        academicianClassScheduleResponse.CourseCode = course.CourseCode;
                        academicianClassScheduleResponse.AcademicianId = academician.Id;


                        responseList.Add(academicianClassScheduleResponse);
                    }
                }
            }
            
            return responseList;
        }




    }
}
