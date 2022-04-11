using PZCheeseria.Model;
using System.Collections.Generic;

namespace PZCheeseria.Repository.Interface
{
    public interface ICheeseRepository
    {
        IEnumerable<Cheese> GetAllCheese();
        Cheese Get(int id);
    }
}
