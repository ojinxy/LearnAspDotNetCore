using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LearnAspDotNetCore.Models
{
    public class Question5Model
    {
        [DisplayName("Expontial Value :")]
        public UInt64 question
        {
            get;
            set;
    
        }

        [DisplayName("Expontial Answer :")]
        public UInt64 answer
        {
            get;
            set;
        }

        [DisplayName("Duration (MiliSeconds) :")]
        public int duration
        {
            get;
            set;
        }

        public List<Question5Result> question5Results = new List<Question5Result>();

        public Question5Model()
        {
            question5Results = new List<Question5Result>();
        }
    }
}
