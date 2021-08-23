using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTestCaseProject.Models
{
    public class GitHubProject
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string Author { get; set; }
        public int Stargazers { get; set; }
        public int Watchers { get; set; }
        public string ProjectUrl { get; set; }
    }
}
