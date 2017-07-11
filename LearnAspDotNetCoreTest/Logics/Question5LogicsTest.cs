using System;
using LearnAspDotNetCore.Logics;
using Xunit;

namespace LearnAspDotNetCoreTest.Logics24
{
    public class Question5LogicsTest
    {
        enum TESTVALUES : int { TEST1 = 4, TEST2 = 7, ANSWER1 = 24, ANSWER2 = 5040 };
        public Question5LogicsTest()
        {
        }

        [Theory]
        [InlineData((int)TESTVALUES.TEST1)]
        [InlineData((int)TESTVALUES.TEST2)]
        public void testFactorialLoop(int value)
        {
            Question5Logics q5Logics = new Question5Logics(value);

            if (value == (int)TESTVALUES.TEST1)
            {
                Assert.Equal((int)TESTVALUES.ANSWER1, q5Logics.getAnswerFromLoop());
            }
            else if (value == (int)TESTVALUES.TEST2)
            {
                Assert.Equal((int)TESTVALUES.ANSWER2, q5Logics.getAnswerFromLoop());
            }
        }

        [Theory]
        [InlineData((int)TESTVALUES.TEST1)]
        [InlineData((int)TESTVALUES.TEST2)]
        public void testRecursive(int value)
        {
            Question5Logics q5Logics = new Question5Logics(value);

			if (value == (int)TESTVALUES.TEST1)
			{
                Assert.Equal((int)TESTVALUES.ANSWER1, q5Logics.getAnswerFromRecursive());
			}
			else if (value == (int)TESTVALUES.TEST2)
			{
				Assert.Equal((int)TESTVALUES.ANSWER2, q5Logics.getAnswerFromRecursive());
			}

        }
    }
}
