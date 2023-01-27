using CulhaAPI_MVC.API_Models.Request;
using CulhaAPI_MVC.Controllers;
using DataLayer.Repository;
using DataLayer.Repository.Models;

namespace CulhaAPI_MVC.Repos
{
    public class AcademicianConstraintRepo
    {
        public CulhaDbContext context = new CulhaDbContext();
        public void AcademicianConstraintInsert(List<AcademicianConstraintRequest> req)
        {
            for (int i = 0; i <req.Count; i++)
            {
                TimeSlot ts = context.TimeSlots.Where(timeSlot => timeSlot.Id == req[i].TimeSlotId).SingleOrDefault();

                if (ts != null)
                {
                    AcademicianConstraint mappedEntity = new AcademicianConstraint();
                    mappedEntity.AcademicianId = req[i].AcademicianId;
                    mappedEntity.TimeSlotId = ts.Id;
                    mappedEntity.Description = req[i].Description;
                    context.AcademicianConstraints.Add(mappedEntity);
                    context.SaveChanges();

                }
            }

            
            
        }
    }
}
