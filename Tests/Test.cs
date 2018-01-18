using Moq;
using Patents.Controllers;
using Patents.Models;
using Patents.Models.Entities;
using Patents.Models.Repositories;
using Patents.Models.TestInterfaces;
using Patents.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace Tests
{
    public class Test
    {

        [Fact]
        public static void EntitiesIdeaTest()
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
        public static void EntitiesInventorTest()
        {
            Inventor inv = new Inventor
            {
                InventorId = 0,
                FullName = "text",
                Adress = "Ref",
                Email = "em",
                Password = "123"
            };
            Assert.Equal(0, inv.GetPersonId());
        }

        [Fact]
        public static void EntitiesMeetingTest()
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
        public static void EntitiesPatentTest()
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
        public static void EntitiesPaymentTest()
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
        public static void EntitiesRegisterTest()
        {
            Register register = new Register
            {
                FullName = "0",
                Password = "16.00m",
                RoleId = 0,
                Role = null,
                RegisterId = 0,
                Email = null
            };
            Assert.Equal(0, register.GetPersonId());
        }

        [Fact]
        public static void EntitiesRoleTest()
        {
            Role role = new Role
            {
                UserRole = "0",
                RoleId = 0,
            };
            Assert.Equal("00", role.RoleId.ToString() + role.UserRole);
        }

        [Fact]
        public static void EntitiesStateTest()
        {
            State state = new State
            {
                Info = "0",
                StateId = 0,
            };
            Assert.Equal("00", state.StateId.ToString() + state.Info);
        }

        [Fact]
        public static void EntitiesStatementTest()
        {
            Request statement = new Request
            {
                ConsidDate = new System.DateTime(),
                SubmitDate = new System.DateTime(),
                RequestId = 0,
                Name = "0",
                DenialReason = "-",
                Text = "text",
                StateId = 0,
                State = null
            };
            Assert.Equal("00", statement.StateId.ToString() + statement.Name);
        }

        [Fact]
        public static void IndexTest()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void TestTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Test() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Inventors1Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            ViewResult result = controller.ShowAllData(true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Inventors2Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            InventorsView view = new InventorsView { Id = "0", Adress = "adr", Email = "em", Name = "name"};
            ViewResult result = controller.FindByParams(view, true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Inventors3Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            PartialViewResult result = controller.SearchingForm() as PartialViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Inventors4Test()
        {
            var mock = new Mock<IInventorsRepository>();
            mock.Setup(a => a.Inventors).Returns(new List<Inventor>());
            InventorsController controller = new InventorsController(mock.Object, true);
            ViewResult result = controller.InventorsTable() as ViewResult;
            Assert.NotNull(result);
        }

        //***************************************

        [Fact]
        public static void Meetings1Test()
        {
            var mock = new Mock<IMeetingsRepository>();
            mock.Setup(a => a.Meetings).Returns(new List<Meeting>());
            MeetingsController controller = new MeetingsController(mock.Object, true);
            ViewResult result = controller.ShowAllData(true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Meetings2Test()
        {
            var mock = new Mock<IMeetingsRepository>();
            mock.Setup(a => a.Meetings).Returns(new List<Meeting>());
            MeetingsController controller = new MeetingsController(mock.Object, true);
            MeetingsView view = new MeetingsView { InventorName = "name", Date = "-", RegisterName = "adr", State = "em"};
            ViewResult result = controller.FindByParams(view, true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Meetings3Test()
        {
            var mock = new Mock<IMeetingsRepository>();
            mock.Setup(a => a.Meetings).Returns(new List<Meeting>());
            MeetingsController controller = new MeetingsController(mock.Object, true);
            PartialViewResult result = controller.ShowAll() as PartialViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Meetings4Test()
        {
            var mock = new Mock<IMeetingsRepository>();
            mock.Setup(a => a.Meetings).Returns(new List<Meeting>());
            MeetingsController controller = new MeetingsController(mock.Object, true);
            ViewResult result = controller.MeetingsTable() as ViewResult;
            Assert.NotNull(result);
        }

        //***********************************************

        [Fact]
        public static void Patents1Test()
        {
            var mock = new Mock<IPatentsRepository>();
            mock.Setup(a => a.Patents).Returns(new List<Patent>());
            PatentsController controller = new PatentsController(mock.Object, true);
            ViewResult result = controller.ShowAllData(true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Patents2Test()
        {
            var mock = new Mock<IPatentsRepository>();
            mock.Setup(a => a.Patents).Returns(new List<Patent>());
            PatentsController controller = new PatentsController(mock.Object, true);
            PatentsView view = new PatentsView { InventorName = "name", InventorId = "-", PatentId = "adr", RegisterId = "em", RegisterName = "em", StatementState = "em", Sum = "em" };
            ViewResult result = controller.FindByParams(view, true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Patents3Test()
        {
            var mock = new Mock<IPatentsRepository>();
            mock.Setup(a => a.Patents).Returns(new List<Patent>());
            PatentsController controller = new PatentsController(mock.Object, true);
            PartialViewResult result = controller.SearchingForm() as PartialViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Patents4Test()
        {
            var mock = new Mock<IPatentsRepository>();
            mock.Setup(a => a.Patents).Returns(new List<Patent>());
            PatentsController controller = new PatentsController(mock.Object, true);
            ViewResult result = controller.PatentsTable() as ViewResult;
            Assert.NotNull(result);
        }

        //***********************************

        [Fact]
        public static void Registers1Test()
        {
            var mock = new Mock<IRegistersRepository>();
            mock.Setup(a => a.Registers).Returns(new List<Register>());
            RegistersController controller = new RegistersController(mock.Object, true);
            ViewResult result = controller.ShowAllData(true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Registers2Test()
        {
            var mock = new Mock<IRegistersRepository>();
            mock.Setup(a => a.Registers).Returns(new List<Register>());
            RegistersController controller = new RegistersController(mock.Object, true);
            RegistersView view = new RegistersView { Id = "0", Role = "adr", Email = "em", Name = "name" };
            ViewResult result = controller.FindByParams(view, true) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Registers3Test()
        {
            var mock = new Mock<IRegistersRepository>();
            mock.Setup(a => a.Registers).Returns(new List<Register>());
            RegistersController controller = new RegistersController(mock.Object, true);
            PartialViewResult result = controller.SearchingForm() as PartialViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void Registers4Test()
        {
            var mock = new Mock<IRegistersRepository>();
            mock.Setup(a => a.Registers).Returns(new List<Register>());
            RegistersController controller = new RegistersController(mock.Object, true);
            ViewResult result = controller.RegistersTable() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public static void InventorsViewTest()
        {
            InventorsView view = new InventorsView
            {
                Id = "0",
                Adress = "south",
                Email = "kfn@dkfm",
                Name = "djkfv"
            };
            Assert.Equal("south", view.Adress);
        }

        [Fact]
        public static void MeetingsViewTest()
        {
            MeetingsView view = new MeetingsView
            {
                Date = "0",
                InventorName = "south",
                RegisterName = "vm",
                State = "djkfv"
            };
            Assert.Equal("vm", view.RegisterName);
        }

        [Fact]
        public static void PatentsViewTest()
        {
            PatentsView view = new PatentsView
            {
                InventorId = "0",
                InventorName = "south",
                RegisterName = "vm",
                StatementState = "djkfv",
                PatentId = "dkgjv",
                RegisterId = "rg",
                Sum = "16.00m"
            };
            Assert.Equal("16.00m", view.Sum);
        }

        [Fact]
        public static void RegistersViewTest()
        {
            RegistersView view = new RegistersView
            {
                Id = "0",
                Name = "south",
                Email = "vm",
                Role = "djkfv"
            };
            Assert.Equal("djkfv", view.Role);
        }
    }
}
