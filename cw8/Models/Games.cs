using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw8.models;

public class Games
{
    public int Id{get;set;}
    [DisplayName("Tytul")]
    [Required(ErrorMessage ="Tytul jest wymagany")]
    public string? Title{get;set;}
    [DisplayName("Data wydania")]
    [Required(ErrorMessage ="Data wydania jest wymagana")]
    public DateOnly ReleseDate{get;set;}
    [DisplayName("Gatunek")]
    [Required(ErrorMessage ="Gatunek jest wymagany")]
    public string? Genre{get;set;}
    [DisplayName("Cena")]
    [Required(ErrorMessage ="Cena jest wymagana")]//walidacja
    [Range(0,2000,ErrorMessage =("Cena musi zawierac sie w przedziale od 0 do 2000"))]
    public double? Price{get;set;}
}
