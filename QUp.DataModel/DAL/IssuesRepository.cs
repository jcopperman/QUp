using QUp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUp.DataModel.DAL
{
    public class IssuesRepository : IIssueRepository
    {
        IQUpContext context;

        public IssuesRepository(IQUpContext _context)
        {
            context = _context;
        }

        public IEnumerable<Issues> GetIssues()
        {
            return context.Issues.ToList();
        }

        public Issues GetIssueByID(int issueId)
        {
            return context.Issues.Find(issueId);
        }

        public void InsertIssue(Issues issue)
        {
            context.Issues.Add(issue);

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


        public bool IssueExists(int id)
        {
            return context.Issues.Count(e => e.Id == id) > 0;
        }

        public bool UpdateIssue(Issues _issue)
        {
            Issues issue = GetIssueByID(_issue.Id);
            issue = _issue;

            var result = Save();

            return result;
        }

        public void DeleteIssue(int issueId)
        {
            Issues issue = context.Issues.Find(issueId);
            context.Issues.Remove(issue);
        }
    }
}
