using BirdingJournal.Models;

namespace BirdingJournal.DAL {
    public class EFBirdingJournalRepository : IBirdingJournalRepository {
        private BirdingJournalDbContext context;

        public EFBirdingJournalRepository(BirdingJournalDbContext ctx) {
            context = ctx;
        }

        public IQueryable<BirdSighting> BirdSightings => context.BirdSightings;

        public void InsertBirdSighting(BirdSighting bs) {
            // context.Add(bs);
            context.SaveChanges();
        }

        public void DeleteBirdSighting(int birdSightingID) {
            // context.Remove(birdSightingID);
            context.SaveChanges();
        }

        public void UpdateBirdSighting(BirdSighting bs) {
            context.SaveChanges();
        }

        public IEnumerable<BirdSighting> GetBirdSightings(){
            return context.BirdSightings.ToList();
        }

        public BirdSighting GetBirdSightingByID(int id) {
            return context.BirdSightings.Find(id);
        }

        public void Save() {
            context.SaveChanges();
        }
    }
}