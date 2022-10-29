using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.ScriptureNotes
{
    public class CreateModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureNoteContext _context;

        public CreateModel(ScriptureJournal.Data.ScriptureNoteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScriptureNote ScriptureNote { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ScriptureNote == null || ScriptureNote == null)
            {
                return Page();
            }

            _context.ScriptureNote.Add(ScriptureNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
