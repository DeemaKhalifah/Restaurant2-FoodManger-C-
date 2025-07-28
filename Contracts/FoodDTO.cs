using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class FoodDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public FoodDTO(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public FoodDTO() { }
    }

}

