using System;
using System.Text;
using LearnAspDotNetCore.Api.Interfaces;

namespace LearnAspDotNetCore.Api.Implementations
{
    public class ScrambleReverse : IScramble
    {
        public ScrambleReverse()
        {
        }

        public string scramble(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] array = input.ToCharArray();
            for (int i = array.Length; i > 0; i--)
            {
                sb.Append(array[i - 1]);
            }

            return sb.ToString();
        }
    }
}
