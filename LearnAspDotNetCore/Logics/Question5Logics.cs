using System;
using System.Threading;

namespace LearnAspDotNetCore.Logics
{
    public class Question5Logics
    {
        public UInt64 value
        {
            get;
            set;
        }

        public Question5Logics(UInt64 value)
        {
            this.value = value;
        }

        public UInt64 getAnswerFromLoop()
        {
            UInt64 answer = value;

            UInt64 index = value - 1;

            while (index > 0)
            {
                answer *= index;

                index -= 1;
                Thread.Sleep(10);
            }

            return answer;
        }

        public UInt64 getAnswerFromRecursive()
        {

            return calculateAnswerFromRecursive(value - 1, value);
        }

        private UInt64 calculateAnswerFromRecursive(UInt64 index, UInt64 recursiveValue)
        {
            if (index > 1)
            {
                return index * calculateAnswerFromRecursive(index - 1, recursiveValue);
            }
            else
            {
                return recursiveValue;
            }
        }

    }
}
