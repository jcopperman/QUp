using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public class SprintRepository : ISprintRepository
    {
        IQUpContext context;

        public SprintRepository(IQUpContext _context)
        {
            context = _context;
        }

        public IEnumerable<Sprint> GetSprints()
        {
            return context.Sprints.ToList();
        }

        public Sprint GetSprintByID(int sprint)
        {
            return context.Sprints.Find(sprint);
        }

        public void InsertSprint(Sprint sprint)
        {
            context.Sprints.Add(sprint);

            Save();
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }


        public bool SprintExists(int id)
        {
            return context.Projects.Count(e => e.Id == id) > 0;
        }

        public bool UpdateSprint(Sprint _sprint)
        {
            Sprint sprint = GetSprintByID(_sprint.Id);
            sprint = _sprint;

            var result = Save();

            return result;
        }

        public void DeleteSprint(int sprintId)
        {
            Sprint sprint = context.Sprints.Find(sprintId);
            context.Sprints.Remove(sprint);
        }
    }
}
