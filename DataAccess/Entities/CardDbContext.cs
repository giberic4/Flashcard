using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
namespace DataAccess;

public class CardDbContext : DbContext
{
public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }

public DbSet<Card>  Cardset{get; set;}

}
