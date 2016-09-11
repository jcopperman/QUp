using QUp.Domain;
using System;
using System.Linq;


namespace QUp.Api.Tests
{
    class TestProjectDbSet : TestDbSet<Project>
    {
        public override Project Find(params object[] keyValues)
        {
            return this.SingleOrDefault(project => project.Id == (int)keyValues.Single());
        }
    }
}
