namespace CulhaAPI_MVC.API_Models.Response
{
    public class DayClassScheduleResponse
    {   
        public int Slot { get; set; }
        public string CourseName { get; set; }
        public string ClassroomCode { get; set; }
        public int SemesterCount { get; set; }
        public string DepartmentName { get; set; }
        public string AcademicianFullName { get; set; }
    }
}
