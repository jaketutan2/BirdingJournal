using BirdingJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdingJournal.DAL {
    public class BirdingJournalDbContext: DbContext {
         public BirdingJournalDbContext(DbContextOptions<BirdingJournalDbContext> options) : base(options){
            
        }

        public DbSet<BirdSighting> BirdSightings {get; set;}
        public DbSet<User_> Users {get; set;}
        public DbSet<Bird> Birds {get; set;}

    }
}