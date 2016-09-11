using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public interface ISprintRepository
    {
        IEnumerable<Sprint> GetSprints();
        Sprint GetSprintByID(int sprintId);
        void InsertSprint(Sprint sprint);
        void DeleteSprint(int sprintId);
        bool UpdateSprint(Sprint sprint);
        bool Save();
    }
}
