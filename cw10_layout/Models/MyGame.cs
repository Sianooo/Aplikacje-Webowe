using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw10_layout.Models
{
    public class MyGame
    {
        public int Id { get; set; }
        
        [DisplayName("Tytuł gry")]
        [Required(ErrorMessage = "Tytuł gry jest wymagany")]
        public string Title { get; set; }
        
        [DisplayName("Gatunek gry")]
        [Required(ErrorMessage = "Gatunek gry jest wymagany")]
        public string Genre { get; set; }
        
        [DisplayName("Rok wydania")]
        [Required(ErrorMessage = "Rok wydania jest wymagany")]
        [Range(1900, 2100, ErrorMessage = "Rok wydania musi być w przedziale 1900-2100")]
        public int? ReleaseYear { get; set; }
    }
}
