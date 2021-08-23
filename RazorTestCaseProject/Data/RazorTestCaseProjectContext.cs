using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorTestCaseProject.Models;

namespace RazorTestCaseProject.Data
{
    public class RazorTestCaseProjectContext : DbContext
    {
        public RazorTestCaseProjectContext (DbContextOptions<RazorTestCaseProjectContext> options)
            : base(options)
        {
        }

        public DbSet<RazorTestCaseProject.Models.GitHubProject> GitHubProject { get; set; }
    }
}
