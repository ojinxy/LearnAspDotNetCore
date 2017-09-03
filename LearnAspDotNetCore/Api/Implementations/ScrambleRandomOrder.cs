using System;
using System.Collections.Generic;
using System.Text;
using LearnAspDotNetCore.Api.Interfaces;
using Microsoft.Extensions.Logging;

namespace LearnAspDotNetCore.Api.Implementations
{
    public class ScrambleRandomOrder : IScramble
    {
        private ILogger _logger;
        public ScrambleRandomOrder(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("ScrambleRandomOrder");
            _logger.LogInformation("ScramblerRandom Service Created.");
        }

        public string scramble(string input)
        {
            StringBuilder workingVal = new StringBuilder(input);

            Random random = new Random();

            StringBuilder output = new StringBuilder();

            int length = workingVal.Length;

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, workingVal.Length - 1);

                output.Append(workingVal.ToString().ToCharArray()[index]);

                workingVal.Remove(index,1);
            }

            return output.ToString();

        }
    }
}
