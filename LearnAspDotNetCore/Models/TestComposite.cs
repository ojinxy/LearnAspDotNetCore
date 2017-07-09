using System;
using System.Collections.Generic;

namespace LearnAspDotNetCore.Models
{
    public class TestComposite
    {
        public Test test { get; set; }
        public List<Test> tests { get; set; }

        public TestComposite()
        {
            test = new Test();
            tests = new List<Test>();
        }
    }
}
