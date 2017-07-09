using System;
using Xunit;

namespace LearnAspDotNetCoreTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Console.WriteLine("xUnit tests running.");
            Assert.True(true);
        }
    }
}
