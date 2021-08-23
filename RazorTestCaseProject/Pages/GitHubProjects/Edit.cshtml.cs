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
    public class EditModel : PageModel
    {
        private readonly RazorTestCaseProject.Data.RazorTestCaseProjectContext _context;

        public EditModel(RazorTestCaseProject.Data.RazorTestCaseProjectContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GitHubProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GitHubProjectExists(GitHubProject.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GitHubProjectExists(int id)
        {
            return _context.GitHubProject.Any(e => e.ID == id);
        }
    }
}
