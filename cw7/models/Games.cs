using System;

namespace cw7.models;

public class Games
{
    public int Id{get;set;}
    public string? Title{get;set;}
    public DateOnly ReleseDate{get;set;}
    public string? Genre{get;set;}
    public double? Price{get;set;}
}
