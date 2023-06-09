using System;
using System.Collections.Generic;
using System.Linq;
using BirdingJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdingJournal.DAL{
    public class BirdingJournalRepository : IBirdingJournalRepository {
        
        private BirdingJournalDbContext context;

        public BirdingJournalRepository(BirdingJournalDbContext context) {
            this.context = context;
        }

        public IEnumerable<BirdSighting> GetBirdSightings(){
            return context.BirdSightings.ToList();
        }

        public BirdSighting GetBirdSightingByID(long? id) {
            return context.BirdSightings.Find(id);
        }

        public void InsertBirdSighting(BirdSighting birdSighting) {
            context.BirdSightings.Add(birdSighting);
            this.Save();
        }

        public void DeleteBirdSighting(long birdSightingID) {
            if (birdSightingID !=0) {
                BirdSighting birdSighting = context.BirdSightings?.Find(birdSightingID);
                context.BirdSightings.Remove(birdSighting);
                this.Save();       
            }    
        }

        public void UpdateBirdSighting(BirdSighting birdSighting) {
            context.Update(birdSighting);
            context.SaveChanges();
        }

        public void Save() {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed){
                if (disposing) {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}