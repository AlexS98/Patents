using Moq;
using Patents.Controllers;
using Patents.Models;
using Patents.Models.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void EntitiesIdeaTest()
        {
            Idea idea = new Idea
            {
                IdeaId = 0,
                Text = "text",
                References = "Ref"
            };
            Assert.Equal(0, idea.IdeaId);
            Assert.Equal("Ref", idea.References);
        }
        [Fact]
        public void IndexTest()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }
        [Fact]
        public void TestTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Test() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
