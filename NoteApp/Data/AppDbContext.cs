using Microsoft.EntityFrameworkCore;
using NoteApp.Models;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

    }
}
