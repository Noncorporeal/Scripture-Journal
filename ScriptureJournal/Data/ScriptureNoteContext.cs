using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace ScriptureJournal.Data
{
    public class ScriptureNoteContext : DbContext
    {
        public ScriptureNoteContext (DbContextOptions<ScriptureNoteContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournal.Models.ScriptureNote> ScriptureNote { get; set; } = default!;
    }
}
