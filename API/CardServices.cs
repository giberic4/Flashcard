using DataAccess;
using DataAccess.Models;

namespace Services;
public class CardServices
{
    private readonly CardDbContext _context;

    public CardServices(CardDbContext context)
    {

        _context = context;

    }
    public Card CreateCard(Card c)
    {
        _context.Add(c);

        _context.SaveChanges();
        // _context.ChangeTracker.Clear();
        return c;
    }

    public List<Card> GetAll()
    {
        return _context.Cardset.ToList();
    }

    public Card GetCard(int id)
    {
        return _context.Cardset.FirstOrDefault(w => w.Id == id)!;

    }

    public Card UpdateCard(Card u)
    {
        _context.Update(u);
        _context.Cardset.ToList();
        _context.SaveChanges();
        return u;
    }

    public Card DeleteCard(Card d)
    {
        _context.Remove(d);
        _context.SaveChanges();
        return d;
    }





}