using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorTestCaseProject.Data;
using RazorTestCaseProject.Models;

namespace RazorTestCaseProject.Pages.GitHubProjects
{
    public class CreateModel : PageModel
    {
        private readonly RazorTestCaseProject.Data.RazorTestCaseProjectContext _context;

        public CreateModel(RazorTestCaseProject.Data.RazorTestCaseProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GitHubProject GitHubProject { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GitHubProject.Add(GitHubProject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
