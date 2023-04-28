using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BirdingJournal.Models {
    public class BirdSighting {
        public long? BirdSightingID {get; set;}
        [Required(ErrorMessage = "Please enter a value.")]
        public string? BirdCommonName {get; set;}
        public long? BirdID {get; set;}
        public long User_ID {get; set;}
        public string? Location { get; set; }
        [Required(ErrorMessage = "Please enter a value.")]
        public DateTime SpottedDate { get; set;}
        public string? Notes {get; set;}
        public string? IsFemale {get; set;}
        public string? IsJuvenile {get; set;}
    }
}