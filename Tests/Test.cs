using Patents.Models.Entities;
using Patents.Models.ViewModels;
using Xunit;

namespace Tests
{
    public static class Test
    {
        [Fact]
        public static void EntitiesIdeaTest()
        {
            var idea = new Idea
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
            var inv = new Inventor
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
            var meet = new Meeting
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
            Assert.Equal("0", meet.InventorId + meet.Additions);
        }

        [Fact]
        public static void EntitiesRegisterTest()
        {
            var register = new Register
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
            var role = new Role
            {
                UserRole = "0",
                RoleId = 0,
            };
            Assert.Equal("00", role.RoleId + role.UserRole);
        }

        [Fact]
        public static void EntitiesStateTest()
        {
            var state = new State
            {
                Info = "0",
                StateId = 0,
            };
            Assert.Equal("00", state.StateId + state.Info);
        }

        [Fact]
        public static void EntitiesStatementTest()
        {
            var statement = new Request
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
            Assert.Equal("00", statement.StateId + statement.Name);
        }

        /**************************************************************/

        [Fact]
        public static void InventorsViewTest()
        {
            var view = new InventorsView
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
            var view = new MeetingsView
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
            var view = new PatentsView
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
            var view = new RegistersView
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
