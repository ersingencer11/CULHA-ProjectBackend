using CulhaAPI_MVC.API_Models.Request;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class ClassroomConstraintRepo
    {
        CulhaDbContext context = new CulhaDbContext();

        public void ClassroomConstraintInsert(ClassroomConstraintRequest req)
        {
            TimeSlot ts = context.TimeSlots.Where(timeSlot => timeSlot.Day == req.Day && timeSlot.Slot == req.Slot).SingleOrDefault();

            if(ts != null)
            {
                ClassroomConstraint mappedEntity = new ClassroomConstraint();
                mappedEntity.ClassroomCode = req.ClassroomCode;
                mappedEntity.TimeSlotId = ts.Id;
                mappedEntity.Description = req.Description;
                context.ClassroomConstraints.Add(mappedEntity);
                context.SaveChanges();
            }
        }

    }
}
