namespace CulhaAPI_MVC.API_Models.Response
{
    public class ClassroomClassScheduleResponse
    {
        public string TimeDescription { get; set; }
        public int Slot { get; set; }
        public string CourseName { get; set; }
        public int SemesterCount { get; set; }
        public string AcademicianFullName { get; set; }
    }
}
