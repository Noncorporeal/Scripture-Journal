using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.ScriptureNotes
{
    public class DeleteModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureNoteContext _context;

        public DeleteModel(ScriptureJournal.Data.ScriptureNoteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ScriptureNote ScriptureNote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ScriptureNote == null)
            {
                return NotFound();
            }

            var scripturenote = await _context.ScriptureNote.FirstOrDefaultAsync(m => m.ID == id);

            if (scripturenote == null)
            {
                return NotFound();
            }
            else 
            {
                ScriptureNote = scripturenote;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ScriptureNote == null)
            {
                return NotFound();
            }
            var scripturenote = await _context.ScriptureNote.FindAsync(id);

            if (scripturenote != null)
            {
                ScriptureNote = scripturenote;
                _context.ScriptureNote.Remove(ScriptureNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
