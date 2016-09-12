using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public interface IIssueRepository
    {
        IEnumerable<Issues> GetIssues();
        Issues GetIssueByID(int issueId);
        void InsertIssue(Issues issue);
        void DeleteIssue(int issueId);
        bool UpdateIssue(Issues issue);
        bool Save();
    }
}
