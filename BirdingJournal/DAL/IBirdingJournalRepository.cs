using System;
using System.Collections.Generic;
using BirdingJournal.Models;

namespace BirdingJournal.DAL {
    public interface IBirdingJournalRepository {
        IEnumerable<BirdSighting> GetBirdSightings();
        BirdSighting GetBirdSightingByID(int birdSightingID);
        void UpdateBirdSighting(BirdSighting bs);
        void InsertBirdSighting(BirdSighting bs);
        void DeleteBirdSighting(int birdSightingID);
        void Save();
    }
}