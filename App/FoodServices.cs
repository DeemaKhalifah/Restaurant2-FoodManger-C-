using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Domain;
using Contracts;
using EntityFramwork;

namespace App
{
    public class FoodServices : IFoodServices
    {
       // private List<Food> _foodList = new List<Food>();
        private readonly AppDbContext _context;

        public FoodServices()
        {
            _context = new AppDbContext();
        }
        public List<FoodDTO> GetAll()
        {

            IEnumerable<FoodDTO> query = _context.foods.Where(f => !f.IsDeleted).Select(f => new FoodDTO
            {
                Id = f.Id,
                Name = f.Name,
                Category = f.Category,
                Price = f.Price
            });
            return query.ToList();
        }

        public void Add(FoodDTO food)
        {
            if (food == null)
            {
                Console.WriteLine("Cannot add: input is null.");
                return;
            }
            IQueryable<Food> existing = _context.foods.Where(x => x.Name.ToLower() == food.Name.ToLower() && !x.IsDeleted);
            if (existing.Any())
            {
                Console.WriteLine($"food '{food.Name}' already exists.");
                return;
            }
            var food1 = new Food(food.Name, food.Price , food.Category);
            _context.foods.Add(food1);
            _context.SaveChanges();
            Console.WriteLine($"food '{food.Name}' is added.");
        }


        public void Delete(int id)
        {
            var food1 = _context.foods.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (food1 != null)
            {
                food1.IsDeleted = true;
                _context.SaveChanges();
                Console.WriteLine($"Food with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine($"Food with ID {id} not found or  already deleted.");
            }
        }

        public void Update(int id, FoodDTO updatedFood)
        {
            if (updatedFood == null)
            {
                Console.WriteLine(" Cannot update with null data");
                return;

            }
            var food = _context.foods.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (food != null )
            {
                food.Name = updatedFood.Name;
                food.Price = updatedFood.Price;
                food.Category = updatedFood.Category;
                _context.SaveChanges();

                Console.WriteLine($"Food with ID {id} updated successfully.");
            }
           else
            {
                Console.WriteLine($"Food with ID {id} not found or deleted.");
            }
        }

    }
}
