using Moq;
using Patents.Controllers;
using Patents.Models;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
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
            Assert.Equal("Reftext", idea.References + idea.Text);
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
        [Fact]
        public void Inventors1Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object);
            ViewResult result = controller.ShowAllData(true) as ViewResult;
            Assert.NotNull(result);
        }
        [Fact]
        public void Inventors2Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object);
            InventorsView view = new InventorsView { Id = "0", Adress = "adr", Email = "em", Name = "name"};
            ViewResult result = controller.FindByParams(view, true) as ViewResult;
            Assert.NotNull(result);
        }
        [Fact]
        public void Inventors3Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object);
            PartialViewResult result = controller.SearchingForm() as PartialViewResult;
            Assert.NotNull(result);
        }
        [Fact]
        public void Inventors4Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object);
            ViewResult result = controller.InventorsTable() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
