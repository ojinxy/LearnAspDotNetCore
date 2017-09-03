using System;
using System.Text;
using LearnAspDotNetCore.Api.Interfaces;
using Microsoft.Extensions.Logging;

namespace LearnAspDotNetCore.Api.Implementations
{
    public class ScrambleReverse : IScramble
    {
        private ILogger _logger;

        public ScrambleReverse(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("ScramblerReverse");
            _logger.LogInformation("ScramblerReverse Service Created.");
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
