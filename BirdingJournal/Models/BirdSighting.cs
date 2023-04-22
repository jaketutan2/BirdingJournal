namespace BirdingJournal.Models {
    public class BirdSighting {
        public string? BirdCommonName { get; set; }
        public string? BirdScientificName {get; set;}
        public string? BirdFamily {get; set;}
        public string? Location { get; set; }
        public DateTime SpottedDate { get; set;}
        public string? Notes {get; set;}
        public Boolean IsFemale {get; set;}
        public Boolean IsJuvenile {get; set;}

    }
}