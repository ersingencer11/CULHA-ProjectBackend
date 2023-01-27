namespace CulhaAPI_MVC.API_Models.Request
{
    public class ClassScheduleResponse
    {
        public int ClassScheduleItemNo { get; set; }
        public string ClassroomCode { get; set; }
        public int CourseOfferedId { get; set; }
        public int Day { get; set; }
        public int Slot { get; set; }
    }
}
