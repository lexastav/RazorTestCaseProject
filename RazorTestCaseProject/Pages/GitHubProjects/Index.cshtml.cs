using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTestCaseProject.Data;
using RazorTestCaseProject.Models;

namespace RazorTestCaseProject.Pages.GitHubProjects
{
    public class IndexModel : PageModel
    {
        private readonly RazorTestCaseProject.Data.RazorTestCaseProjectContext _context;

        public IndexModel(RazorTestCaseProject.Data.RazorTestCaseProjectContext context)
        {
            _context = context;
        }

        public IList<GitHubProject> GitHubProject { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Authors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GitHubProjectAuthor { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> authorQuery = from m in _context.GitHubProject
                                            orderby m.Author
                                            select m.Author;
            var gitHubProjects = from m in _context.GitHubProject select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                gitHubProjects = gitHubProjects.Where(s => s.ProjectName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(GitHubProjectAuthor))
            {
                gitHubProjects = gitHubProjects.Where(x => x.Author == GitHubProjectAuthor);
            }
            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            GitHubProject = await gitHubProjects.ToListAsync();
        }
    }
}
