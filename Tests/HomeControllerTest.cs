using Patents.Controllers;
using System.Web.Mvc;
using Xunit;

namespace Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Test() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
