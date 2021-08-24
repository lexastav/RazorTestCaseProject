using System;
using System.Linq;
using RazorTestCaseProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RazorTestCaseProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorTestCaseProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorTestCaseProjectContext>>()))
            {
                // Look for any movies.
                if (context.GitHubProject.Any())
                {
                    return;   // DB has been seeded
                }

                context.GitHubProject.AddRange(
                    new GitHubProject
                    {
                        ProjectName = "PLACE",
                        Author = "sanweiliti",
                        Stargazers = 5,
                        Watchers = 32,
                        ProjectUrl = "https://github.com/sanweiliti/PLACE"

                    },

                    new GitHubProject
                    {
                        ProjectName = "kubescape",
                        Author = "armosec",
                        Stargazers = 4,
                        Watchers = 1000,
                        ProjectUrl = "https://github.com/armosec/kubescape"
                    },

                    new GitHubProject
                    {
                        ProjectName = "ToDo_project",
                        Author = "lexastav",
                        Stargazers = 0,
                        Watchers = 0,
                        ProjectUrl = "https://github.com/lexastav/ToDo_project"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
