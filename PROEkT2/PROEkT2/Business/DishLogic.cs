using PROEkT2.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROEkT2.Business
{
    public class DishLogic
    {
        private Dishes_Context dishes_Context = new Dishes_Context();
        public Dishes Get(int id)
        {
            Dishes findeDishe = dishes_Context.Dishes.Find(id);
            if (findeDishe !=null)
            {
                dishes_Context.Entry(findeDishe).Reference(x => x.Dishes_Types).Load();
            }
            return findeDishe;
        }
        public List<Dishes> GetAll()
        {
            return dishes_Context.Dishes.Include("Dishes_Types").ToList();
        }
        public void Create(Dishes dishes)
        {
            dishes_Context.Dishes.Add(dishes);
            dishes_Context.SaveChanges();
        }
        public void Update(int id,Dishes dishes)
        {
            Dishes findedDishes = dishes_Context.Dishes.Find(id);
            if (findedDishes == null)
            {
                return;
            }
            findedDishes.Name = dishes.Name;
            findedDishes.Price = dishes.Price;
            findedDishes.Stock = dishes.Stock;
            dishes_Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Dishes findeDishe = dishes_Context.Dishes.Find(id);
            dishes_Context.Dishes.Remove(findeDishe);
            dishes_Context.SaveChanges();
        }
    }

}    

