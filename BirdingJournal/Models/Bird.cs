using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BirdingJournal.Models {
    public class Bird {

        public long BirdID {get; set;}
        public string? BirdCommonName { get; set; }
        public string? BirdScientificName {get; set;}
        public string? BirdDescription {get; set;}
        public string? BirdHabitat {get; set;}

    }
}