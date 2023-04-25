namespace BirdingJournal.Models.ViewModels {
    public class BirdSightingListViewModel {
        public IEnumerable<BirdSighting> BirdSightings {get; set;} = Enumerable.Empty<BirdSighting>();
        public PagingInfo PagingInfo {get; set;} = new();
    }
}