using CulhaAPI_MVC.API_Models.Request;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class CourseConstraintRepo
    {

        public CulhaDbContext context = new CulhaDbContext();

        public void CourseConstraintInsert(CourseConstraintRequest req)
        {
            TimeSlot ts = context.TimeSlots.Where(timeSlot => timeSlot.Day == req.Day && timeSlot.Slot == req.Slot).SingleOrDefault();
            
            if (ts !=null)
            {
                CourseConstraint mappedEntity = new CourseConstraint();
                mappedEntity.CourseCode = req.CourseCode;
                mappedEntity.TimeSlotId = ts.Id;
                mappedEntity.Description = req.Description;
                context.CourseConstraints.Add(mappedEntity);
                context.SaveChanges();
            }

        }
    }
}
