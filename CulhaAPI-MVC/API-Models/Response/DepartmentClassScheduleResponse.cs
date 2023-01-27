namespace CulhaAPI_MVC.API_Models.Response
{
    public class DepartmentClassScheduleResponse
    {
        public int TimeSlotId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string ClassroomCode { get; set; }
        public int SemesterCount { get; set; }
        
    }
}
