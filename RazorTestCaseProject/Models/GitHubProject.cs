using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTestCaseProject.Models
{
    public class GitHubProject
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string ProjectName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Author { get; set; }
        [Range(0, 5)]
        public int Stargazers { get; set; }
        [Range(0, 1000000000)]
        public int Watchers { get; set; }
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        //[StringLength(60, MinimumLength = 22)]
        //[Required]
        public string ProjectUrl { get; set; }
    }
}
