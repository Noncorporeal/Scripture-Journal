using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.ScriptureNotes
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureNoteContext _context;

        public IndexModel(ScriptureJournal.Data.ScriptureNoteContext context)
        {
            _context = context;
        }

        public IList<ScriptureNote> ScriptureNote { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public Book ? ScriptureBook { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Book> generateQuery = from n in _context.ScriptureNote
                                               orderby n.Book
                                               select n.Book;

            var notes = from n in _context.ScriptureNote
                         select n;
            if (!string.IsNullOrEmpty(SearchString))
            {
                notes = notes.Where(s => s.Note.ToLower().Contains(SearchString.ToLower()));
            }

            if (ScriptureBook != null)
            {
                notes = notes.Where(s => s.Book == ScriptureBook);
            }

            var books = await generateQuery.ToListAsync();
            var bookNames = new List<string>();
            foreach (Book b in books)
            {
                try
                {
                    bookNames.Add(b.GetDisplayName());
                }
                catch (Exception e)
                {
                    bookNames.Add(Enum.GetName(b));
                }
            }
            
            Books = new SelectList(bookNames);
            ScriptureNote = await notes.ToListAsync();
        }
    }
}
