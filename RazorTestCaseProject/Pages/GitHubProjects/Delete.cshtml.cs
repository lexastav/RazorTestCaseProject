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
    public class DeleteModel : PageModel
    {
        private readonly RazorTestCaseProject.Data.RazorTestCaseProjectContext _context;

        public DeleteModel(RazorTestCaseProject.Data.RazorTestCaseProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GitHubProject = await _context.GitHubProject.FindAsync(id);

            if (GitHubProject != null)
            {
                _context.GitHubProject.Remove(GitHubProject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
