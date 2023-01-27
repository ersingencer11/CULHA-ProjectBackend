namespace CulhaAPI_MVC.API_Models.Request
{
    public class CourseConstraintRequest
    {
        public string Description { get; set; }
        public string CourseCode { get; set; }
        public int Day { get; set; }
        public int Slot { get; set; }
    }
}
