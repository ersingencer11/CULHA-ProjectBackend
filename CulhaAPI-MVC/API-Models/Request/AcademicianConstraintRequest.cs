using CulhaAPI_MVC.Controllers;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.API_Models.Request
{
    public class AcademicianConstraintRequest
    {
        public int AcademicianId { get; set; }
        public int TimeSlotId { get; set; }
        public string Description { get; set; }
    }
}
