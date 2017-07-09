using System;
using Xunit;
using LearnAspDotNetCore.Controllers;
using System.Threading.Tasks;

namespace LearnAspDotNetCoreTest.Controllers
{
    public class HomeControllerTest
    {
        private HomeController homeController;

        public HomeControllerTest()
        {
            homeController = new HomeController();
        }

        [Theory]
        [InlineData("Apple")]
        [InlineData("Bowl")]
        public void LengthOfStringTest(String value)
        {
            Console.WriteLine("xUnit tests running in HomeControllerTest.");
            Assert.Equal(value.Length, homeController.LengthOfString(value));

        }


    }
}
