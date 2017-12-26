using Moq;
using Patents.Controllers;
using Patents.Models;
using Patents.Models.Entities;
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
        public void EntitiesInventorTest()
        {
            Inventor inv = new Inventor
            {
                InventorId = 0,
                Name = "text",
                Adress = "Ref",
                Email = "em",
                Password = "123"
            };
            Assert.Equal(0, inv.GetPersonId());
        }

        [Fact]
        public void EntitiesMeetingTest()
        {
            Meeting meet = new Meeting
            {
                MeetingId = 0,
                Date = new System.DateTime(),
                Additions = "",
                InventorId = 0,
                Inventor = null,
                RegisterId  = 0,
                Register = null,
                StateId  = 0,
                State = null
            };
            Assert.Equal("0", meet.InventorId.ToString() + meet.Additions);
        }

        [Fact]
        public void EntitiesPatentTest()
        {
            Patent meet = new Patent
            {
                PatentId = 0,
                Sum = 16.00m,
                InventorId = 0,
                Inventor = null,
                RegisterId = 0,
                Register = null,
                StatementId = 0,
                Statement = null,
                IdeaId = 1,
                Idea = null
            };
            Assert.Equal("00", meet.InventorId.ToString() + meet.RegisterId);
        }

        [Fact]
        public void EntitiesPaymentTest()
        {
            Payment payment = new Payment
            {
                PaymentId = 0,
                Sum = 16.00m,
                InventorId = 0,
                Inventor = null,
                RegisterId = 0,
                Register = null,
                StateId = 0,
                State = null,
                Date = new System.DateTime()
            };
            Assert.Equal("00", payment.InventorId.ToString() + payment.RegisterId);
        }

        [Fact]
        public void EntitiesRegisterTest()
        {
            Register register = new Register
            {
                Name = "0",
                Password = "16.00m",
                RoleId = 0,
                Role = null,
                RegisterId = 0,
                Email = null
            };
            Assert.Equal(0, register.GetPersonId());
        }

        [Fact]
        public void EntitiesRoleTest()
        {
            Role role = new Role
            {
                UserRole = "0",
                RoleId = 0,
            };
            Assert.Equal("00", role.RoleId.ToString() + role.UserRole);
        }

        [Fact]
        public void EntitiesStateTest()
        {
            State state = new State
            {
                Info = "0",
                StateId = 0,
            };
            Assert.Equal("00", state.StateId.ToString() + state.Info);
        }

        [Fact]
        public void EntitiesStatementTest()
        {
            Statement statement = new Statement
            {
                ConsidDate = new System.DateTime(),
                SubmitDate = new System.DateTime(),
                StatementId = 0,
                Name = "0",
                DenialReason = "-",
                Text = "text",
                StateId = 0,
                State = null
            };
            Assert.Equal("00", statement.StateId.ToString() + statement.Name);
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
            InventorsController controller = new InventorsController(mock.Object, true);
            ViewResult result = controller.ShowAllData(true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void Inventors2Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            InventorsView view = new InventorsView { Id = "0", Adress = "adr", Email = "em", Name = "name"};
            ViewResult result = controller.FindByParams(view, true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void Inventors3Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            PartialViewResult result = controller.SearchingForm() as PartialViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void Inventors4Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            ViewResult result = controller.InventorsTable() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
