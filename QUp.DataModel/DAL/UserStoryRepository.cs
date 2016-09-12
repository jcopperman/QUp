using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public class UserStoryRepository : IUserStoryRepository
    {
        IQUpContext context;

        public UserStoryRepository(IQUpContext _context)
        {
            context = _context;
        }

        public IEnumerable<UserStory> GetUserStories()
        {
            return context.Stories.ToList();
        }

        public UserStory GetUserStoryByID(int userStoryId)
        {
            return context.Stories.Find(userStoryId);
        }

        public void InsertUserStory(UserStory userStory)
        {
            context.Stories.Add(userStory);

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


        public bool UserStoryExists(int id)
        {
            return context.Stories.Count(e => e.Id == id) > 0;
        }

        public bool UpdateUserStory(UserStory _userstory)
        {
            UserStory userstory = GetUserStoryByID(_userstory.Id);
            userstory = _userstory;

            var result = Save();

            return result;
        }

        public void DeleteUserStory(int userStoryId)
        {
            UserStory userstory = context.Stories.Find(userStoryId);
            context.Stories.Remove(userstory);
        }
    }
}
