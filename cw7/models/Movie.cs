 using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw7.models;

public class Movie
{
    public int Id{get;set;}
    [DisplayName("Tytul")]
    [Required(ErrorMessage ="Tytul jest wymagany")]
    public string? Title{get;set;}
    [DisplayName("Rezyser")]
    [Required(ErrorMessage ="Rezyser jest wymagany")]
    public string? Director{get;set;}
    [DisplayName("Data premiery")]
    [Required(ErrorMessage ="Data premiery jest wymagana")]
    public DateOnly? ReleseDate{get;set;}
    [DisplayName("Gatunek")]
    [Required(ErrorMessage ="Gatunek jest wymagany")]
    public string? Genre{get;set;}
    [DisplayName("Cena")]
    [Required(ErrorMessage ="Cena jest wymagana")]//walidacja
    [Range(0,2000,ErrorMessage =("Cena musi zawierac sie w przedziale od 0 do 2000"))]
    public double? Price{get;set;}
}
