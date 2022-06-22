using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROEkT2.Data
{
    public class Dishes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Dishes_Type Dishes_Types { get; set; }
        public int DishesTypeId { get; set; }
    }
}
