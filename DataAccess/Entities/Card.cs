namespace DataAccess.Models;
using System.ComponentModel.DataAnnotations;
public class Card
{
    public int Id { get; set; }

    [StringLength(200, MinimumLength = 10)]
    public string Front { get; set; } = "";

    [StringLength(200, MinimumLength = 10)]
    public string Back { get; set; } = "";
}