namespace CulhaAPI_MVC.API_Models.Response
{
    public class ClassroomConstraintsResponse
    {
        public int ClassCapacity { get; set; }
        public Boolean IsEnabled { get; set; }
        public int ExamCapacity { get; set; }
        public int CampusId { get; set; }
        public string ClassroomCode { get; set; }
        public string Building { get; set; }
        public string Type { get; set; }
        public int? TimeSlotId { get; set; }


    }
}
    