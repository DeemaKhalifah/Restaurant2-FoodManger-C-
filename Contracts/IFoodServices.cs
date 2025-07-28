using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFoodServices
    {
        List<FoodDTO> GetAll();
        void Add(FoodDTO food);
        void Delete(int id);
        void Update(int id, FoodDTO updatedFood);

    }
}
