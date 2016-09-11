using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUp.Api.Controllers;
using QUp.Domain;
using System.Web.Http.Results;
using System.Net;

namespace QUp.Api.Tests.Tests
{
    [TestClass]
    public class TestProjectController
    {
        [TestMethod]
        public void PostProject_ShouldReturnSameProject()
        {
            var controller = new ProjectsController(new TestQUpContext());

            var item = GetDemoProject();

            var result =
                controller.PostProject(item) as CreatedAtRouteNegotiatedContentResult<Project>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Title, item.Title);
        }

        [TestMethod]
        public void PutProject_ShouldReturnStatusCode()
        {
            var controller = new ProjectsController(new TestQUpContext());

            var item = GetDemoProject();

            var result = controller.PutProject(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProject_ShouldFail_WhenDifferentID()
        {
            var controller = new ProjectsController(new TestQUpContext());

            var badresult = controller.PutProject(999, GetDemoProject());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProject_ShouldReturnProjectWithSameID()
        {
            var context = new TestQUpContext();
            context.Projects.Add(GetDemoProject());

            var controller = new ProjectsController(context);
            var result = controller.GetProject(3) as OkNegotiatedContentResult<Project>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetProjects_ShouldReturnAllProjects()
        {
            var context = new TestQUpContext();
            context.Projects.Add(new Project { Id = 1, Title = "Demo1" });
            context.Projects.Add(new Project { Id = 2, Title = "Demo2" });
            context.Projects.Add(new Project { Id = 3, Title = "Demo3" });

            var controller = new ProjectsController(context);
            var result = controller.GetProjects() as TestProjectDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteProject_ShouldReturnOK()
        {
            var context = new TestQUpContext();
            var item = GetDemoProject();
            context.Projects.Add(item);

            var controller = new ProjectsController(context);
            var result = controller.DeleteProject(3) as OkNegotiatedContentResult<Project>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Project GetDemoProject()
        {
            return new Project() { Id = 3, Title = "Demo name"};
        }
    }
}
