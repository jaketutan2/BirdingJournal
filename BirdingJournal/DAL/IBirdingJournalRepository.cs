using System;
using System.Collections.Generic;
using BirdingJournal.Models;

namespace BirdingJournal.DAL {
    public interface IBirdingJournalRepository {
        IEnumerable<BirdSighting> GetBirdSightings();
        BirdSighting GetBirdSightingByID(long? birdSightingID);
        void UpdateBirdSighting(BirdSighting bs);
        void InsertBirdSighting(BirdSighting bs);
        void DeleteBirdSighting(long birdSightingID);
        void Save();
    }
}