using System;

namespace makarony.Models;

public class Reservation
{
    public int Id { get; set; }
    public string? Date { get; set; }
    public int Place { get; set; }
    public int PersonCount { get; set; }
    public string? Phone { get; set; }
}
