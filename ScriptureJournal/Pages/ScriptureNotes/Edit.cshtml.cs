using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.ScriptureNotes
{
    public class EditModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureNoteContext _context;

        public EditModel(ScriptureJournal.Data.ScriptureNoteContext context)
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

            var scripturenote =  await _context.ScriptureNote.FirstOrDefaultAsync(m => m.ID == id);
            if (scripturenote == null)
            {
                return NotFound();
            }
            ScriptureNote = scripturenote;
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

            _context.Attach(ScriptureNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptureNoteExists(ScriptureNote.ID))
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

        private bool ScriptureNoteExists(int id)
        {
          return (_context.ScriptureNote?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
