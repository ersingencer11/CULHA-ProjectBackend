namespace CulhaAPI_MVC.API_Models.Request
{
    public class ClassroomConstraintRequest
    {
        public string Description { get; set; }
        public string ClassroomCode { get; set; }
        public int Day { get; set; }
        public int Slot { get; set; }
    }
}
