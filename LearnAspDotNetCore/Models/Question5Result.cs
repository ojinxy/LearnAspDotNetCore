using System;
namespace LearnAspDotNetCore.Models
{
    public class Question5Result
    {
        public String threadId
        {
            get;
            set;
        }

        public UInt64 answer
        {
            get;
            set;
     
        }

        public String solutionType
        {
            get;
            set;
        }

        public Question5Result(String threadId, UInt64 answer, String solutionType)
        {
            this.answer = answer;
            this.solutionType = solutionType;
            this.threadId = threadId;
        }
    }
}
