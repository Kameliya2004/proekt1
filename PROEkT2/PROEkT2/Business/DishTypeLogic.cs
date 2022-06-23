using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROEkT2.Data;
namespace PROEkT2.Business
{
    public class DishTypeLogic
    {
       private Dishes_Context dishesDbContext = new Dishes_Context();
        public List<Dishes_Type> GetDishesType()
        {
            return dishesDbContext.Dishes_Types.ToList();
        }
        public string GetDishesTypeById(int id)
        {
            return dishesDbContext.Dishes_Types.Find(id).Name;
        }
    }
}
