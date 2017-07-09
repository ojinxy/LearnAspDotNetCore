using System.Collections.Generic;
using System.Linq;
using LearnAspDotNetCore.Data;
using LearnAspDotNetCore.Models;
using LearnAspDotNetCore.Controllers;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System;
using LearnAspDotNetCoreTest.Tools;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LearnAspDotNetCoreTest.Controllers
{
    public class QuestionControllerTest
    {
        public QuestionControllerTest()
        {
        }

        [Fact]
        public void TestQuestions_Day_1()
        {
            var dbContextTest = new LearnAspDotNetCoreContext();

            var testObjectMock = MockingTools.GetMockDbSet<Test>(this.GenerateTestObjects());

            dbContextTest.Test = testObjectMock;

            QuestionController questionController = new QuestionController(dbContextTest);

            var result = questionController.Questions_Day_1();

            var viewResult = Assert.IsType<ViewResult>(result);
            Console.WriteLine("Checking View Name - " + viewResult.ViewName);
            Console.WriteLine(viewResult.ViewName);
            var model = Assert.IsAssignableFrom<TestComposite>(
                viewResult.ViewData.Model);

            Assert.Equal(2, model.tests.Count());

            Assert.Equal("Test 1", model.tests[0].Title);


        }

        [Fact]
        private async void Test_Questions_Day_1_q1()
        {
            var dbContextMoq = new Mock<LearnAspDotNetCoreContext>();

            //Mock Save Changes Async being called on 
            dbContextMoq.Setup(moq => moq.SaveChangesAsync(It.IsAny<CancellationToken>()))
                         .Returns(Task.FromResult(It.IsAny<int>())).Verifiable();



            String testString = "Second Fake Test";

            var fakeTest = new Test()
            {
                Title = testString
            };

            var fakeTestComp = new TestComposite()
            {
                test = fakeTest
            };

            var mockTestDbSet = MockingTools.GetMockDbSetOrginal<Test>(new Test()
            {
                Title = "First Fake Test"
            });

            //Mock Add function for TestDbSet
            mockTestDbSet.Setup(moq => moq.Add(It.IsAny<Test>()))
                         .Returns(It.IsAny<EntityEntry<Test>>()).Verifiable();

            //dbContextMoq.Setup(moq => moq.Test).Returns(mockTestDbSet.Object);

            dbContextMoq.Object.Test = mockTestDbSet.Object;

            //inject mock dbcontext
            var questController = new QuestionController(dbContextMoq.Object);

            //Wait until controller is finished doing function
            var result = await questController.Questions_Day_1_q1(fakeTestComp);

            //Asserts
            var redirectAction = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Questions_Day_1", redirectAction.ActionName);

            //Verify that all mocked functions were called
            mockTestDbSet.Verify();
            dbContextMoq.Verify();


        }

        private List<Test> GenerateTestObjects()
        {
            var tests = new List<Test>();

            tests.Add(new Test()
            {
                Title = "Test 1"
            });

            tests.Add(new Test()
            {
                Title = "Test 2"
            });

            return tests;
        }
    }
}
