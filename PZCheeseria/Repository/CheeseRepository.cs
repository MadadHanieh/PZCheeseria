using PZCheeseria.Model;
using PZCheeseria.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PZCheeseria.Repository
{
    public class CheeseRepository : ICheeseRepository
    {
        private readonly IEnumerable<Cheese> AllCheese;
        public CheeseRepository()
        {
            AllCheese = new List<Cheese>
            {
                 new Cheese
                {
                    Id = 1,
                    Colour = "white and red",
                    Price = 1
                },
                new Cheese
                {
                    Id = 2,
                    Colour = "white and blue",
                    Price = 2
                },
                new Cheese
                {
                    Id = 3,
                    Colour = "white and green",
                    Price = 3
                },
                new Cheese
                {
                    Id = 4,
                    Colour = "white and purple",
                    Price = 4
                },
                new Cheese
                {
                    Id = 5,
                    Colour = "white and orange",
                    Price = 5
                }
            };
    }
        public Cheese Get(int id)
        {
            return AllCheese.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Cheese> GetAllCheese()
        {
            return AllCheese;
        }
    }
}
