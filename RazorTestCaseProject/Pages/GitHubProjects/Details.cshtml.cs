using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTestCaseProject.Data;
using RazorTestCaseProject.Models;

namespace RazorTestCaseProject.Pages.GitHubProjects
{
    public class DetailsModel : PageModel
    {
        private readonly RazorTestCaseProject.Data.RazorTestCaseProjectContext _context;

        public DetailsModel(RazorTestCaseProject.Data.RazorTestCaseProjectContext context)
        {
            _context = context;
        }

        public GitHubProject GitHubProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GitHubProject = await _context.GitHubProject.FirstOrDefaultAsync(m => m.ID == id);

            if (GitHubProject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
