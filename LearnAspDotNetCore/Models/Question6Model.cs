using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearnAspDotNetCore.Models
{
    public class Question6Model
    {
        public Question6Model()
        {
        }

        [DisplayName("Input :")]
        [Required]
        public String input { get; set; }

        [DisplayName("Scrambled Output :")]
        public String output { get; set; }
    }
}
