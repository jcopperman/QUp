using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public interface IUserStoryRepository
    {
        IEnumerable<UserStory> GetUserStories();
        UserStory GetUserStoryByID(int userStoryId);
        void InsertUserStory(UserStory userstory);
        void DeleteUserStory(int userStoryId);
        bool UpdateUserStory(UserStory userStory);
        bool Save();
    }
}
